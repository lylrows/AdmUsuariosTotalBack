using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.EvaluationPostulantInternal.Contracts;
using HumanManagement.Domain.EvaluationPostulantInternal.Dto;
using HumanManagement.Domain.EvaluationPostulantInternal.Models;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.EvaluationPostulantsInternal.Command
{
    public class GenerateInformeEvaluationCommand: IRequest<Result>
    {
        public int IdEvaluation { get; set; }
    }

    public class GenerateInformeEvaluationCommandHandle : IRequestHandler<GenerateInformeEvaluationCommand, Result>
    {
        private readonly IEvaluationFortalezasInternRepository evaluationFortalezasInternRepository;
        private readonly IEvaluationProficiencyInternRepository evaluationProficiencyInternRepository;
        private readonly IBaseRepository<EvaluationVacantInternal> evaluationbaseRepository;
        private readonly IEvaluationInternMultitestRepository evaluationInternMultitestRepository;
        private readonly AppSettings _appSettings;
        public GenerateInformeEvaluationCommandHandle(IEvaluationFortalezasInternRepository evaluationFortalezasInternRepository,
                                                      IEvaluationProficiencyInternRepository evaluationProficiencyInternRepository,
                                                      IBaseRepository<EvaluationVacantInternal> evaluationbaseRepository,
                                                      IOptions<AppSettings> appSettings,
                                                      IEvaluationInternMultitestRepository evaluationInternMultitestRepository)
        {
            this.evaluationFortalezasInternRepository = evaluationFortalezasInternRepository;
            this.evaluationProficiencyInternRepository = evaluationProficiencyInternRepository;
            this.evaluationbaseRepository = evaluationbaseRepository;
            this._appSettings = appSettings.Value;
            this.evaluationInternMultitestRepository = evaluationInternMultitestRepository;
        }
        public async Task<Result> Handle(GenerateInformeEvaluationCommand request, CancellationToken cancellationToken)
        {
            var dto = new InfoReportIntegradoInternDto();
            var dtocompetencias = await evaluationProficiencyInternRepository.GetEvaluationProficiencies(request.IdEvaluation, 1);
            var dtofortalezas = await evaluationFortalezasInternRepository.GetEvaluationFortalezasPostulants(request.IdEvaluation);
            var evaluation = await evaluationbaseRepository.FindPredicate(x => x.Id == request.IdEvaluation);
            var multitest = await evaluationInternMultitestRepository.GetEvaluationMultitestIntern(request.IdEvaluation);

            dto.InfoEvaluationMultitest = multitest;
            dto.InfoEvaluationProficiency = dtocompetencias;
            dto.InfoEvaluationRating = dtofortalezas;
            dto.PositionApplicant = evaluation.PositionRequired;

           /* var template = await File.ReadAllTextAsync(_appSettings.TemplateReporteEvaluationIntegralIntern);
            template = template.Replace("@CARGOPOSTULADO@", evaluation.PositionRequired);

            var rowProf = new List<string>();
            foreach (var item in dtocompetencias)
            {
                var row = "<tr><td style='border: solid; border - width:1px; text - align:center; padding: 5px;'>" + item.Proficiency + "</td> <td style='border: solid; border - width:1px; text - align:center; padding: 5px;'>" + item.Expectative + "</td><td style='border: solid; border - width:1px; text - align:center; padding: 5px;'>" + item.FullNamePostulant + "</td>  <td style='border: solid; border - width:1px; text - align:center; padding: 5px;'>" + item.LevelRRHH + "</td><td style='border: solid; border - width:1px; text - align:center; padding: 5px;'>" + item.LevelJefe + "</tr>";
                rowProf.Add(row);
            }

            template = template.Replace("@FILASCOMPETENCIAS@", string.Join("", rowProf));


            var rowrat = new List<string>();
            foreach (var item in dtofortalezas)
            {
                var row = "<tr><td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + item.FullNamePostulant + "</td><td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + item.SRatingrrhhstrengths + "</td> <td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + item.SRatingrrhhopportunities + "</td><td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + item.SRatingjefestrengths + "</td> <td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + item.SRatingjefeopportunities + "</td> </tr>";
                rowrat.Add(row);
            }
            template = template.Replace("@FILASFORTALEZAS@", string.Join("", rowrat));


            var listMulti = new
            {
                postulant = "Bertol Franco",
                levelaptverbal = 4,
                levelaptnumerica = 3,
                levelaptespacial = 4,
                levelaptabstracta = 5
            };

            var row3 = "<tr><td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + listMulti.postulant + "</td> <td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + listMulti.levelaptverbal + "</td> <td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + listMulti.levelaptnumerica + "</td> <td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + listMulti.levelaptespacial + "</td> <td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + listMulti.levelaptabstracta + "</td> </tr>";
            template = template.Replace("@FILASMULTITEST@", row3);

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
