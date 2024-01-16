using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Empresa.Contracts;
using HumanManagement.Domain.SalaryBand.Contracts;
using HumanManagement.Domain.SalaryBand.Dto;
using HumanManagement.Domain.SalaryBand.Models;
using HumanManagement.Domain.WindowsService.Exactus.Contracts;
using HumanManagement.Domain.WindowsService.Exactus.Dto;
using Microsoft.Extensions.Logging;
using System;

using System.Linq;
using System.Timers;
using WSHumanManagement.Application.Exactus.Nomina.IServices;
using Microsoft.Extensions.Configuration;
using HumanManagement.Domain.MasterTable.Dto;
using HumanManagement.Domain.Person.Contracts;

namespace WSHumanManagement.Application.Exactus.Nomina.Services
{



    public class ExactusNominaService : IExactusNominaService
    {
        private readonly IEmpresaRepository empresaRepository;

        private readonly IExactusNominaRepository exactusNominaRepository;
        private readonly IBaseRepository<SalaryConcept> baseSalaryConceptRepository;

        private readonly IBaseRepository<SalaryPayrollDet> baseSalaryPayrollDetRepository;
        private readonly IExactusNominaCabRepository exactusNominaCabRepository;
        private readonly IBaseRepository<SalaryPayrollCab> baseSalaryPayrollCabRepository;
        private readonly ILogger<ExactusNominaService> _logger;
        private readonly ISalaryBandRepository salaryBandRepository;
        private readonly IPersonRepository personRepository;
        public IConfiguration Configuration { get; }


        public ExactusNominaService(IEmpresaRepository empresaRepository,
            IBaseRepository<SalaryConcept> baseSalaryConceptRepository,
            IExactusNominaRepository exactusNominaRepository,
            IBaseRepository<SalaryPayrollDet> baseSalaryPayrollDetRepository,
            IExactusNominaCabRepository exactusNominaCabRepository,
            IBaseRepository<SalaryPayrollCab> baseSalaryPayrollCabRepository,
            ILogger<ExactusNominaService> _logger,
            ISalaryBandRepository salaryBandRepository,
                                    IPersonRepository personRepository,
            IConfiguration configuration
            )
        {
            this.empresaRepository = empresaRepository;
            this.baseSalaryConceptRepository = baseSalaryConceptRepository;
            this.exactusNominaRepository = exactusNominaRepository;
            this.baseSalaryPayrollDetRepository = baseSalaryPayrollDetRepository;
            this.exactusNominaCabRepository = exactusNominaCabRepository;
            this.baseSalaryPayrollCabRepository = baseSalaryPayrollCabRepository;
            this._logger = _logger;
            this.salaryBandRepository = salaryBandRepository;
            this.personRepository = personRepository;
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
            iniciar();
        }

