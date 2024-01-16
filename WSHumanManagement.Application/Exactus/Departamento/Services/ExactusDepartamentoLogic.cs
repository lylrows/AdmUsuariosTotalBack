using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Areas.Contracts;
using HumanManagement.Domain.Areas.Models;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Empresa.Contracts;
using HumanManagement.Domain.Empresa.Models;
using HumanManagement.Domain.General.Contracts;
using HumanManagement.Domain.General.Dto;
using HumanManagement.Domain.WindowsService.Exactus.Contracts;
using HumanManagement.Domain.WindowsService.Exactus.Dto;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WSHumanManagement.Application.Exactus.Departamento.IServices;
using Microsoft.Extensions.Configuration;

namespace WSHumanManagement.Application.Exactus.Departamento.Services
{

    public class ExactusDepartamentoLogic : IExactusDepartamentoLogic
    {
        private readonly IEmpresaRepository empresaRepository;
        private readonly IExactusDepartamentoRepository exactusDepartamentoRepository;
        private readonly IBaseRepository<Areas> baseAreaRepository;
        private readonly ILogger<ExactusDepartamentoLogic> _logger;
        public IConfiguration Configuration { get; }

        //private Timer feqProcessVh;
        //private Timer feqProcessDay;
        //private TimeSpan StartTime;
        //private TimeSpan EndTime;
        //private bool InProcess;

        public ParameterFilterDto ParameterFilter { get; set; }
        private readonly ICoreParameterRepository coreParameterRepository;
        public ExactusDepartamentoLogic(IEmpresaRepository empresaRepository,
                                    IExactusDepartamentoRepository exactusDepartamentoRepository,
                                    IAreaRepository areaRepository,
                                    IBaseRepository<Areas> baseAreaRepository,
                                    ICoreParameterRepository coreParameterRepository,
                                    ILogger<ExactusDepartamentoLogic> _logger,
                                    IConfiguration configuration
            )
        {
            this.exactusDepartamentoRepository = exactusDepartamentoRepository;
            this.empresaRepository = empresaRepository;
            this.baseAreaRepository = baseAreaRepository;
            this._logger = _logger;
            Configuration = configuration;

            this.coreParameterRepository = coreParameterRepository;

        }

        #region "Controlar Tiempo Ejecución"
        private Timer feqProcessVh;
        private Timer feqProcessDay;
        private bool InProcess { get; set; }
        private TimeSpan StartTime { get; set; }
        private TimeSpan EndTime { get; set; }
        public void Import()
        {
            try
            {
                feqProcessVh = new Timer(int.Parse(Configuration["AppSettings:Frecuencia"]));
                feqProcessVh.Elapsed += feqProcessVh_Elapsed;
                StartTime = DateTime.Parse(Configuration["AppSettings:StartTime"]).TimeOfDay;
                EndTime = DateTime.Parse(Configuration["AppSettings:EndTime"]).TimeOfDay;
                feqProcessVh.Start(); 
            }
            catch (Exception ex)
            {
                _logger.LogError("[Import: Falló Comenzar Proceso]-[Error: " + ex.Message);
                _logger.LogError("[Import: Falló Comenzar Proceso]-[Error: " + ex.StackTrace);
            }
        }

        public void Finish()
        {
            if (feqProcessDay != null && feqProcessDay.Enabled)
            {
                feqProcessDay.Stop();
                feqProcessDay.Elapsed -= feqProcessDay_Elapsed;
                feqProcessDay.Dispose();
                feqProcessDay = null;
            }

            if (feqProcessVh != null && feqProcessVh.Enabled)
            {
                feqProcessVh.Stop();
                feqProcessVh.Elapsed -= feqProcessVh_Elapsed;
                feqProcessVh.Dispose();
                feqProcessVh = null;
            }
            InProcess = false;
        }

        void feqProcessDay_Elapsed(object sender, ElapsedEventArgs e)
        {
            IniciarImport();
        }

        void feqProcessVh_Elapsed(object sender, ElapsedEventArgs e)
        {
            _logger.LogInformation("Ejecutando Proceso...");
            var horaActual = DateTime.Now.TimeOfDay;
            var _dayOfWeek = (int)DateTime.Now.DayOfWeek;
            var _dayOfMonth = (int)DateTime.Now.Day;
            _logger.LogInformation(string.Format("horaActual => {0}, StartTime => {1}, EndTime => {2}, _dayOfWeek => {3}, _dayOfMonth => {4}", horaActual, StartTime, EndTime, _dayOfWeek, _dayOfMonth));
            //Primer Corte
            if (horaActual >= StartTime && horaActual <= EndTime)
            {
                _logger.LogInformation("Ingreso al Proceso");
                IniciarImport();
            }
            else
            {
                if (feqProcessDay != null && feqProcessDay.Enabled)
                {
                    InProcess = false;
                    feqProcessDay.Stop();
                }
            }
        }
        #endregion

        public void IniciarImport()
        {
            _logger.LogInformation("Metodo Import  - Inicio");
            var CompaniesList = empresaRepository.GetAll().Result;
            _logger.LogInformation(string.Format("Se encontraron {0} compañías.", CompaniesList.Count()));
            ExactusDepartmentFilterDto filterDepartment = new ExactusDepartmentFilterDto();


            var areaslist = baseAreaRepository.GetAll().Result;
            _logger.LogInformation(string.Format("Se encontraron {0} Areas en gestión Humana.", areaslist.Count()));

            _logger.LogInformation("Se recorreran las compañias");
            foreach (var comp in CompaniesList)
            {
                try
                {
                    if (!string.IsNullOrEmpty(comp.Schema))
                    {
                        filterDepartment.Scheme = comp.Schema;

                        var departmentList = exactusDepartamentoRepository.GetAll(filterDepartment).Result;

                        _logger.LogInformation(string.Format("Se encontraron {0} Areas exactus para la compañía {1}.", departmentList.Count(), comp.Descripcion));

                        foreach (var depa in departmentList)
                        {

                            var exist = areaslist.Where(i => i.IdEmpresa == comp.Id && i.CodExactus == depa.DEPARTAMENTO).FirstOrDefault();


                            if (exist == null)
                            {
                                HumanManagement.Domain.Areas.Models.Areas newAreaBd = new HumanManagement.Domain.Areas.Models.Areas();

                                newAreaBd.IdEmpresa = comp.Id;
                                newAreaBd.NameArea = depa.DESCRIPCION;
                                newAreaBd.CodExactus = depa.DEPARTAMENTO;
                                newAreaBd.IdUpperArea = 0;
                                newAreaBd.Boss = depa.JEFE;

                                newAreaBd.Active = true;
                                newAreaBd.IdUserRegister = 1;
                                newAreaBd.DateRegister = DateTime.Now;
                                newAreaBd.IdUserUpdate = 1;
                                newAreaBd.DateUpdate = DateTime.Now;

                                _logger.LogInformation(string.Format("Se registrará el area {0}  para la compañía {1}.", depa.DESCRIPCION, comp.Descripcion));
                                baseAreaRepository.Add(newAreaBd).Wait();
                            }

                        }


                    }

                }
                catch (Exception ex)
                {

                    _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.Message);
                    _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.StackTrace);
                }

            }
            _logger.LogInformation("Metodo Import  - Fin");
        }


        private void SetParameter()
        {
            SetParameterBase();
        }
        private void SetParameterBase()
        {

            ParameterFilter.ApplicationName = Constants.HumanManagemen.ApplicationName;
            ParameterFilter.Module = Constants.HumanManagemen.ModuleCommon;

        }

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}