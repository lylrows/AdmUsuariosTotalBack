using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.EvaluationPostulant.Contracts;
using HumanManagement.Domain.EvaluationPostulant.Dto;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EvaluationModel = HumanManagement.Domain.EvaluationPostulant.Models.Evaluation;

namespace HumanManagement.Application.EvaluationPostulants.Command
{
    public class GenerateInformeEvaluationExternCommand: IRequest<Result>
    {
        public int IdEvaluation { get; set; }
    }

    public class GenerateInformeEvaluationExternCommandHandle : IRequestHandler<GenerateInformeEvaluationExternCommand, Result>
    {
        private readonly IBaseRepository<EvaluationModel> evaluationbaseRepository;
        private readonly IEvaluationProficiencyRepository evaluationProficiencyRepository;
        private readonly IEvaluationRatingRepository evaluationRatingRepository;
        private readonly AppSettings _appSettings;
        private readonly IEvaluationMultitestRepository evaluationMultitestRepository;
        public GenerateInformeEvaluationExternCommandHandle(IBaseRepository<EvaluationModel> evaluationbaseRepository,
                                                      IEvaluationProficiencyRepository evaluationProficiencyRepository,
                                                      IEvaluationRatingRepository evaluationRatingRepository,
                                                      IOptions<AppSettings> appSettings,
                                                      IEvaluationMultitestRepository evaluationMultitestRepository)
        {
            this.evaluationbaseRepository = evaluationbaseRepository;
            this.evaluationProficiencyRepository = evaluationProficiencyRepository;
            this.evaluationRatingRepository = evaluationRatingRepository;
            this._appSettings = appSettings.Value;
            this.evaluationMultitestRepository = evaluationMultitestRepository;
        }
        public async Task<Result> Handle(GenerateInformeEvaluationExternCommand request, CancellationToken cancellationToken)
        {
            var dto = new InfoReportIntegradoDto();

            var evaluation = await evaluationbaseRepository.FindPredicate(x => x.Id == request.IdEvaluation);
            var proficiencies = await evaluationProficiencyRepository.GetEvaluationProficiencies(request.IdEvaluation);
            var rating = await evaluationRatingRepository.GetEvaluationRatingPostulants(request.IdEvaluation);
            var multitest = await evaluationMultitestRepository.GetEvaluationMultitest(request.IdEvaluation);

            dto.PositionApplicant = evaluation.PositionRequired;
            dto.InfoEvaluationProficiency = proficiencies;
            dto.InfoEvaluationRating = rating;
            dto.InfoEvaluationMultitest = multitest;

          /*  var template = await File.ReadAllTextAsync(_appSettings.TemplateReporteEvaluationIntegralExtern);
            template = template.Replace("@CARGOPOSTULADO@", evaluation.PositionRequired);*/

            /* var rowProf = new List<string>();
             foreach (var item in proficiencies)
             {
                 var row = "<tr> <td style='border: solid; border - width:1px; text - align:center; padding: 5px;'>" + item.Proficiency + "</td> <td style='border: solid; border - width:1px; text - align:center; padding: 5px;'>" + item.Expectative + "</td><td style='border: solid; border - width:1px; text - align:center; padding: 5px;'>" + item.FullNamePostulant + "</td> <td style='border: solid; border - width:1px; text - align:center; padding: 5px;'>" + item.LevelRRHH + "</td> <td style='border: solid; border - width:1px; text - align:center; padding: 5px;'>" + item.LevelClient + "</td> <td style='border: solid; border - width:1px; text - align:center; padding: 5px;'>" + item.LevelJefe + "</tr>";
                 rowProf.Add(row);
             }

             template = template.Replace("@FILASCOMPETENCIAS@", string.Join("", rowProf));

             var rowrat = new List<string>();
             foreach (var item in rating)
             {
                 var row = "<tr><td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + item.FullNamePostulant + "</td> <td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + item.SRatingrrhhstrengths + "</td> <td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + item.SRatingrrhhopportunities + "</td> <td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + item.SRatingclientstrengths + "</td> <td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + item.SRatingclientopportunities + "</td> <td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + item.SRatingjefestrengths + "</td> <td style='border:solid; border-width:1px; text-align:center;padding:5px;'>" + item.SRatingjefeopportunities + "</td> </tr>";
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
