using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Employee.Models;
using HumanManagement.Domain.EvaluationPostulantInternal.Contracts;
using HumanManagement.Domain.EvaluationPostulantInternal.Dto;
using HumanManagement.Domain.EvaluationPostulantInternal.Models;
using HumanManagement.Domain.Person.Contracts;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EvaluationPostulantsInternalModel = HumanManagement.Domain.EvaluationPostulantInternal.Models.EvaluationPostulantsInternal;

namespace HumanManagement.Application.EvaluationPostulantsInternal.Command
{
    public class GenerateEvaluationReportInternCommand: IRequest<Result>
    {
        public int IdEvaluationPostulant { get; set; }
    }

    public class GenerateEvaluationReportInternCommandHandle : IRequestHandler<GenerateEvaluationReportInternCommand, Result>
    {
        private readonly IBaseRepository<Address> addressbaseRepository;
        private readonly IBaseRepository<EvaluationPostulantsInternalModel> evalpostulantbaseRepository;
        private readonly IBaseRepository<EvaluationVacantInternal> evaluationbaseRepository;
        private readonly IPersonRepository personRepository;
        private readonly IEvaluationProficiencyInternRepository evaluationProficiencyRepository;
        private readonly IEvaluationFortalezasInternRepository evaluationRatingRepository;
        private readonly AppSettings _appSettings;
        private readonly IBaseRepository<EvaluationMultitestIntern> multitestbaseRepository;
        private readonly IMapper mapper;

