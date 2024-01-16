using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.Domain.BaseDto;
using HumanManagement.Domain.BaseRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Proficiency.Queries
{
    public class GetProficiencyComboQuery : IRequest<Result>
    {

        public class GetProficiencyComboQueryHandler : IRequestHandler<GetProficiencyComboQuery, Result>
        {


            private readonly IBaseRepository<Domain.Proficiency.Models.Proficiency> baseRepository;
            private IMapper mapper;

            public GetProficiencyComboQueryHandler(IBaseRepository<Domain.Proficiency.Models.Proficiency> baseRepository, IMapper mapper)
            {
                this.baseRepository = baseRepository;
                this.mapper = mapper;

            }

            public async Task<Result> Handle(GetProficiencyComboQuery request, CancellationToken cancellationToken)
            {

                //List<DropDownListDto<int>> listreturn = new List<DropDownListDto<int>>();
                List<ListaProfiencie> listreturn = new List<ListaProfiencie>();

                var listEntity = await baseRepository.GetAll();

                //foreach (var item in listEntity.Where(i=>i.Active))
                //{
                //    DropDownListDto<int> dto = new DropDownListDto<int>();
                //    dto.Code = item.IdProficiency;
                //    dto.Description = item.NameProficiency;

                //    listreturn.Add(dto);
                //}
                foreach (var item in listEntity.Where(i => i.Active))
                {
                    ListaProfiencie _obj = new ListaProfiencie();
                    _obj.Code = item.IdProficiency;
                    _obj.Description = item.NameProficiency;
                    _obj.Required = item.Required;

                    listreturn.Add(_obj);
                }
                return new Result
                {
                    StateCode = 200,
                    Data = listreturn
                };
            }
            
            public class ListaProfiencie
            {
                public int Code { get; set; }
                public string Description { get; set; }
                public Boolean Required { get; set; }
            }
        }
    }
}
