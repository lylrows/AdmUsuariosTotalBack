using HumanManagement.Domain.Organigram.Contracts;
using HumanManagement.Domain.Organigram.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace HumanManagement.Application.Organigram.Queries
{
    public class GetOrganigramCargoQuery : IRequest<List<OrganigramDto>>
    {
        public int IdArea { get; set; }
        public int IdEmpresa { get; set; }
        public int IdCargo { get; set; }
        public class GetOrganigramCargoQueryHandler : IRequestHandler<GetOrganigramCargoQuery, List<OrganigramDto>>
        {
            private readonly IOrganigramRepository organigramRepository;
            private readonly ILogger<GetOrganigramCargoQueryHandler> _logger;

            public GetOrganigramCargoQueryHandler(IOrganigramRepository organigramRepository, ILogger<GetOrganigramCargoQueryHandler> _logger)
            {
                this.organigramRepository = organigramRepository;
                this._logger = _logger;
            }
            public async Task<List<OrganigramDto>> Handle(GetOrganigramCargoQuery request, CancellationToken cancellationToken)
            {
                Stopwatch timeMeasure = new Stopwatch();
                timeMeasure.Start();

                var list = new List<OrganigramDto>();

                var data = await organigramRepository.GetOrganigramDetail(request.IdEmpresa, request.IdArea, request.IdCargo);
                

                list.AddRange(
                    from item in data
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
                        Children = LoadChildren(item.Id, item.IdEmpresa, item.IdCargo,2, item.IdEmpleado).Result
                    });
                timeMeasure.Stop();
                _logger.LogInformation($"Tiempo Organigrama Detalle: {timeMeasure.Elapsed.TotalSeconds} s");
                return list;
            }

            public async Task<List<OrganigramDto>> LoadChildren(int idArea, int idEmpresa, int idCargo, int nivel, int idboss)
            {
                var list = new List<OrganigramDto>();

                var dataTotal = await organigramRepository.GetOrganigramByCargo(idEmpresa, idArea, idCargo);
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
                        Children = LoadChildren3(item.Id, item.IdEmpresa, item.IdCargo ,3, item.IdEmpleado,dataTotal).Result
                    });
                return list;
            }

            public async Task<List<OrganigramDto>> LoadChildren3(int idArea, int idEmpresa, int idCargo, int nivel, int idboss,List<AreaCargoDto> dataTotal)
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
                        Children = LoadChildren4(item.Id, item.IdEmpresa, item.IdCargo, 4, item.IdEmpleado,dataTotal).Result
                    });
                return list;
            }

            public async Task<List<OrganigramDto>> LoadChildren4(int idUpperArea, int idEmpresa, int idCargo , int nivel, int idboss, List<AreaCargoDto> dataTotal)
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
                        Children = LoadChildren5(item.Id, item.IdEmpresa, item.IdCargo, 5, item.IdEmpleado,dataTotal).Result
                    });
                return list;
            }

            public async Task<List<OrganigramDto>> LoadChildren5(int idUpperArea, int idEmpresa, int idCargo, int nivel, int idboss, List<AreaCargoDto> dataTotal)
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
                        Children = LoadChildren5(item.Id, item.IdEmpresa,idCargo, nivel++,item.IdEmpleado, dataTotal).Result
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
                }
                else
                {
                    return "../../../../../assets/images/avatars/avatar.jpg";
                }
            }
        }
    }
}
