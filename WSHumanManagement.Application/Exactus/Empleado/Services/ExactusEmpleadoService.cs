using AutoMapper;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Spreadsheet;
using HumanManagement.Domain.Areas.Models;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Cargo.Models;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Employee.Contracts;
using HumanManagement.Domain.Employee.Models;
using HumanManagement.Domain.Empresa.Contracts;

using HumanManagement.Domain.General.Models;
using HumanManagement.Domain.Mail.Contracts;
using HumanManagement.Domain.MasterTable.Contracts;
using HumanManagement.Domain.MasterTable.Dto;
using HumanManagement.Domain.Models;
using HumanManagement.Domain.Person.Contracts;
using HumanManagement.Domain.Person.Models;
using HumanManagement.Domain.Security.Contracts;
using HumanManagement.Domain.Security.Dto;
using HumanManagement.Domain.Security.Entities;
using HumanManagement.Domain.Security.Events;
using HumanManagement.Domain.Security.Models;
using HumanManagement.Domain.WindowsService.Exactus.Contracts;
using HumanManagement.Domain.WindowsService.Exactus.Dto;
using HumanManagement.Domain.WindowsService.Exactus.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using WSHumanManagement.Application.Exactus.Empleado.IServices;

namespace WSHumanManagement.Application.Exactus.Empleado.Services
{

    public class ExactusEmpleadoService : IExactusEmpleadoService
    {
        private readonly IEmpresaRepository empresaRepository;
        private readonly IExactusEmpleadoRepository exactusEmpleadoRepository;
        private readonly IBaseRepository<Cargo> baseCargoRepository;
        private readonly IBaseRepository<Areas> baseAreaRepository;
        private readonly IBaseRepository<EmployeeModel> baseEmployeeRepository;
        private readonly IBaseRepository<Bank> baseBankRepository;
        private readonly IMapper mapper;
        private readonly ICryptography cryptography;
        private readonly IBaseRepository<PersonModel> basePersonRepository;
        private readonly IBaseRepository<EmployeeFile> baseEmployeeFileRepository;
        private readonly IBaseRepository<User> baseUserRepository;
        private List<UserMailDto> userMailDtoList;
        private readonly IMailRepository mailRepository;
        private readonly IHtmlReader htmlReader;
        public IConfiguration Configuration { get; }
        private readonly IEmployeeRepository employeeRepository;
        private readonly IExactusBaseRepository<ExactusEALLEmpleado> baseEAllEmpleadoRepository;
        private readonly ILogger<ExactusEmpleadoService> _logger;
        private readonly IMasterTableRepository masterTableRepository;
        private readonly IBaseRepository<Address> baseAddressRepository;
        private readonly IPersonRepository personRepository;
        private readonly IBaseRepository<Phone> basePhoneRepository;
        private readonly IBaseRepository<ProfileUser> baseProfileUserRepository;





