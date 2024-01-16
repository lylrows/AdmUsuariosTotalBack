using HumanManagement.Domain.Organigram.Contracts;
using HumanManagement.Domain.Organigram.Dto;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Organigram.Queries
{
    public class GetOrganigramQuery : IRequest<List<OrganigramDto>>
    {
        public int IdEmpresa { get; set; }
        public class GetOrganigramQueryHandler : IRequestHandler<GetOrganigramQuery, List<OrganigramDto>>
        {
            private readonly IOrganigramRepository organigramRepository;
            private readonly ILogger<GetOrganigramQueryHandler> _logger;
            public GetOrganigramQueryHandler(IOrganigramRepository organigramRepository, ILogger<GetOrganigramQueryHandler> _logger)
            {
                this.organigramRepository = organigramRepository;
                this._logger = _logger;
            }
            public async Task<List<OrganigramDto>> Handle(GetOrganigramQuery request, CancellationToken cancellationToken)
            {
                Stopwatch timeMeasure = new Stopwatch();
                timeMeasure.Start();
                var list = new List<OrganigramDto>();

                var data = await organigramRepository.GetOrganigram(request.IdEmpresa);

                var dataUpper = data.Where(p => p.IdAreaUpper == 0).ToList();

                list.AddRange(
                    from item in dataUpper
                    select new OrganigramDto
                    {
                        Id = item.Id,
                        IdEmpresa = item.IdEmpresa,
                        IdCargo = item.IdCargo,
                        Label = item.Area,
                        Expanded = true,
                        StyleClass = "department-cfo",
                        Type = "department",
                        Data = new DataPerson
                        {
                            Avatar = GetAvatar(item.Avatar),
                            Cargo = item.Cargo,
                            Name = item.Empleado
                        },
                        Children = LoadChildren(item.Id, item.IdEmpresa, item.IdCargo ,2,item.IdEmpleado).Result
                    });
                timeMeasure.Stop();
                _logger.LogInformation($"Tiempo Organigrama Principal: {timeMeasure.Elapsed.TotalSeconds} s");
                return list;
            }

            public async Task<List<OrganigramDto>> LoadChildren(int idUpperArea, int idEmpresa, int idCargo,int nivel,int idboss)
            {
                var list = new List<OrganigramDto>();

                var dataTotal = await organigramRepository.GetOrganigramByCargo(idEmpresa, idUpperArea, idCargo);
                

                var data = dataTotal.Where(i => i.IdBossReal == idboss ).ToList();

                list.AddRange(
                    from item in data
                    select new OrganigramDto
                    {
                        Id = item.Id,
                        IdEmpresa = item.IdEmpresa,
                        IdCargo = item.IdCargo,
                        Label = item.Area,
                        Expanded = true,
                        StyleClass = GetClassOrganigram(nivel),
                        Type = "department",
                        Data = new DataPerson
                        {
                            Avatar = GetAvatar(item.Avatar),
                            Cargo = item.Cargo,
                            Name = item.Empleado
                        },
                        
                    });
                return list;
            }

            public async Task<List<OrganigramDto>> LoadChildren3(int idUpperArea, int idEmpresa, int idCargo, int nivel,int idboss,List<AreaCargoDto> dataTotal)
            {
                var list = new List<OrganigramDto>();

                

                var data = dataTotal.Where(i => i.IdBossReal == idboss ).ToList();

                list.AddRange(
                    from item in data
                    select new OrganigramDto
                    {
                        Id = item.Id,
                        IdEmpresa = item.IdEmpresa,
                        IdCargo = item.IdCargo,
                        Label = item.Area,
                        Expanded = true,
                        StyleClass = GetClassOrganigram(nivel),
                        Type = "department",
                        Data = new DataPerson
                        {
                            Avatar = GetAvatar(item.Avatar),
                            Cargo = item.Cargo,
                            Name = item.Empleado
                        },
                        Children = LoadChildren4(item.Id, item.IdEmpresa, item.IdCargo, 4,item.IdEmpleado,dataTotal).Result
                    });
                return list;
            }

            public async Task<List<OrganigramDto>> LoadChildren4(int idUpperArea, int idEmpresa, int idCargo, int nivel,int idboss, List<AreaCargoDto> dataTotal)
            {
                var list = new List<OrganigramDto>();

                

                var data = dataTotal.Where(i => i.IdBossReal == idboss ).ToList();

                list.AddRange(
                    from item in data
                    select new OrganigramDto
                    {
                        Id = item.Id,
                        IdEmpresa = item.IdEmpresa,
                        IdCargo = item.IdCargo,
                        Label = item.Area,
                        Expanded = true,
                        StyleClass = GetClassOrganigram(nivel),
                        Type = "department",
                        Data = new DataPerson
                        {
                            Avatar = GetAvatar(item.Avatar),
                            Cargo = item.Cargo,
                            Name = item.Empleado
                        },
                        Children = LoadChildren5(item.Id, item.IdEmpresa, item.IdCargo, 5, item.IdEmpleado, dataTotal).Result
                    });
                return list;
            }

            public async Task<List<OrganigramDto>> LoadChildren5(int idUpperArea, int idEmpresa, int idCargo , int nivel,int idboss,  List<AreaCargoDto> dataTotal)
            {
                var list = new List<OrganigramDto>();

                

                var data = dataTotal.Where(i => i.IdBossReal == idboss ).ToList();

                list.AddRange(
                    from item in data
                    select new OrganigramDto
                    {
                        Id = item.Id,
                        IdEmpresa = item.IdEmpresa,
                        IdCargo = item.IdCargo,
                        Label = item.Area,
                        Expanded = true,
                        StyleClass = GetClassOrganigram(nivel),
                        Type = "department",
                        Data = new DataPerson
                        {
                            Avatar = GetAvatar(item.Avatar),
                            Cargo = item.Cargo,
                            Name = item.Empleado
                        },
                        Children = null
                    });
                return list;
            }

            public string GetClassOrganigram(int nivel)
            {
                string clase = "";
                switch (nivel)
                {
                    case 2:
                        clase = "department-cto";
                        break;
                    case 3:
                        clase = "department-coo";
                        break;
                    case 4:
                        clase = "department-4";
                        break;
                    case 5:
                        clase = "department-5";
                        break;
                    default:
                        break;
                }

                return clase;
            }

            public string GetAvatar(string url)
            {
                if (url != "" && url != null)
                {
                    if (url.Substring(0, 4).Equals("http"))
                    {
                        return url;
                    }
                    else
                    {
                        var fileAvatar = url;
                        var base64ImageRepresentation = "";
                        if (File.Exists(fileAvatar))
                        {
                            var imageArray = File.ReadAllBytes(fileAvatar);
                            base64ImageRepresentation = $"data:image/jpeg;base64,{Convert.ToBase64String(imageArray)}";
                        }

                        return base64ImageRepresentation;
                    }
                } else
                {
                    return "../../../../../assets/images/avatars/avatar.jpg";
                }
            }
        }
    }
}
