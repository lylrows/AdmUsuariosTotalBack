using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;

using HumanManagement.Domain.HMExactus.Models;
using HumanManagement.Domain.InformationPostulant.Contracts;
using HumanManagement.Domain.Postulant.Person.Models;
using HumanManagement.Domain.Utils.Constracts;
using HumanManagement.Domain.WindowsService.Exactus.Contracts;
using HumanManagement.Domain.WindowsService.Exactus.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.InformationPostulant.Command
{
    public class SendInfoToExactusCommand : IRequest<Result>
    {
        public int nid_person { get; set; }
        public int nid_evaluation { get; set; }
    }

    public class SendInfoToExactusCommandHandle : IRequestHandler<SendInfoToExactusCommand, Result>
    {
        
        private readonly IBaseRepository<PersonModelPostulant> baseRepositoryPerson;
        private readonly IBaseRepository<HumanManagement.Domain.Empresa.Models.Empresa> baseRepositoryEmpresa;
        private readonly IBaseRepository<Domain.EvaluationPostulant.Models.Evaluation> baseEvaluation;
        private readonly IBaseRepository<HumanManagement.Domain.Job.Models.Job> baseRepositoryJob;
        private readonly IBaseRepository<HMExactusPayroll> baseRepositoryExPayroll;
        private readonly IExactusEmpleadoRepository exactusEmpleadoRepository;

        private readonly IBaseRepository<HumanManagement.Domain.Areas.Models.Areas> baseAreaRepository;
        private readonly IBaseRepository<HumanManagement.Domain.Cargo.Models.Cargo> baseCargoRepository;
        private readonly IUtilRepository utilRepository;
        private readonly IInformationFamilyRepository informationFamilyRepository;





        public SendInfoToExactusCommandHandle(IBaseRepository<PersonModelPostulant> baseRepositoryPerson,
            IBaseRepository<Domain.EvaluationPostulant.Models.Evaluation> baseEvaluation,
            IBaseRepository<HumanManagement.Domain.Empresa.Models.Empresa> baseRepositoryEmpresa,
            IBaseRepository<HumanManagement.Domain.Job.Models.Job> baseRepositoryJob,
            IBaseRepository<HMExactusPayroll> baseRepositoryExPayroll,
            IExactusEmpleadoRepository exactusEmpleadoRepository,
            IBaseRepository<HumanManagement.Domain.Areas.Models.Areas> baseAreaRepository,
            IBaseRepository<HumanManagement.Domain.Cargo.Models.Cargo> baseCargoRepository,
            IUtilRepository utilRepository,
            IInformationFamilyRepository informationFamilyRepository
            )
        {
            this.baseRepositoryPerson = baseRepositoryPerson;
            this.baseEvaluation = baseEvaluation;
            
            this.baseRepositoryEmpresa = baseRepositoryEmpresa;
            this.baseRepositoryJob = baseRepositoryJob;
            this.baseRepositoryExPayroll = baseRepositoryExPayroll;
            this.exactusEmpleadoRepository = exactusEmpleadoRepository;
            this.baseAreaRepository = baseAreaRepository;
            this.baseCargoRepository = baseCargoRepository;
            this.utilRepository = utilRepository;
            this.informationFamilyRepository = informationFamilyRepository;
        }
        public async Task<Result> Handle(SendInfoToExactusCommand request, CancellationToken cancellationToken)
        {
            var eval_model = await baseEvaluation.Find(request.nid_evaluation);

            var jobmodel = await baseRepositoryJob.Find(eval_model.IdJob);

            var modelperson = await baseRepositoryPerson.Find(request.nid_person);
            var empresamodel = await baseRepositoryEmpresa.Find(jobmodel.Id_Company);


            var payrolls = await baseRepositoryExPayroll.GetAll();

            var nomina = payrolls.Where(i => i.Code == modelperson.scodepayroll).FirstOrDefault();


            var cargoModel = await baseCargoRepository.Find(jobmodel.IdCharge);
            var areamodel = await baseAreaRepository.Find(cargoModel.IdArea);

            string scodcargoexactus = "ND";
            string scodareaexactus = "ND";

            if (!string.IsNullOrEmpty(cargoModel.CodExactus))
                scodcargoexactus = cargoModel.CodExactus;

            if (!string.IsNullOrEmpty(areamodel.CodExactus))
                scodareaexactus = areamodel.CodExactus;

            
            var _objSendExactus = await utilRepository.GetInfoToSendExatus(modelperson.Id);


            ExactusEmpleadoInsSpDto dtoinsert = new ExactusEmpleadoInsSpDto();

            dtoinsert.Schema = empresamodel.Schema;
            dtoinsert.PSCONJUNTO = empresamodel.Schema;
            dtoinsert.PSUSUARIO = "sa";
            dtoinsert.PSEMPLEADO = modelperson.DocumentNumber;
            dtoinsert.PSNOMBRE = modelperson.FirstName.ToUpper() + (modelperson.SecondName == null ? "" : (" " + modelperson.SecondName.ToUpper()));
            dtoinsert.PSPRIMERAPELLIDO = modelperson.LastName.ToUpper();
            dtoinsert.PSSEGUNDOAPELLIDO = modelperson.MotherLastName.ToUpper();
            dtoinsert.PSNOMBREPILA = string.Format("{0} {1} {2}", dtoinsert.PSNOMBRE,dtoinsert.PSPRIMERAPELLIDO,dtoinsert.PSSEGUNDOAPELLIDO);
            dtoinsert.PSSEXO = modelperson.IdSex == 11 ? "F" : (modelperson.IdSex == 12 ? "M" : "");
            dtoinsert.PSTIPOSANGRE = modelperson.BloodType;
            dtoinsert.PSIDENTIFICACION = modelperson.DocumentNumber;
            dtoinsert.PSPASAPORTE = modelperson.Passport;
            var dFechaSistema = DateTime.Now;
            dtoinsert.PDTFECHAINGRESO =  new DateTime(dFechaSistema.Year, dFechaSistema.Month, dFechaSistema.Day);
            dtoinsert.PSDEPARTAMENTO = _objSendExactus.scodcostcenter;
            dtoinsert.PSPUESTO = scodcargoexactus;
            dtoinsert.PSPLAZA = "ND";
            dtoinsert.PSNOMINA = modelperson.scodepayroll;
            dtoinsert.PSCENTROCOSTO = _objSendExactus.scodcostcenter;

            dtoinsert.PDTFECHANACIMIENTO = modelperson.BirthDate.Value;
            dtoinsert.PSUBICACION = _objSendExactus.scode_sede;
            dtoinsert.PSPAIS = "PER";

            string codestadocivil = "";

            switch (modelperson.IdCivilStatus)
            {
                case 16:
                    codestadocivil = "C";
                    break;
                case 17:
                    codestadocivil = "S";
                    break;
                case 18:
                    codestadocivil = "D";
                    break;
                case 2341:
                    codestadocivil = "V";
                    break;
                case 2342:
                    codestadocivil = "U";
                    break;
                default:
                    codestadocivil = "S";
                    break;
            }


            dtoinsert.PSESTADOCIVIL = codestadocivil;

            var familia = await informationFamilyRepository.GetInformationFamily(request.nid_person, request.nid_evaluation);


            dtoinsert.PNDEPENDIENTES = familia.Count;
            dtoinsert.PSASEGURADO = modelperson.Cuspp;
            dtoinsert.PSCLASESEGURO = "ND";
            dtoinsert.PSPERMISOCONDUCIR = "";
            dtoinsert.PSPERMISOSALUD = "";
            dtoinsert.PSNIT = modelperson.DocumentNumber;
            dtoinsert.PNSALARIOREFERENCIA = modelperson.salaryref ?? 0;
            dtoinsert.PSCUENTAENTIDAD = modelperson.sentityaccount;
            dtoinsert.PSFORMAPAGO = "T";
            dtoinsert.PSENTIDADFINANCIERA = modelperson.sfinancialentitycode;
            dtoinsert.PSHORARIO = modelperson.schedule;
            dtoinsert.PSTELEFONO1 = modelperson.CellPhone;
            dtoinsert.PSNOTASTEL1 = "";
            dtoinsert.PSTELEFONO2 = modelperson.AnotherPhone;
            dtoinsert.PSNOTASTEL2 = "";
            dtoinsert.PSTELEFONO3 = "";
            dtoinsert.PSNOTASTEL3 = "";
            dtoinsert.PSEMAIL = modelperson.Email;
            
            dtoinsert.PSRUBRO1 = modelperson.sorigincodbankrem;
            dtoinsert.PSRUBRO2 = modelperson.sorigincodbankcts;
            dtoinsert.PSRUBRO3 = "";
            dtoinsert.PSRUBRO4 = nomina.DaysHabsVaca.ToString();
            dtoinsert.PSRUBRO5 = "";
            dtoinsert.PSRUBRO6 = modelperson.scodeafp;
            dtoinsert.PSRUBRO7 = modelperson.ssalarycurrency.ToString();
            dtoinsert.PSRUBRO8 = modelperson.sctscurrency.ToString();
            dtoinsert.PSRUBRO9 = modelperson.sctsaccount;
            dtoinsert.PSRUBRO10 = modelperson.scodbankcts;
            dtoinsert.PSRUBRO11 = modelperson.sdoctypebcp.ToString();
            dtoinsert.PSRUBRO12 = modelperson.bintegralremuneration == true ? "1" : "0";
            dtoinsert.PSRUBRO13 = modelperson.bnodomiciliado == true ? "1" : "0";
            dtoinsert.PSRUBRO14 = modelperson.stypesalaryaccount;
            dtoinsert.PSRUBRO15 = modelperson.bfifthdiscount == true ? "1" : "0";
            dtoinsert.PSRUBRO16 = modelperson.bafpmixed == true ? "1" : "0";
            dtoinsert.PSRUBRO17 = "";
            dtoinsert.PSRUBRO18 = "";
            dtoinsert.PSRUBRO19 = "0";
            dtoinsert.PSRUBRO20 = "";
            dtoinsert.PSRUBRO21 = "";
            dtoinsert.PSRUBRO22 = "";
            dtoinsert.PSRUBRO23 = "";
            dtoinsert.PSRUBRO24 = "";
            dtoinsert.PSRUBRO25 = "";
            dtoinsert.PSNOTAS = "";
            dtoinsert.PNVACSADICIONALES = 0;
            dtoinsert.PSMENSAJEERROR = "";



            var sendexactus = await exactusEmpleadoRepository.InsertEmpleadoSP(dtoinsert);

            if (string.IsNullOrEmpty(sendexactus))
            {

                modelperson.bisonexactus = true;

                await baseRepositoryPerson.UpdatePartial(modelperson, x => x.bisonexactus);


                ExactusEmpleadoInsSpDirDto dtodireccion = new ExactusEmpleadoInsSpDirDto();
                dtodireccion.Schema = dtoinsert.Schema = empresamodel.Schema;
                dtodireccion.PSCONJUNTO = dtoinsert.Schema = empresamodel.Schema;
                dtodireccion.PSUSUARIO = "SA";
                dtodireccion.PSEMPLEADO = modelperson.DocumentNumber;


                var departamentos = await utilRepository.GetDepartament();
                var departamento = departamentos.Where(i => i.nid_department == modelperson.IdDepartmentLocation).FirstOrDefault();


                var provincias = await utilRepository.GetProvince(departamento.nid_department);
                var provincia = provincias.Where(i => i.nid_province == modelperson.IdProvinceLocation).FirstOrDefault();

                var distritos = await utilRepository.GetDistrict(provincia.nid_province);
                var distrito = distritos.Where(i => i.nid_district == modelperson.IdDistrictLocation).FirstOrDefault();


                dtodireccion.PSTIPODIRECCION = "H";
                dtodireccion.PSDIRECCION = "SUNAT";
                dtodireccion.PSCAMPO1 = departamento.sname;
                dtodireccion.PSCAMPO2 = provincia.sname;
                dtodireccion.PSCAMPO3 = distrito.sname;
                dtodireccion.PSCAMPO4 = modelperson.Address;
                dtodireccion.PSCAMPO5 = null;
                dtodireccion.PSCAMPO6 = null;
                dtodireccion.PSCAMPO7 = null;
                dtodireccion.PSCAMPO8 = null;
                dtodireccion.PSCAMPO9 = null;
                dtodireccion.PSCAMPO10 = null;
                dtodireccion.PSMENSAJEERROR = null;


                sendexactus = await exactusEmpleadoRepository.InsertDireccionSP(dtodireccion);


                return new Result
                {
                    Data = true,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
            else
            {
                return new Result
                {
                    MessageError = new List<string>() { sendexactus },
                    StateCode = Constants.StateCodeResult.ERROR_EXCEPTION
                };

            }


        }
    }
}