        public ExactusEmpleadoService(IEmpresaRepository empresaRepository,
                                    IExactusEmpleadoRepository exactusEmpleadoRepository,
                                    IBaseRepository<Cargo> baseCargoRepository,
                                    IBaseRepository<Areas> baseAreaRepository,
                                    IBaseRepository<EmployeeModel> baseEmployeeRepository,
                                    IBaseRepository<Bank> baseBankRepository,
                                    IMapper mapper,
                                    ICryptography cryptography,
                                    IBaseRepository<PersonModel> basePersonRepository,
                                    IBaseRepository<EmployeeFile> baseEmployeeFileRepository,
                                    IBaseRepository<User> baseUserRepository,
                                    IMailRepository mailRepository,
                                    IHtmlReader htmlReader,
                                    IConfiguration configuration,
                                    IEmployeeRepository employeeRepository,
                                    IExactusBaseRepository<ExactusEALLEmpleado> baseEAllEmpleadoRepository,
                                    ILogger<ExactusEmpleadoService> _logger,
                                    IMasterTableRepository masterTableRepository,
                                    IBaseRepository<Address> baseAddressRepository,
                                    IPersonRepository personRepository,
                                    IBaseRepository<Phone> basePhoneRepository,
                                    IBaseRepository<ProfileUser> baseProfileUserRepository
            )
        {
            this.exactusEmpleadoRepository = exactusEmpleadoRepository;
            this.empresaRepository = empresaRepository;
            this.baseCargoRepository = baseCargoRepository;
            this.baseAreaRepository = baseAreaRepository;
            this.baseEmployeeRepository = baseEmployeeRepository;
            this.baseBankRepository = baseBankRepository;
            this.cryptography = cryptography;
            this.basePersonRepository = basePersonRepository;
            this.baseEmployeeFileRepository = baseEmployeeFileRepository;
            this.baseUserRepository = baseUserRepository;
            this.mapper = mapper;
            userMailDtoList = new List<UserMailDto>();
            this.mailRepository = mailRepository;
            this.htmlReader = htmlReader;
            Configuration = configuration;
            this.employeeRepository = employeeRepository;
            this.baseEAllEmpleadoRepository = baseEAllEmpleadoRepository;
            this._logger = _logger;
            this.masterTableRepository = masterTableRepository;
            this.baseAddressRepository = baseAddressRepository;
            this.personRepository = personRepository;
            this.basePhoneRepository = basePhoneRepository;
            this.baseProfileUserRepository = baseProfileUserRepository;
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
        #endregion

        public void IniciarImport()
        {
            var _request = new ServiceProcessDto()
            {
                scode_service = "SERVICE_EMPLEADO"
            };
            var _result = personRepository.ConsultarProcesoServicio(_request).Result;

            if (_result.nsate == 0)
            {
                try
                {
                    _request.nsate = 1;
                    var _result1 = personRepository.RegistrarProcesoServicio(_request).Result;
                    _logger.LogInformation("Metodo IniciarImpor  - Inicio");
                    var CompaniesList = empresaRepository.GetAll().Result;
                    _logger.LogInformation(string.Format("Se encontraron {0} compañías.", CompaniesList.Count()));
                    ExactusEmpleadoFilterDto filterEmpleado = new ExactusEmpleadoFilterDto();

                    _logger.LogInformation("Metodo baseEmployeeRepository  - Inicio");
                    var EmpleadosBD = baseEmployeeRepository.GetAll().Result;
                    _logger.LogInformation("Metodo baseEmployeeRepository  - Fin");
                    _logger.LogInformation(string.Format("Se encontraron {0} Empleados en gestión Humana.", EmpleadosBD.Count()));

                    _logger.LogInformation("Metodo baseCargoRepository  - Inicio");
                    var Cargoslist = baseCargoRepository.GetAll().Result;
                    _logger.LogInformation("Metodo baseCargoRepository  - Fin");
                    _logger.LogInformation(string.Format("Se encontraron {0} Cargos en gestión Humana.", Cargoslist.Count()));

                    _logger.LogInformation("Metodo baseAreaRepository  - Inicio");
                    var areaslist = baseAreaRepository.GetAll().Result;
                    _logger.LogInformation("Metodo baseAreaRepository  - Fin");
                    _logger.LogInformation(string.Format("Se encontraron {0} Areas en gestión Humana.", areaslist.Count()));

                    _logger.LogInformation("Metodo baseBankRepository  - Inicio");
                    var bankList = baseBankRepository.GetAll().Result;
                    _logger.LogInformation("Metodo baseBankRepository  - Fin");
                    _logger.LogInformation(string.Format("Se encontraron {0} Bank en gestión Humana.", areaslist.Count()));

                    _logger.LogInformation("Metodo civilStatusList  - Inicio");
                    var civilStatusList = masterTableRepository.GetByIdFather(9).Result;
                    _logger.LogInformation("Metodo civilStatusList  - Fin");
                    _logger.LogInformation("Metodo nationalityList  - Inicio");
                    var nationalityList = masterTableRepository.GetByIdFather(8).Result;
                    _logger.LogInformation("Metodo nationalityList  - Fin");

                    _logger.LogInformation("Se recorreran las compañias");
                    foreach (var comp in CompaniesList)
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(comp.Schema))
                            {
                                filterEmpleado.Scheme = comp.Schema;

                                var fullempleado = exactusEmpleadoRepository.GetAll(filterEmpleado).Result;

                                _logger.LogInformation(string.Format("Se encontraron {0} Empleados exactus para la compañía {1}.", fullempleado.Empleados.Count(), comp.Descripcion));

                                int nIdAreaDefault = areaslist.Where(i => i.IdEmpresa == comp.Id && i.CodExactus == "ND").Select(i => i.Id).FirstOrDefault();

                                int nIdCargoDefault = Cargoslist.Where(i => i.IdEmpresa == comp.Id && i.CodExactus == "ND").Select(i => i.Id).FirstOrDefault();

                                List<ExactusEmpleadoDto> importedEmployeeList = new List<ExactusEmpleadoDto>();
                                int idcargoBD = 0;
                                int idempleado = 0;
                                foreach (var emp in fullempleado.Empleados)
                                {

                                    var exist = EmpleadosBD.Where(i => i.IdCompany == comp.Id && i.CodEmployee == emp.EMPLEADO).FirstOrDefault();

                                    if (exist == null && emp.ESTADO_EMPLEADO != "CESA")
                                    {
                                        //validar si existe la persona en el sitema, para cambiarle de compañia
                                        exist = EmpleadosBD.Where(i => i.CodEmployee == emp.EMPLEADO).FirstOrDefault();
                                        if (exist != null) exist.IdCompany = comp.Id;
                                    }

                                    if (exist == null)
                                    {
                                        //Agregar sp de eliminar usuario existente - JNR
                                        if (emp.ESTADO_EMPLEADO == "CESA")
                                        {
                                            continue;
                                        }

                                        string FirstName = string.Empty;
                                        string SecondName = string.Empty;

                                        emp.NOMBRE_PILA = emp.NOMBRE_PILA == null ? string.Empty : emp.NOMBRE_PILA;


                                        var arNombre = emp.NOMBRE_PILA.Trim().Split(" ");

                                        if (arNombre.Length == 1)
                                        {
                                            FirstName = arNombre[0];
                                        }
                                        else if (arNombre.Length == 2)
                                        {

                                            FirstName = arNombre[0];
                                            SecondName = arNombre[1];

                                        }
                                        else if (arNombre.Length > 2)
                                        {
                                            for (int i = 0; i < arNombre.Length; i++)
                                            {
                                                if (i == 0)
                                                {
                                                    FirstName = arNombre[i];
                                                }
                                                else if (i == 1)
                                                {
                                                    SecondName = arNombre[i];
                                                }
                                                else
                                                {
                                                    SecondName += " " + arNombre[i];
                                                }
                                            }

                                        }

                                        importedEmployeeList.Add(new ExactusEmpleadoDto
                                        {
                                            CodPerson = emp.EMPLEADO,
                                            FirstName = FirstName,
                                            SecondName = SecondName,
                                            LastName = emp.PRIMER_APELLIDO == null ? string.Empty : emp.PRIMER_APELLIDO,
                                            MotherLastName = emp.SEGUNDO_APELLIDO == null ? string.Empty : emp.SEGUNDO_APELLIDO,
                                            plaza = emp.PLAZA,
                                            IdSex = emp.SEXO == "M" ? 12 : 11,
                                            BirthDate = emp.FECHA_NACIMIENTO,
                                            Identification = emp.IDENTIFICACION,
                                            IsNoDomiciled = true,
                                            CodEmployee = emp.EMPLEADO,
                                            Email = emp.E_MAIL,
                                            AdmissionDate = emp.FECHA_INGRESO,

                                            IsDependents = true,

                                            DateOffirstAdmission = DateTime.Now,
                                            UniversityGraduationDate = null,
                                            CountryentryDate = null,

                                            IdState = emp.ESTADO_EMPLEADO == "CESA" ? 23 : 24,
                                            CodeCharge = emp.PUESTO,//codigo exactus puesto
                                            IdCompany = comp.Id,
                                            IdActive = emp.ACTIVO == "S" ? 21 : 20,

                                            IdCivilStatus = civilStatusList.Where(i => i.ShortValue == emp.ESTADO_CIVIL).Select(i => i.Id).FirstOrDefault(),
                                            BloodType = emp.TIPO_SANGRE,
                                            Passport = emp.PASAPORTE,

                                            IdNationality = nationalityList.Where(i => i.ShortValue == emp.PAIS).Select(i => i.Id).FirstOrDefault(),
                                            Sede = emp.UBICACION,
                                            CenterCost = emp.CENTRO_COSTO,
                                            CodeBank = emp.ENTIDAD_FINANCIERA,
                                            AccountBank = emp.CUENTA_ENTIDAD,
                                            Cciaccount_bank = string.Empty,
                                            CurrencyAccountBank = emp.RUBRO7,

                                            CodeBankCts = emp.RUBRO10,
                                            AccountCts = emp.RUBRO9,
                                            CurrencyCts = emp.RUBRO8,
                                            AfpCode = emp.RUBRO6,

                                            DEPARTAMENTO_DIR = emp.DEPARTAMENTO_DIR,
                                            PROVINCIA = emp.PROVINCIA,
                                            DISTRITO = emp.DISTRITO,
                                            DIRECCIONEMP = emp.DIRECCIONEMP,
                                            TELEFONO1 = emp.TELEFONO1,
                                            TELEFONO2 = emp.TELEFONO2,
                                            TELEFONO3 = emp.TELEFONO3,
                                            DIVISION_GEOGRAFICA2 = emp.DIVISION_GEOGRAFICA2


                                        });
                                    }
                                    else
                                    {
                                        idcargoBD = exist.IdPosition;


                                        int nIdStateExactusEmp = emp.ESTADO_EMPLEADO == "CESA" ? 23 : 24;

                                        if (nIdStateExactusEmp == 23)
                                        {
                                            _logger.LogInformation("Se actualizará la situación del empleado {0} en GH a  {1}", emp.NOMBRE_PILA, emp.ESTADO_EMPLEADO);
                                            exist.IdState = nIdStateExactusEmp;
                                        }
                                        #region Update Employee

                                        var personaupdate = basePersonRepository.Find(exist.IdPerson).Result;
                                        if (emp.ESTADO_EMPLEADO != "CESA")
                                        {


                                            #region Calcula Nombres


                                            string FirstName = string.Empty;
                                            string SecondName = string.Empty;

                                            emp.NOMBRE_PILA = emp.NOMBRE_PILA == null ? string.Empty : emp.NOMBRE_PILA;



                                            var arNombre = emp.NOMBRE_PILA.Trim().Split(" ");

                                            if (arNombre.Length == 1)
                                            {
                                                FirstName = arNombre[0];

                                            }
                                            else if (arNombre.Length == 2)
                                            {
                                                FirstName = arNombre[0];

                                                SecondName = arNombre[1];

                                            }
                                            else if (arNombre.Length > 2)
                                            {

                                                for (int i = 0; i < arNombre.Length; i++)
                                                {

                                                    if (i == 0)
                                                    {
                                                        FirstName = arNombre[i];
                                                    }
                                                    else if (i == 1)
                                                    {
                                                        SecondName = arNombre[i];
                                                    }
                                                    else
                                                    {
                                                        SecondName += " " + arNombre[i];
                                                    }
                                                }

                                            }


                                            personaupdate.FirstName = FirstName;
                                            personaupdate.SecondName = SecondName;
                                            personaupdate.LastName = emp.PRIMER_APELLIDO == null ? string.Empty : emp.PRIMER_APELLIDO;
                                            personaupdate.MotherLastName = emp.SEGUNDO_APELLIDO == null ? string.Empty : emp.SEGUNDO_APELLIDO;
                                            personaupdate.IdSex = emp.SEXO == "M" ? 12 : 11;
                                            personaupdate.BirthDate = emp.FECHA_NACIMIENTO;
                                            #endregion
                                            exist.plaza = emp.PLAZA;
                                            exist.IdState = nIdStateExactusEmp;
                                            personaupdate.Email = emp.E_MAIL;


                                            exist.AdmissionDate = emp.FECHA_INGRESO;



                                            personaupdate.IdCivilStatus = civilStatusList.Where(i => i.ShortValue == emp.ESTADO_CIVIL).Select(i => i.Id).FirstOrDefault();
                                            personaupdate.BloodType = emp.TIPO_SANGRE;
                                            personaupdate.Passport = emp.PASAPORTE;
                                            personaupdate.IdNationality = nationalityList.Where(i => i.ShortValue == emp.PAIS).Select(i => i.Id).FirstOrDefault();

                                            exist.Sede = emp.UBICACION;
                                            exist.CenterCost = emp.CENTRO_COSTO;
                                            exist.CodeBank = emp.ENTIDAD_FINANCIERA;
                                            exist.AccountBank = emp.CUENTA_ENTIDAD;
                                            exist.Cciaccount_bank = string.Empty;
                                            exist.CurrencyAccountBank = emp.RUBRO7;

                                            exist.CodeBankCts = emp.RUBRO10;
                                            exist.AccountCts = emp.RUBRO9;
                                            exist.CurrencyCts = emp.RUBRO8;
                                            exist.AfpCode = emp.RUBRO6;


                                            int? su_entsegvida = null;
                                            if (!string.IsNullOrEmpty(emp.U_ENTSEGVIDA))
                                            {
                                                su_entsegvida = int.Parse(emp.U_ENTSEGVIDA);
                                            }

                                            exist.su_entsegvida = su_entsegvida;

                                            int? su_planeps = null;
                                            if (!string.IsNullOrEmpty(emp.U_PLANEPS))
                                            {
                                                su_planeps = int.Parse(emp.U_PLANEPS);
                                            }

                                            exist.su_planeps = su_planeps;


                                            int? su_plansegpri = null;
                                            if (!string.IsNullOrEmpty(emp.U_PLANSEGPRI))
                                            {
                                                su_plansegpri = int.Parse(emp.U_PLANSEGPRI);
                                            }

                                            exist.su_plansegpri = su_plansegpri;


                                            int? su_sctrsalud = null;
                                            if (emp.U_SCTRSALUD != null)
                                            {
                                                su_sctrsalud = Convert.ToInt32(emp.U_SCTRSALUD);// int.Parse();

                                            }


                                            exist.su_sctrsalud = su_sctrsalud;


                                            int? su_entsegpract = null;
                                            if (!string.IsNullOrEmpty(emp.U_ENTSEGPRACT))
                                            {
                                                su_entsegpract = int.Parse(emp.U_ENTSEGPRACT);
                                            }


                                            exist.su_entsegpract = su_entsegpract;


                                            var inserbackupempleado = personRepository.RegisterBackupEmpleado(personaupdate.CodPerson).Result;


                                            personaupdate.IdUserUpdate = 1;
                                            personaupdate.DateUpdate = DateTime.Now;

                                            // buscar el cargo
                                            //_logger.LogInformation("Obteniendo el IDPOSITION");
                                            //int idPosition = Cargoslist.Where(i => i.IdEmpresa == comp.Id && i.CodExactus == emp.PUESTO).Select(i => i.Id).FirstOrDefault();
                                            //_logger.LogInformation("IDPOSITION: ", idPosition);
                                            //exist.IdPosition = idPosition;

                                            basePersonRepository.Update(personaupdate).Wait();
                                            exist.IdUserUpdate = 1;
                                            exist.DateUpdate = DateTime.Now;
                                            _logger.LogInformation("Se actualizará la situación del empleado {0} en COD {1}", emp.NOMBRE_PILA, emp.EMPLEADO);

                                            baseEmployeeRepository.Update(exist).Wait();

                                        }
                                        else
                                        {
                                            _logger.LogInformation("RegistrarPersonaCesada ==> {0}", personaupdate.CodPerson);
                                            /*Guardar información del empleado antes de cesarlo*/
                                            var inserbackupempleado = personRepository.RegistrarPersonaCesada(personaupdate.CodPerson).Result;
                                            _logger.LogInformation("UpdatePartial x.IdState ==> {0}", exist.IdState);
                                            baseEmployeeRepository.UpdatePartial(exist, x => x.IdState).Wait();
                                        }
                                        #endregion
                                    }
                                }

                                importedEmployeeList.ForEach(x =>
                                {

                                    int idPosition = Cargoslist.Where(i => i.IdEmpresa == x.IdCompany && i.CodExactus == x.CodeCharge).Select(i => i.Id).FirstOrDefault();

                                    if (idPosition == 0)
                                    {//SI
                                        idPosition = nIdCargoDefault;
                                    }
                                    x.IdPosition = idPosition;

                                    int idCtsOriginBank = bankList.Where(i => i.CodeBank == x.CtsOriginBank).Select(i => i.Id).FirstOrDefault();
                                    if (idCtsOriginBank > 0)
                                    {
                                        x.IdCtsOriginBank = idCtsOriginBank;
                                    }
                                    int idOriginBank = bankList.Where(i => i.CodeBank == x.OriginBankRemuneration).Select(i => i.Id).FirstOrDefault();
                                    if (idOriginBank > 0)
                                    {
                                        x.IdOriginBank = idOriginBank;
                                    }
                                    int idFinancialEntity = bankList.Where(i => i.CodeBank == x.FinancialEntity).Select(i => i.Id).FirstOrDefault();
                                    if (idFinancialEntity > 0)
                                    {
                                        x.IdFinancialEntity = idFinancialEntity;
                                    }

                                    var person = mapper.Map<PersonModel>(x);
                                    var employee = mapper.Map<EmployeeModel>(x);

                                    var employeeFile = mapper.Map<EmployeeFile>(x);
                                    employee.DateRegister = DateTime.Now;
                                    employee.DateUpdate = DateTime.Now;
                                    employee.IdUserRegister = 1;
                                    employee.IdUserUpdate = 1;
                                    employeeFile.DateRegister = DateTime.Now;
                                    employeeFile.DateUpdate = DateTime.Now;
                                    employeeFile.IdUserRegister = 1;
                                    employeeFile.IdUserUpdate = 1;

                                    person.Active = employee.IdState == 24 ? true : false;

                                    bool exist = basePersonRepository.Exist(x => x.CodPerson.Equals(person.CodPerson)).Result;
                                    if (!exist)
                                    {
                                        _logger.LogInformation(string.Format("Se registrará el empleado {0} para la empresa {1}.", $"{person.FirstName} {person.SecondName}, {person.LastName} {person.MotherLastName}", comp.Descripcion));
                                        try
                                        {
                                            _logger.LogInformation("Se registró en la tabla person");
                                            basePersonRepository.Add(person).Wait();
                                        }
                                        catch (Exception ex)
                                        {
                                            _logger.LogError("[Import - Insert Person]-[Error: " + ex.Message);
                                            _logger.LogError("[Import - Insert Person]-[Error: " + ex.StackTrace);
                                        }

                                        employee.IdPerson = person.Id;
                                        try
                                        {
                                            _logger.LogInformation("Se registró en la tabla employee");
                                            employee.ExistsInExactus = true;
                                            employee.IdCostcenter = 1;
                                            employee.IdPayroll = 1;
                                            baseEmployeeRepository.Add(employee).Wait();
                                        }
                                        catch (Exception ex)
                                        {
                                            _logger.LogError("[Import - Insert Employee]-[Error: " + ex.Message);
                                            _logger.LogError("[Import - Insert Employee]-[Error: " + ex.StackTrace);
                                        }


                                        employeeFile.IdEmployee = employee.Id;


                                        try
                                        {

                                            var inseraddres = personRepository.InsertAddressPersonByUbigeo(x.DIVISION_GEOGRAFICA2, x.DIRECCIONEMP, employee.IdPerson).Result;
                                        }
                                        catch (Exception ex)
                                        {
                                            _logger.LogError("[Import - Insert Employee]-[Error: " + ex.Message);
                                            _logger.LogError("[Import - Insert Employee]-[Error: " + ex.StackTrace);
                                        }

                                        try
                                        {

                                            var estudios = fullempleado.Academicos.Where(i => i.EMPLEADO == x.CodPerson).ToList();

                                            _logger.LogInformation($"Se encontraron {estudios.Count()}  estudios para {x.CodPerson} ");


                                            foreach (var est in estudios)
                                            {

                                                var ins_estudio = personRepository.InsertAcademicPerson(est.TIPO_ACADEMICO, est.INSTITUCION, est.CONCLUIDO,
                                                    est.FECHA_OBTENCION, est.FECHA_VENCIMIENTO, est.U_PROFESION, est.TITULO, x.CodPerson).Result;
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            _logger.LogError("[Import - Insert Employee]-[Error: " + ex.Message);
                                            _logger.LogError("[Import - Insert Employee]-[Error: " + ex.StackTrace);
                                        }

                                        try
                                        {

                                            List<string> lstTelefonos = new List<string>();
                                            if (!string.IsNullOrEmpty(x.TELEFONO1) && x.TELEFONO1 != " ")
                                            {
                                                lstTelefonos.Add(x.TELEFONO1);
                                            }
                                            if (!string.IsNullOrEmpty(x.TELEFONO2) && x.TELEFONO2 != " ")
                                            {
                                                lstTelefonos.Add(x.TELEFONO2);
                                            }
                                            if (!string.IsNullOrEmpty(x.TELEFONO3) && x.TELEFONO3 != " ")
                                            {
                                                lstTelefonos.Add(x.TELEFONO3);
                                            }

                                            if (lstTelefonos.Any())
                                            {

                                                foreach (var phonestring in lstTelefonos)
                                                {
                                                    Phone phoneModel = new Phone();
                                                    phoneModel.IdPerson = person.Id;
                                                    phoneModel.DateRegister = DateTime.Now;
                                                    phoneModel.UserRegister = 1;
                                                    phoneModel.phone = phonestring;
                                                    basePhoneRepository.Add(phoneModel).Wait();




                                                }
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            _logger.LogError("[Import - Insert Employee File]-[Error: " + ex.Message);
                                            _logger.LogError("[Import - Insert Employee File]-[Error: " + ex.StackTrace);
                                        }


                                        try
                                        {

                                            var experiencias = fullempleado.Experiencias.Where(i => i.EMPLEADO == x.CodPerson).ToList();

                                            foreach (var exp in experiencias)
                                            {
                                                var dtojob = new HumanManagement.Domain.Employee.Dto.InsertJobDto();

                                                dtojob.namejob = exp.EMPRESA;
                                                dtojob.nid_employee = employee.Id;
                                                dtojob.positionjob = exp.PUESTO;
                                                dtojob.sfunction = exp.FUNCIONES;
                                                dtojob.timejob = string.Empty;

                                                employeeRepository.InsertJob(dtojob).Wait();
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            _logger.LogError("[Import - Insert Employee File]-[Error: " + ex.Message);
                                            _logger.LogError("[Import - Insert Employee File]-[Error: " + ex.StackTrace);
                                        }


                                        try
                                        {

                                            var familialist = fullempleado.Familia.Where(i => i.EMPLEADO == x.CodPerson).ToList();


                                            foreach (var familia in familialist)
                                            {

                                                employeeRepository.InsertSon(new HumanManagement.Domain.Employee.Dto.InsertSonDto()
                                                {
                                                    ddateofbirth = familia.FECHA_NACIMIENTO == null ? DateTime.Now : familia.FECHA_NACIMIENTO.Value,
                                                    sfamilytype = familia.VINCULO,
                                                    sfullname = familia.NOMBRE,
                                                    slastname = familia.PATERNO,
                                                    smotherslastname = familia.MATERNO,
                                                    nid_employee = employee.Id

                                                }).Wait();
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            _logger.LogError("[Import - Insert Employee File]-[Error: " + ex.Message);
                                            _logger.LogError("[Import - Insert Employee File]-[Error: " + ex.StackTrace);
                                        }




                                        try
                                        {
                                            _logger.LogInformation("Se registró en la tabla employeefile");
                                            baseEmployeeFileRepository.Add(employeeFile).Wait();
                                        }
                                        catch (Exception ex)
                                        {
                                            _logger.LogError("[Import - Insert Employee File]-[Error: " + ex.Message);
                                            _logger.LogError("[Import - Insert Employee File]-[Error: " + ex.StackTrace);
                                        }



                                        User user = new User
                                        {
                                            UserName = person.CodPerson,
                                            Password = person.CodPerson,
                                            IdPerson = person.Id,
                                            Active = person.Active,
                                            State = 1
                                        };

                                        try
                                        {

                                            user.SetEncryptPassword(cryptography);

                                            _logger.LogInformation("Se registró en la tabla user");
                                            baseUserRepository.Add(user).Wait();

                                            ProfileUser profileUserModel = new ProfileUser();
                                            profileUserModel.IdProfile = 7;
                                            profileUserModel.IdUser = user.Id;


                                            baseProfileUserRepository.Add(profileUserModel).Wait();

                                        }
                                        catch (Exception ex)
                                        {
                                            _logger.LogError("[Import - Insert User]-[Error: " + ex.Message);
                                            _logger.LogError("[Import - Insert User]-[Error: " + ex.StackTrace);
                                        }

                                        UserMailDto userMailDto = new UserMailDto
                                        {
                                            UserName = user.UserName,
                                            Password = person.CodPerson,
                                            Email = person.Email,
                                            FullName = $"{person.FirstName} {person.SecondName}, {person.LastName} {person.MotherLastName}"
                                        };
                                        userMailDtoList.Add(userMailDto);
                                    }
                                    else
                                    {
                                        _logger.LogInformation("Ya existe una persona con DNI: " + person.CodPerson);
                                    }

                                });

                            }
                        }
                        catch (Exception ex)
                        {

                            _logger.LogError("[Import]-[Error: " + ex.Message);
                            _logger.LogError("[Import]-[Error: " + ex.StackTrace);
                        }

                    }
                    _request.nsate = 0;
                    var _result2 = personRepository.RegistrarProcesoServicio(_request).Result;
                    _logger.LogInformation("Metodo Import  - Fin");
                }
                catch (Exception ex)
                {
                    _logger.LogError(string.Format("ERROR: Proceso IniciarImport: Message: {0} ,StackTrace: {1}", ex.Message.ToString(), ex.StackTrace.ToString()));
                    _logger.LogError("ERROR Exception: Actualiza RegistrarProcesoServicio  - Inicio");
                    _request.nsate = 0;
                    var _result2 = personRepository.RegistrarProcesoServicio(_request).Result;
                    _logger.LogError("ERROR Exception: Actualiza RegistrarProcesoServicio  - Fin");
                }
            }
            else
            {
                _logger.LogInformation("Metodo IniciarImpor  - NO INGRESA");
            }
        }

        private void SendMail()
        {
            _logger.LogInformation("Metodo SendMail  - Inicio");
            userMailDtoList.ForEach(x =>
            {
                try
                {
                    var userRegistered = new UserRegistered(x);


                    MailSenderUser mailSenderUser = new MailSenderUser(htmlReader, userRegistered.UserMail);
                    var objMail = mailSenderUser.GetMail();
                    objMail.From = Configuration["AppSettings:FromMailNotification"].ToString();
                    objMail.FromName = Configuration["AppSettings:FromNameNotification"].ToString();

                    _logger.LogInformation(string.Format("Enviar correo a : {0}", objMail.To[0].ToString()));
                    mailRepository.SendMail(objMail);
                    _logger.LogInformation("Se envió el correo correctamente");
                }
                catch (Exception ex)
                {
                    _logger.LogError("[SendMail]-[Error: " + ex.Message);
                    _logger.LogError("[SendMail]-[Error: " + ex.StackTrace);
                }

            });
            _logger.LogInformation("Metodo SendMail  - Fin");
        }




        public void Export()
        {

            var CompaniesList = empresaRepository.GetAll().Result;

            var empleadosporexportar = employeeRepository.EmployeeForSendToExactus().Result;




            foreach (var emp in empleadosporexportar)
            {

                var person = basePersonRepository.Find(emp.IdPerson).Result;
                if (string.IsNullOrEmpty(person.CodPerson))
                {
                    continue;
                }

                ExactusEmpleadoInsertDto dtoinsert = new ExactusEmpleadoInsertDto();

                ExactusEALLEmpleado modelEmpleado = new ExactusEALLEmpleado();


                var cargo = baseCargoRepository.Find(emp.IdPosition).Result;
                var area = baseAreaRepository.Find(cargo.IdArea).Result;


                dtoinsert.Scheme = CompaniesList.Where(i => i.Id == emp.IdCompany).Select(i => i.Schema).FirstOrDefault();
                dtoinsert.EMPLEADO = emp.CodEmployee;
                dtoinsert.NOMBRE = person.FirstName + " " + person.SecondName ?? "" + " " + person.LastName + " " + person.MotherLastName;
                dtoinsert.SEXO = person.IdSex == 11 ? "F" : "M";
                dtoinsert.ESTADO_EMPLEADO = "ACTI";
                dtoinsert.ACTIVO = "S";
                dtoinsert.FECHA_INGRESO = emp.AdmissionDate;
                dtoinsert.DEPARTAMENTO = area.CodExactus == null ? "ND" : area.CodExactus;
                dtoinsert.PUESTO = cargo.CodExactus == null ? "ND" : cargo.CodExactus;
                dtoinsert.PLAZA = "ND";
                dtoinsert.NOMINA = "ND";
                dtoinsert.CENTRO_COSTO = "ND";
                dtoinsert.FECHA_NACIMIENTO = person.BirthDate == null ? DateTime.Now : person.BirthDate.Value;

                dtoinsert.DIRECCION_HAB = "DEPARTAMENTO: LIMA  PROVINCIA: LIMA  DISTRITO: SAN JUAN DE LURIGANCHO  DIRECCION: CALLE TUPAC YAURI 651 PISO 4 NRO: DPTO: INT: MZA: LOTE: URB. URBANIZACIÓN ZARATE";
                dtoinsert.UBICACION = "SEDEC";

                dtoinsert.PAIS = "PER";
                dtoinsert.ESTADO_CIVIL = "S";
                dtoinsert.VACS_PENDIENTES = 0;
                dtoinsert.VACS_ULT_CALCULO = DateTime.Now;
                dtoinsert.SALARIO_REFERENCIA = 0;
                dtoinsert.FORMA_PAGO = "T";
                dtoinsert.HORARIO = "H059";
                dtoinsert.FECHA_NO_PAGO = DateTime.Now;
                dtoinsert.TIPO_SALARIO_AUMEN = "G";
                dtoinsert.VACS_ADICIONALES = 0;
                dtoinsert.NoteExistsFlag = 0;
                dtoinsert.RecordDate = DateTime.Now;
                dtoinsert.RowPointer = Guid.NewGuid();
                dtoinsert.CreatedBy = "sa";
                dtoinsert.UpdatedBy = "sa";
                dtoinsert.CreateDate = DateTime.Now;



                try
                {

                    var ninsert = exactusEmpleadoRepository.InsertEmpleado(dtoinsert).Result;

                }
                catch (Exception ex)
                {

                    throw;
                }



            }

        }
    }
}