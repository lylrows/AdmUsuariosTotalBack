using AutoMapper;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Postulant.Disability.Dto;
using HumanManagement.Domain.Postulant.Disability.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SitePostulant.Application.Disability.IService;
using SitePostulant.Application.Response;

using System.IO;

using System.Threading.Tasks;

namespace SitePostulant.Application.Disability.Service
{
    public class DisabilityService: IDisabilityService
    {
        private readonly IBaseRepository<DisabilityModel> baseRepository;
        private readonly IMapper mapper;
        private readonly AppSettings _appSettings;
        public DisabilityService(IBaseRepository<DisabilityModel> baseRepository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
            this._appSettings = appSettings.Value;
        }

        public async Task<Result> Add(DisabilityDto dto, IFormFile file)
        {
            var folder = _appSettings.PathSaveFile;
            var filenamefolder = folder + "Certificates\\";
            dto.CertificateFileName = file.FileName;
            dto.CertificateFolder = filenamefolder;

            if (!Directory.Exists(filenamefolder))
            {
                Directory.CreateDirectory(filenamefolder); 
           }

            var entity = mapper.Map<DisabilityModel>(dto);
            await baseRepository.Add(entity);
            dto.Id = entity.Id;
            var newfilename = dto.Id + "-" + file.FileName;
            var pathDocument = filenamefolder + newfilename;
            using (var stream = new FileStream(pathDocument, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            dto.CertificateFileName = newfilename;
           
            var entityupd = mapper.Map<DisabilityModel>(dto);
            await baseRepository.Update(entityupd);

            return new Result
            {
                Data = dto,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }

        public async Task<Result> GetDisability(int IdPerson)
        {
            var entites = await baseRepository.FindPredicate(x => x.IdPerson == IdPerson && x.Active == true);
            var dto = new DisabilityDto();
            if (entites != null) {
                 dto = mapper.Map<DisabilityDto>(entites);
                if (dto.CertificateFolder != null)
                {
                    var file = dto.CertificateFolder + dto.CertificateFileName;
                    if (File.Exists(file))
                    {
                        var buffer = File.ReadAllBytes(file);
                        dto.CertificateFileBuffer = buffer;
                        dto.FileType = Path.GetExtension(dto.CertificateFileName);
                    }
                }
            }
          
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = dto
            };
        }

        public async Task<Result> Update(DisabilityDto dto)
        {
            var entityupd = mapper.Map<DisabilityModel>(dto);
            await baseRepository.Update(entityupd);

            return new Result
            {
                Data = dto,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
