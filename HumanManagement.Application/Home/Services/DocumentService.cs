using AutoMapper;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Home.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HumanManagement.Application.Home.IServices;

namespace HumanManagement.Application.Home.Services
{
    public class DocumentService: IDocumentService
    {
        private readonly IBaseRepository<Domain.Home.Models.Document> baseRepository;
        private IMapper mapper;
        public DocumentService(IBaseRepository<Domain.Home.Models.Document> baseRepository,
                            IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task Add(DocumentDto dto)
        {
            dto.DateRegister = DateTime.Now;
            var document = mapper.Map<Domain.Home.Models.Document>(dto);
            await baseRepository.Add(document);
        }
        public Task<DocumentDto> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(DocumentDto dto)
        {
            dto.DateUpdate = DateTime.Now;
            var document = mapper.Map<Domain.Home.Models.Document>(dto);
            await baseRepository.Update(document);
        }
        public async Task Delete(int id)
        {
            var entity = await baseRepository.Find(id);
            if (entity != null)
            {
                await baseRepository.Delete(entity);
            }
        }
        public async Task<DocumentDto> GetById(int id)
        {
            var result = await baseRepository.Find(id);
            var authorDTO = mapper.Map<DocumentDto>(result);
            return authorDTO;
        }
    }
}
