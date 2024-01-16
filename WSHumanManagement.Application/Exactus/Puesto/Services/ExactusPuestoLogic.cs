using HumanManagement.Domain.Cargo.Contracts;
using HumanManagement.Domain.Cargo.Models;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Empresa.Contracts;
using HumanManagement.Domain.WindowsService.Exactus.Contracts;
using HumanManagement.Domain.WindowsService.Exactus.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSHumanManagement.Application.Exactus.Puesto.IServices;
using HumanManagement.Domain.Areas.Models;
using Microsoft.Extensions.Logging;
using HumanManagement.Domain.SalaryBand.Models;
using System.Timers;
using Microsoft.Extensions.Configuration;

namespace WSHumanManagement.Application.Exactus.Puesto.Services
{
    public class ExactusPuestoLogic : IExactusPuestoLogic
    {
        private readonly IEmpresaRepository empresaRepository;
        private readonly IExactusPuestoRepository exactusPuestoRepository;
        private readonly IBaseRepository<Cargo> baseCargoRepository;
        private readonly IBaseRepository<Areas> baseAreaRepository;
        private readonly ILogger<ExactusPuestoLogic> _logger;
        private readonly IBaseRepository<SalaryBand> baseBandBoxRepository;
        public IConfiguration Configuration { get; }

        public ExactusPuestoLogic(IEmpresaRepository empresaRepository,
                                    IExactusPuestoRepository exactusPuestoRepository,
                                    IBaseRepository<Cargo> baseCargoRepository,
                                    IBaseRepository<Areas> baseAreaRepository,
                                    ILogger<ExactusPuestoLogic> _logger,
                                    IBaseRepository<SalaryBand> baseBandBoxRepository,
                                    IConfiguration configuration

            )
        {
            this.exactusPuestoRepository = exactusPuestoRepository;
            this.empresaRepository = empresaRepository;
            this.baseCargoRepository = baseCargoRepository;
            this.baseAreaRepository = baseAreaRepository;
            this._logger = _logger;
            this.baseBandBoxRepository = baseBandBoxRepository;
            Configuration = configuration;
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
            try
            {
                _logger.LogInformation("Ejecutando Proceso...");
                var horaActual = DateTime.Now.TimeOfDay;
                var _dayOfWeek = (int)DateTime.Now.DayOfWeek;
                var _dayOfMonth = (int)DateTime.Now.Day;
                //Convert.ToInt32(ConfigurationManager.AppSettings["DayOfWeek"]) == _day
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
            catch (Exception ex)
            {
                var error = ex;
            }
           
        }
        #endregion

        public void IniciarImport()
        {
            _logger.LogInformation("Metodo Import  - Inicio");
            var CompaniesList = empresaRepository.GetAll().Result;
            _logger.LogInformation(string.Format("Se encontraron {0} compañías.", CompaniesList.Count()));

            ExactusPuestoFilterDto filterPuesto = new ExactusPuestoFilterDto();


            var Cargoslist = baseCargoRepository.GetAll().Result; 
            _logger.LogInformation(string.Format("Se encontraron {0} Cargos en gestión Humana.", Cargoslist.Count()));

            var areaslist = baseAreaRepository.GetAll().Result;
            _logger.LogInformation(string.Format("Se encontraron {0} Areas en gestión Humana.", areaslist.Count()));

            _logger.LogInformation("Se recorreran las compañias");


            var bandboxlist = baseBandBoxRepository.GetAll().Result;

            foreach (var comp in CompaniesList)
            {
                try
                {
                    if (!string.IsNullOrEmpty(comp.Schema))
                    {
                        filterPuesto.Scheme = comp.Schema;


                        var puestoList = exactusPuestoRepository.GetAll(filterPuesto).Result;

                        _logger.LogInformation(string.Format("Se encontraron {0} Puestos exactus para la compañía {1}.", puestoList.Count(), comp.Descripcion));

                        int nIdAreaDefault = areaslist.Where(i => i.IdEmpresa == comp.Id && i.CodExactus == "ND").Select(i => i.Id).FirstOrDefault();

                        foreach (var puesto in puestoList)
                        {

                            var exist = Cargoslist.Where(i => i.IdEmpresa == comp.Id && i.CodExactus == puesto.PUESTO).FirstOrDefault();

                            if (exist == null)
                            {
                                HumanManagement.Domain.Cargo.Models.Cargo newCargoBd = new HumanManagement.Domain.Cargo.Models.Cargo();

                                newCargoBd.IdEmpresa = comp.Id;
                                newCargoBd.NameCargo = puesto.DESCRIPCION;
                                newCargoBd.CodExactus = puesto.PUESTO;
                                newCargoBd.IdUpperCargo = 0;
                                newCargoBd.IdArea = nIdAreaDefault;


                                newCargoBd.Active = puesto.ACTIVO == "S" ? true : false;
                                newCargoBd.IdUserRegister = 1;
                                newCargoBd.DateRegister = DateTime.Now;
                                newCargoBd.IdUserUpdate = 1;
                                newCargoBd.DateUpdate = DateTime.Now;
                                _logger.LogInformation(string.Format("Se registrará puesto {0}  para la compañía {1}.", puesto.DESCRIPCION, comp.Descripcion));

                                baseCargoRepository.Add(newCargoBd).Wait();

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
            _logger.LogInformation("==========================Metodo Import  - Fin==========================");
        }

    }
}