        public GenerateEvaluationReportInternCommandHandle(IBaseRepository<EvaluationPostulantsInternalModel> evalpostulantbaseRepository,
                                                              IBaseRepository<EvaluationVacantInternal> evaluationbaseRepository,
                                                              IPersonRepository personRepository,
                                                              IEvaluationProficiencyInternRepository evaluationProficiencyRepository,
                                                              IEvaluationFortalezasInternRepository evaluationRatingRepository,
                                                              IBaseRepository<Address> addressbaseRepository,
                                                              IOptions<AppSettings> appSettings,
                                                              IBaseRepository<EvaluationMultitestIntern> multitestbaseRepository,
                                                              IMapper mapper
                                                              )
        {
            this.evalpostulantbaseRepository = evalpostulantbaseRepository;
            this.evaluationbaseRepository = evaluationbaseRepository;
            this.personRepository = personRepository;
            this.evaluationProficiencyRepository = evaluationProficiencyRepository;
            this.evaluationRatingRepository = evaluationRatingRepository;
            this.addressbaseRepository = addressbaseRepository;
            this._appSettings = appSettings.Value;
            this.multitestbaseRepository = multitestbaseRepository;
            this.mapper = mapper;
        }
        public async Task<Result> Handle(GenerateEvaluationReportInternCommand request, CancellationToken cancellationToken)
        {
            var dto = new InfoReportIndividualInternDto();
            var evaluationpostulant = await evalpostulantbaseRepository.FindPredicate(x => x.Id == request.IdEvaluationPostulant);
            var evaluation = await evaluationbaseRepository.FindPredicate(x => x.Id == evaluationpostulant.IdEvaluation);
            var person = await personRepository.GetPerson(evaluationpostulant.IdPostulant);
            var address = await addressbaseRepository.FindPredicate(x => x.IdPerson == person.nid_person);
            var testproficiency = await evaluationProficiencyRepository.GetEvaluationProficiencies(evaluationpostulant.IdEvaluation, person.nid_person, 1);
            var testproficiencyActually = await evaluationProficiencyRepository.GetEvaluationProficiencies(evaluationpostulant.IdEvaluation, person.nid_person, 2);
            var testrating = await evaluationRatingRepository.GetEvaluationFortalezasPostulants(evaluationpostulant.IdEvaluation, person.nid_person);
            var multitest = await multitestbaseRepository.FindPredicate(x => x.IdPostulant == evaluationpostulant.IdPostulant);

            var multitestDto = mapper.Map<EvaluationMultitestInternDto>(multitest);
            if (person.dbirthdate != null)
            {

                var datebith = (DateTime)person.dbirthdate;
                if (datebith > DateTime.Now)
                {
                }
                else
                {
                    int edad = DateTime.Today.AddTicks(-datebith.Ticks).Year - 1;
                    person.sage = edad.ToString();
                }
            }
            person.saddress = address?.AddressDescription;

            dto.InfoEvaluationProficiencyFuture = testproficiency;
            dto.InfoEvaluationProficiencyActually = testproficiencyActually;
            dto.InfoEvaluationRating = testrating;
            dto.InfoPerson = person;
            dto.PositionApplicant = evaluation.PositionRequired;
            dto.InfoEvaluationMultitest = multitestDto;

           /* template = template.Replace("@DIRECCION@", address?.AddressDescription);
            template = template.Replace("@ESTADOCIVIL@", person.scivil_status);

            var rowProf = new List<string>();
            foreach (var item in testproficiency)
            {
                var row = "<tr> <td style='border: solid; border - width:1px; text - align:center; padding: 5px;'>" + item.Proficiency + "</td> <td style='border: solid; border - width:1px; text - align:center; padding: 5px;'>" + item.Expectative + "</td> <td style='border: solid; border - width:1px; text - align:center; padding: 5px;'>" + item.LevelRRHH + "</td><td style='border: solid; border - width:1px; text - align:center; padding: 5px;'>" + item.LevelJefe + "</tr>";
                rowProf.Add(row);
            }

            template = template.Replace("@FILASCOMPETENCIASFURURAS@", string.Join("", rowProf));

            var rowProf2 = new List<string>();
            foreach (var item in testproficiencyActually)
            {
                var row = "<tr> <td style='border: solid; border - width:1px; text - align:center; padding: 5px;'>" + item.Proficiency + "</td> <td style='border: solid; border - width:1px; text - align:center; padding: 5px;'>" + item.Expectative + "</td> <td style='border: solid; border - width:1px; text - align:center; padding: 5px;'>" + item.LevelRRHH + "</td><td style='border: solid; border - width:1px; text - align:center; padding: 5px;'>" + item.LevelJefe + "</tr>";
                rowProf2.Add(row);
            }

            template = template.Replace("@FILASCOMPETENCIASACTUALES@", string.Join("", rowProf));

            var listMulti = new
            {
                levelaptverbal = 4,
                levelaptnumerica = 3,
                levelaptespacial = 4,
                levelaptabstracta = 5
            };

            var row3 = "<tr> <td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + listMulti.levelaptverbal + "</td> <td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + listMulti.levelaptnumerica + "</td> <td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + listMulti.levelaptespacial + "</td> <td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + listMulti.levelaptabstracta + "</td> </tr>";
            template = template.Replace("@FILASMULTITEST@", row3);

            var rowrat = new List<string>();
            foreach (var item in testrating)
            {
                var row = "<tr> <td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + item.SRatingrrhhstrengths + "</td> <td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + item.SRatingrrhhopportunities + "</td><td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + item.SRatingjefestrengths + "</td> <td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + item.SRatingjefeopportunities + "</td> </tr>";
                rowrat.Add(row);
            }
            template = template.Replace("@FILASFORTALEZAS@", string.Join("", rowrat));

            var pdf = PdfSharpConvert(template, "");*/

            return new Result
            {
                Data = dto,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }

        static Byte[] PdfSharpConvert(string html, string path)
        {
            Byte[] res = null;
            using (MemoryStream ms = new MemoryStream())
            {
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                pdf.Save(ms);
                res = ms.ToArray();
            }
            return res;

            /*  using (var stream = new FileStream(path, FileMode.Create))
              {
                  var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                  pdf.Save(stream);
              }
              return res;*/
        }
    }
}