        void feqProcessVh_Elapsed(object sender, ElapsedEventArgs e)
        {
            _logger.LogInformation("Ejecutando Proceso...");
            var horaActual = DateTime.Now.TimeOfDay;
            var _dayOfWeek = (int)DateTime.Now.DayOfWeek;
            var _dayOfMonth = (int)DateTime.Now.Day;
            //Convert.ToInt32(ConfigurationManager.AppSettings["DayOfWeek"]) == _day
            _logger.LogInformation(string.Format("horaActual => {0}, StartTime => {1}, EndTime => {2}, _dayOfWeek => {3}, _dayOfMonth => {4}", horaActual, StartTime, EndTime, _dayOfWeek, _dayOfMonth));
            //Primer Corte
            if (horaActual >= StartTime && horaActual <= EndTime && _dayOfMonth == int.Parse(Configuration["AppSettings:DayOfMonth"]))
            {
                _logger.LogInformation("Ingreso al Proceso");
                iniciar();
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

        public void iniciar()
        {
            var _request = new ServiceProcessDto()
            {
                scode_service = "SERVICE_NOMINA"
            };
            var _result = personRepository.ConsultarProcesoServicio(_request).Result;
            if (_result.nsate == 0)
            {
                _request.nsate = 1;
                var _result1 = personRepository.RegistrarProcesoServicio(_request).Result;
                IniciarImport();
                ImportLiquidacion();
                _request.nsate = 0;
                var _result2 = personRepository.RegistrarProcesoServicio(_request).Result;
            } else _logger.LogInformation("Metodo IniciarImport  - NO INGRESA");
        }
        public void IniciarImport()
        {

            var CompaniesList = empresaRepository.GetAll().Result;


            var oConceptsList = baseSalaryConceptRepository.GetAll().Result;

            string arCodConcepts = "'" + string.Join("','", oConceptsList.Select(i => i.CodConcept)) + "'";

            ExactusNominaFilterDto filterNomina = new ExactusNominaFilterDto();

            filterNomina.arCodConcepts = arCodConcepts;

            var currentpayrolls = baseSalaryPayrollDetRepository.GetAll().Result;

            var lstNominaCab = baseSalaryPayrollCabRepository.GetAll().Result;

            foreach (var comp in CompaniesList)
            {

                _logger.LogInformation($"Empresa: {comp.Id}");
                _logger.LogInformation($"Schema: {comp.Schema}");
                _logger.LogInformation($"Descripcion Empresa: {comp.Descripcion}");

                #region Importar Nomina

                if (!string.IsNullOrEmpty(comp.Schema))
                {
                    try
                    {
                        filterNomina.Scheme = comp.Schema;

                        ExactusNominaCabFilterDto filtercab = new ExactusNominaCabFilterDto();
                        filtercab.Scheme = comp.Schema;
                        var nominasExactus = exactusNominaCabRepository.GetAll(filtercab).Result;



                        int nFilas_nomina = nominasExactus.Count();

                        _logger.LogInformation($"ESQUEMA: {filtercab.Scheme} : {nFilas_nomina} registros de nóminas cabecera");

                        nominasExactus = nominasExactus.Where(i => i.FECHA_APLICACION != null).ToList();
                        nominasExactus = nominasExactus.Where(i => i.PERIODO.Year >= 2019).ToList();

                        foreach (var nominaexactuscab in nominasExactus)
                        {
                            int nYeadNomina = nominaexactuscab.PERIODO.Year;
                            int nMonthNomina = nominaexactuscab.PERIODO.Month;

                            _logger.LogInformation("*****************************");
                            _logger.LogInformation($"*PERIODO: { nYeadNomina}                             **");
                            _logger.LogInformation($"*MES:     { nMonthNomina}                            **");
                            _logger.LogInformation($"*NOMINA:  {  nominaexactuscab.NOMINA}                **");
                            _logger.LogInformation($"*NUMERO_NOMINA:  { nominaexactuscab.NUMERO_NOMINA}   **");
                            _logger.LogInformation("*****************************");


                            var currentNominaCabPortal = lstNominaCab.Where(i => i.IdCompany == comp.Id
                                                                              && i.NominaCode == nominaexactuscab.NOMINA
                                                                              && i.NominaNumber == nominaexactuscab.NUMERO_NOMINA
                                                                            ).FirstOrDefault();


                            if (currentNominaCabPortal == null)
                            {
                                _logger.LogInformation("La nomina no existe en plataforma  entonces se procede a importar");

                                SalaryPayrollCab newsalaryPayrollCabBD = new SalaryPayrollCab();
                                newsalaryPayrollCabBD.IdCompany = comp.Id;
                                newsalaryPayrollCabBD.Year = nYeadNomina;
                                newsalaryPayrollCabBD.Month = nMonthNomina;
                                newsalaryPayrollCabBD.NominaCode = nominaexactuscab.NOMINA;
                                newsalaryPayrollCabBD.NominaNumber = nominaexactuscab.NUMERO_NOMINA;
                                newsalaryPayrollCabBD.PERIODO = nominaexactuscab.PERIODO;
                                newsalaryPayrollCabBD.FECHA_APROBACION = nominaexactuscab.FECHA_APROBACION;
                                newsalaryPayrollCabBD.FECHA_PAGO = nominaexactuscab.FECHA_PAGO;
                                newsalaryPayrollCabBD.APROBADA_POR = nominaexactuscab.APROBADA_POR;



                                var nRegisterCabecera = salaryBandRepository.RegisterNominaCab(newsalaryPayrollCabBD).Result;


                                if (nRegisterCabecera > 0)
                                {
                                    _logger.LogInformation($"Se regristó correctamente la Nomina {nominaexactuscab.NOMINA} { nominaexactuscab.NUMERO_NOMINA}");

                                    filterNomina.NominaCode = newsalaryPayrollCabBD.NominaCode;
                                    filterNomina.NominaNumber = newsalaryPayrollCabBD.NominaNumber;


                                    var nominalistexactus = exactusNominaRepository.GetAll(filterNomina).Result;

                                    int nTotalDetalleNomina = nominalistexactus.Count();

                                    _logger.LogInformation($"Se encontró { nTotalDetalleNomina} registros para la nómina la Nomina {nominaexactuscab.NOMINA} { nominaexactuscab.NUMERO_NOMINA}");


                                    foreach (var nominaexactusdet in nominalistexactus)
                                    {

                                        SalaryPayrollDet newPayrollDet = new SalaryPayrollDet();


                                        newPayrollDet.IdCompany = comp.Id;
                                        newPayrollDet.Consecutive = nominaexactusdet.CONSECUTIVO;
                                        newPayrollDet.CodEmployee = nominaexactusdet.EMPLEADO;
                                        newPayrollDet.Concept = nominaexactusdet.CONCEPTO;
                                        newPayrollDet.Payroll = nominaexactusdet.NOMINA;
                                        newPayrollDet.PayRollNumber = nominaexactusdet.NUMERO_NOMINA;
                                        newPayrollDet.CostCenter = nominaexactusdet.CENTRO_COSTO;
                                        newPayrollDet.Amount = nominaexactusdet.MONTO;
                                        newPayrollDet.Total = nominaexactusdet.TOTAL;
                                        newPayrollDet.RegisterType = nominaexactusdet.TIPO_REGISTRO;


                                        newPayrollDet.Active = true;
                                        newPayrollDet.IdUserRegister = 1;
                                        newPayrollDet.DateRegister = DateTime.Now;
                                        newPayrollDet.IdUserUpdate = 1;
                                        newPayrollDet.DateUpdate = DateTime.Now;

                                        int nresuldetail = salaryBandRepository.RegisterNominaDetail(newPayrollDet).Result;

                                        _logger.LogInformation($"Se registró correctamente el consecutivo {nominaexactusdet.CONSECUTIVO} para la nomina=>  {nominaexactuscab.NOMINA} { nominaexactuscab.NUMERO_NOMINA}");

                                        nTotalDetalleNomina--;
                                        _logger.LogInformation($"{nTotalDetalleNomina} registros restantes.");
                                    }
                                    _logger.LogInformation($"Se registró correctamente todos los detalles para la nomina=>  {nominaexactuscab.NOMINA} { nominaexactuscab.NUMERO_NOMINA}");
                                    _logger.LogInformation($"==============================================================================");

                                }
                                else
                                {
                                    _logger.LogError($"No se pudo registrar correctamente la Nomina {nominaexactuscab.NOMINA} { nominaexactuscab.NUMERO_NOMINA}");
                                }

                            }
                            else
                            {
                                _logger.LogInformation("La Nomina Ya existe,  se procederá  a registrar los nuevos detalles");



                                _logger.LogInformation($"  Buscando Registros para la nómina =>  {nominaexactuscab.NOMINA} { nominaexactuscab.NUMERO_NOMINA}");

                                _logger.LogInformation($"currentNominaCabPortal.NominaCode: {currentNominaCabPortal.NominaCode}");
                                _logger.LogInformation($"currentNominaCabPortal.NominaNumber: {currentNominaCabPortal.NominaNumber}");
                                _logger.LogInformation($"currentNominaCabPortal.IdCompany: {currentNominaCabPortal.IdCompany}");


                                var detallenominaportal = salaryBandRepository.GetSalaryPayrollDets(currentNominaCabPortal.NominaCode, currentNominaCabPortal.NominaNumber, currentNominaCabPortal.IdCompany).Result;

                                filterNomina.NominaCode = currentNominaCabPortal.NominaCode;
                                filterNomina.NominaNumber = currentNominaCabPortal.NominaNumber;


                                var nominalistexactus = exactusNominaRepository.GetAll(filterNomina).Result;
                                int nRegistrosExactus = nominalistexactus.Count();
                                int nRegistrosPortal = detallenominaportal.Count();
                                int nRegistrosDiferentes = nRegistrosExactus - nRegistrosPortal;




                                _logger.LogInformation($"Registros detalle Exactus: { nRegistrosExactus}");
                                _logger.LogInformation($"Registros detalle Portal: { nRegistrosPortal}");

                                _logger.LogInformation($"Registros Por insertar: {  nRegistrosExactus - nRegistrosPortal}");

                                foreach (var nominaexactusdet in nominalistexactus)
                                {
                                    var nominadetportal = detallenominaportal.Where(i => i.Consecutive == nominaexactusdet.CONSECUTIVO).FirstOrDefault();


                                    if (nominadetportal == null)
                                    {
                                        _logger.LogInformation($"Se registrará el consecutivo {nominaexactusdet.CONSECUTIVO } ");

                                        SalaryPayrollDet newPayrollDet = new SalaryPayrollDet();


                                        newPayrollDet.IdCompany = comp.Id;
                                        newPayrollDet.Consecutive = nominaexactusdet.CONSECUTIVO;
                                        newPayrollDet.CodEmployee = nominaexactusdet.EMPLEADO;
                                        newPayrollDet.Concept = nominaexactusdet.CONCEPTO;
                                        newPayrollDet.Payroll = nominaexactusdet.NOMINA;
                                        newPayrollDet.PayRollNumber = nominaexactusdet.NUMERO_NOMINA;
                                        newPayrollDet.CostCenter = nominaexactusdet.CENTRO_COSTO;
                                        newPayrollDet.Amount = nominaexactusdet.MONTO;
                                        newPayrollDet.Total = nominaexactusdet.TOTAL;
                                        newPayrollDet.RegisterType = nominaexactusdet.TIPO_REGISTRO;


                                        int nresuldetail = salaryBandRepository.RegisterNominaDetail(newPayrollDet).Result;

                                        _logger.LogInformation($"Se registró correctamente el consecutivo {nominaexactusdet.CONSECUTIVO} para la nomina=>  {nominaexactuscab.NOMINA} { nominaexactuscab.NUMERO_NOMINA}");

                                        nRegistrosDiferentes--;
                                        _logger.LogInformation($"{nRegistrosDiferentes} registros restantes.");
                                    }

                                }
                                _logger.LogInformation($"Se registró correctamente todos los detalles para la nomina=>  {nominaexactuscab.NOMINA} { nominaexactuscab.NUMERO_NOMINA}");

                            }

                            _logger.LogInformation($"Se terminó de procesar la Nomina {nominaexactuscab.NOMINA} { nominaexactuscab.NUMERO_NOMINA}");
                        }

                        _logger.LogInformation($"Se terminó de procesar la empresa {comp.Schema}");
                    }
                    catch (Exception ex)
                    {

                        _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.Message);
                        _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.StackTrace);
                    }

                }

                #endregion



            }


        }

