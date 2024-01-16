using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Mof.Contracts;
using HumanManagement.Domain.Mof.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Mof.Queries
{
    public class GetMofDetailProfQuery : IRequest<Result>
    {
        public MofFilter filter { get; set; }
        public class GetMofDtailProfQueryHandler : IRequestHandler<GetMofDetailProfQuery, Result>
        {
            private readonly IMofRepository _mofRepository;
            public GetMofDtailProfQueryHandler(IMofRepository mofRepository)
            {
                this._mofRepository = mofRepository;
            }


            public async Task<Result> Handle(GetMofDetailProfQuery request, CancellationToken cancellationToken)
            {
                var resultPagination = await _mofRepository.GetMofDetailProfList(request.filter);

               List< ProficiencyByChargeDto> listareturn = new  List<ProficiencyByChargeDto>();
               
                string sDescription = string.Empty;

                var grupos = resultPagination.Select(i => new { IdCharge = i.IdCharge, NameCharge = i.NameCharge , IdCompany =i.IdCompany , CompanyName = i.CompanyName,ImageCompany=i.ImageCompany, NameArea=i.NameArea }).Distinct();

                foreach (var item in grupos)
                {
                    listareturn.Add(new ProficiencyByChargeDto()
                    {
                        IdCharge = item.IdCharge,
                        NameCharge = item.NameCharge,
                        IdCompany = item.IdCompany,
                        CompanyName = item.CompanyName,
                        IsSelected = false,
                        ImageCompany=item.ImageCompany,
                        NameArea=item.NameArea,
                        Proficiencies = new List<ProficiencyDetDto>()
                    }); 
                }

                foreach (var item in listareturn)
                {
                    foreach (var proficiency in resultPagination.Where(i=>i.IdCharge == item.IdCharge))
                    {
                        if (proficiency.IdProficiency != 0)
                        {
                            item.Proficiencies.Add(new ProficiencyDetDto()
                            {
                                Code = proficiency.IdProficiency,
                                Description = proficiency.NameProficiency,
                                Weight = proficiency.Weight,
                                Level = proficiency.Level,
                                IsConfigured=true
                            });
                        }
                        
                    }
                }


                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = listareturn
                };
            }
        }
    }

}
