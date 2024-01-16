using AutoMapper;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.MasterTable.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HumanManagement.Application.MasterTable.IServices;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HumanManagement.Application.MasterTable.Services
{
    public class MasterTableService: IMasterTableService
    {
        private readonly IBaseRepository<Domain.MasterTable.Models.MasterTable> baseRepository;
        private IMapper mapper;
        public MasterTableService(IBaseRepository<Domain.MasterTable.Models.MasterTable> baseRepository,
                            IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        
    }
}