        public void ImportLiquidacion()
        {
            _logger.LogInformation($"IMPORTACION DE LIQUIDACIONES");

            var CompaniesList = empresaRepository.GetAll().Result;

            foreach (var comp in CompaniesList)
            {

                if (!string.IsNullOrEmpty(comp.Schema))
                {
                    _logger.LogInformation($"Se procesará la empresa {comp.Schema}");
                    var liquidacionesCabExactus = exactusNominaCabRepository.GetLiquidacionCab(comp.Schema).Result;

                    var liquidacionesCabGH = salaryBandRepository.GetLiquidacionCabList(comp.Id).Result;

                    int nRegistrosCabPendientes = liquidacionesCabExactus.Count() - liquidacionesCabGH.Count();

                    _logger.LogInformation($"Se registrarán {nRegistrosCabPendientes} liquidaciones");

                    foreach (var item in liquidacionesCabExactus)
                    {

                        var existCab = liquidacionesCabGH.Where(i => i.nliquidation == item.LIQUIDACION).FirstOrDefault();

                        if (existCab == null)
                        {


                            #region Registrar Cabecera Liquidacion





                            LiquidacionCabDto dtocab = new LiquidacionCabDto();

                            dtocab.nidcompany = comp.Id;
                            dtocab.nliquidation = item.LIQUIDACION;
                            dtocab.scodemployee = item.EMPLEADO;
                            dtocab.scurrency = item.MONEDA;
                            dtocab.sstateliquidation = item.ESTADO_LIQUIDAC;
                            dtocab.ddate_in = item.FECHA_INGRESO;
                            dtocab.ddate_out = item.FECHA_SALIDA;
                            dtocab.sclose_contracts = item.CERRAR_CONTRATOS;
                            dtocab.nnumberaction = item.NUMERO_ACCION;
                            dtocab.spayway = item.FORMA_PAGO;
                            dtocab.saccountbank = item.CUENTA_BANCO;
                            dtocab.snumber_document_pay = item.NUMERO_DOC_PAGO;
                            dtocab.saccountseat = item.ASIENTO_CONTABLE;
                            dtocab.ddate_out_pay = item.FECHA_RETIRO_PAGO;
                            dtocab.suser_liquidation = item.USUARIO_LIQUIDAC;
                            dtocab.ddate_liquidation = item.FECHA_LIQUIDACION;
                            dtocab.nsubtypedoc_pay = item.SUBTIPODOC_PAGO;
                            dtocab.sbudget = item.PRESUPUESTO;
                            dtocab.sunit_operative = item.UNIDAD_OPERATIVA;
                            dtocab.nnumber_apart = item.NUMERO_APARTADO;
                            dtocab.nnumber_exercised = item.NUMERO_EJERCIDO;
                            dtocab.scalc_pay_nomina = item.CALCULA_PAGO_NOMINA;
                            dtocab.snomina_calc = item.NOMINA_CALCULO;
                            dtocab.nnumber_nomina_calc = item.NUMERO_NOMINA_CALCULO;
                            dtocab.scontract_term_type = item.TIPO_EXTINCION_CONTRATO;
                            dtocab.ssituation_unac = item.SITUACION_INAC;


                            int nResultCab = salaryBandRepository.RegisterLiquidacionCab(dtocab).Result;

                            if (nResultCab > 0)
                            {



                                _logger.LogInformation($"Se registró correctamente la liquidación {dtocab.nliquidation}");
                                #region Registrar Detalle


                                var liquidacionesDetExactus = exactusNominaCabRepository.GetLiquidacionDet(comp.Schema, dtocab.nliquidation).Result;



                                foreach (var det in liquidacionesDetExactus)
                                {


                                    LiquidacionDetDto dtoinsDet = new LiquidacionDetDto();

                                    dtoinsDet.nidcompany = comp.Id;
                                    dtoinsDet.nliquidation = det.LIQUIDACION;
                                    dtoinsDet.nline = det.LINEA;
                                    dtoinsDet.sconcept = det.CONCEPTO;
                                    dtoinsDet.sdescription = det.DESCRIPCION;
                                    dtoinsDet.stypeconcept = det.TIPO_CONCEPTO;
                                    dtoinsDet.nsequence = det.SECUENCIA;
                                    dtoinsDet.nquantity = det.CANTIDAD;
                                    dtoinsDet.namount = det.MONTO;
                                    dtoinsDet.ntotal_calc = det.TOTAL_CALCULADO;
                                    dtoinsDet.scentercost = det.CENTRO_COSTO;
                                    dtoinsDet.sledgeraccount = det.CUENTA_CONTABLE;


                                    int nResultDet = salaryBandRepository.RegisterLiquidacionDet(dtoinsDet).Result;
                                    if (nResultDet > 0)
                                    {
                                        _logger.LogInformation($"Se registró correctamente el concepto {dtoinsDet.sconcept}");
                                    }
                                    else
                                    {
                                        _logger.LogInformation($"No se registró correctamente el concepto {dtoinsDet.sconcept}");
                                    }

                                }





                                #endregion


                            }
                            else
                            {
                                _logger.LogInformation($"No se registró correctamente la liquidación {dtocab.ddate_liquidation}");
                            }

                            #endregion
                        }

                        nRegistrosCabPendientes--;
                        _logger.LogInformation($"{nRegistrosCabPendientes} restantes");

                        _logger.LogInformation($"-----------------------------------------------------");

                    }
                }
                _logger.LogInformation($"********************************************************************");
            }
            _logger.LogInformation($"*******************    F I N     ***************************");


        }

    }
}