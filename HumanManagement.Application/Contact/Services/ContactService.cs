using AutoMapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using HumanManagement.Application.Contact.IServices;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contact;
using HumanManagement.Domain.Contact.Dto;
using HumanManagement.Domain.Postulant.Security.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Application.Contact.Services
{
    public class ContactService : IContactService
    {

        private readonly IBaseRepository<Domain.Contact.Models.Contact> baseRepository;
        private IMapper mapper;
        public ContactService(IBaseRepository<Domain.Contact.Models.Contact> baseRepository,
                   IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }

        public async Task Add(ContactDto dto)
        {
            var newcontact = mapper.Map<Domain.Contact.Models.Contact>(dto);
            newcontact.DateRegister = DateTime.Now;
            newcontact.DateUpdate = DateTime.Now;
            

            await baseRepository.Add(newcontact);
        }

        public async Task Delete(int id)
        {
            var entity = await baseRepository.Find(id);
            if (entity != null)
            {

                entity.Active = false;
                await baseRepository.Update(entity);
            }
        }

        public async Task<IEnumerable<ContactDto>> GetAll()
        {
            var result = await baseRepository.GetAll();
            var authorDTOs = mapper.Map<List<ContactDto>>(result);
            return authorDTOs;
        }

        public Task<ContactDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public  async Task Update(ContactDto dto)
        {
            var contactupdate = mapper.Map<Domain.Contact.Models.Contact>(dto);
            contactupdate.DateRegister = DateTime.Now;
            contactupdate.DateUpdate = DateTime.Now;
            await baseRepository.Update(contactupdate);
        }
    }
}
