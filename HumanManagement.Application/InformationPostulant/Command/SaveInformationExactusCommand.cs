using System;
using System.Threading;
using System.Threading.Tasks;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Postulant.Person.Contracts;
using HumanManagement.Domain.Postulant.Person.Dto;
using HumanManagement.Domain.Postulant.Person.Models;
using MediatR;

namespace HumanManagement.Application.InformationPostulant.Command
{

    public class SaveInformationExactusCommand : IRequest<Result>
    {
        public PersonExactusDto dto { get; set; }
    }

    public class SaveInformationExactusCommandHandle : IRequestHandler<SaveInformationExactusCommand, Result>
    {
        private readonly IPersonRepository personRepository;
        private readonly IBaseRepository<PersonModelPostulant> baseRepositoryPerson;
        public SaveInformationExactusCommandHandle(IPersonRepository personRepository, IBaseRepository<PersonModelPostulant> baseRepositoryPerson)
        {
            this.personRepository = personRepository;
            this.baseRepositoryPerson = baseRepositoryPerson;
        }
        public async Task<Result> Handle(SaveInformationExactusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var modelperson = await baseRepositoryPerson.Find(request.dto.nid_person);

                
                modelperson.scodepayroll = request.dto.scodepayroll;
                modelperson.scodelocation = request.dto.scodelocation;
                modelperson.salaryref = request.dto.salaryref;
                modelperson.schedule = request.dto.schedule;
                modelperson.sfinancialentitycode = request.dto.sfinancialentitycode;
                modelperson.sentityaccount = request.dto.sentityaccount;
                modelperson.sorigincodbankrem = request.dto.sorigincodbankrem;
                modelperson.sorigincodbankcts = request.dto.sorigincodbankcts;
                modelperson.scodeafp = request.dto.scodeafp;
                modelperson.ssalarycurrency = int.Parse(request.dto.ssalarycurrency);
                modelperson.sctscurrency = int.Parse(request.dto.sctscurrency);
                modelperson.scodbankcts = request.dto.scodbankcts;
                modelperson.sctsaccount = request.dto.sctsaccount;
                modelperson.sdoctypebcp = int.Parse(request.dto.sdoctypebcp);
                modelperson.bintegralremuneration = request.dto.bintegralremuneration;
                modelperson.bnodomiciliado = request.dto.bnodomiciliado;
                modelperson.stypesalaryaccount = request.dto.stypesalaryaccount;
                modelperson.bfifthdiscount = request.dto.bfifthdiscount;
                modelperson.bafpmixed = request.dto.bafpmixed;
                modelperson.BloodType = request.dto.sbloodtype;
                if (String.IsNullOrEmpty(request.dto.dincomecountry)) modelperson.IncomeCountry = null;
                else modelperson.IncomeCountry = Convert.ToDateTime(request.dto.dincomecountry);
                modelperson.Cuspp = request.dto.scuspp;
                if (String.IsNullOrEmpty(request.dto.dendposition)) modelperson.EndPosition = null;
                else modelperson.EndPosition = Convert.ToDateTime(request.dto.dendposition);
                if (String.IsNullOrEmpty(request.dto.dstartposition)) modelperson.StartPosition = null;
                else modelperson.StartPosition = Convert.ToDateTime(request.dto.dstartposition);
                
                await baseRepositoryPerson.UpdatePartial(modelperson, x => x.scodepayroll
                                                                      , x => x.scodelocation
                                                                      , x => x.salaryref
                                                                      , x => x.schedule
                                                                      , x => x.sfinancialentitycode
                                                                      , x => x.sentityaccount
                                                                      , x => x.sorigincodbankrem
                                                                      , x => x.sorigincodbankcts
                                                                      , x => x.scodeafp
                                                                      , x => x.ssalarycurrency
                                                                      , x => x.sctscurrency
                                                                      , x => x.scodbankcts
                                                                      , x => x.sctsaccount
                                                                      , x => x.sdoctypebcp
                                                                      , x => x.bintegralremuneration
                                                                      , x => x.bnodomiciliado
                                                                      , x => x.stypesalaryaccount
                                                                      , x => x.bfifthdiscount
                                                                      , x => x.bafpmixed
                                                                      , x => x.BloodType
                                                                      , x => x.IncomeCountry
                                                                      , x => x.Cuspp
                                                                      , x => x.EndPosition
                                                                      , x => x.StartPosition);

            }
            catch (Exception ex)
            {

                throw;
            }

            return new Result
            {
                Data = true,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
