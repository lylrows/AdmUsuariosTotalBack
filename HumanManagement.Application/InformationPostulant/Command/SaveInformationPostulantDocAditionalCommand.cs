using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.InformationPostulant.Dto;
using HumanManagement.Domain.Utils.Constracts;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.InformationPostulant.Command
{
    public class SaveInformationPostulantDocAditionalCommand : IRequest<Result>
    {
        public List<DocumentoAdicional> dtos { get; set; }
    }
    public class SaveInformationPostulantDocAditionalCommandHandle : IRequestHandler<SaveInformationPostulantDocAditionalCommand, Result>
    {
        private readonly IUtilRepository _utilRepository;
        private readonly AppSettings _appSettings;
        public SaveInformationPostulantDocAditionalCommandHandle(IUtilRepository utilRepository,
                                                     IOptions<AppSettings> appSettings)
        {
            this._utilRepository = utilRepository;
            _appSettings = appSettings.Value;
        }

        public async Task<Result> Handle(SaveInformationPostulantDocAditionalCommand request, CancellationToken cancellationToken)
        {
            
            foreach (var _document in request.dtos)
            {
                if (!String.IsNullOrEmpty(_document.FileBase64))
                {
                    string _base64 = Functions.CleanBase64File(_document.FileBase64);
                    var _file = Convert.FromBase64String(_base64);
                    var _nombreFileAleatorio = string.Format("{0}.{1}", Guid.NewGuid(), Path.GetExtension(_document.NombreFile)); ;
                    var pathComplete = string.Format("{0}{1}", _appSettings.PathDocumentosPostulant, _nombreFileAleatorio);
                    File.WriteAllBytes(pathComplete, _file);
                    _document.PathFile = pathComplete;
                }
                var _result = await _utilRepository.SaveDocumentAditional(_document);
            }
            return new Result
            {
                Data = true,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
