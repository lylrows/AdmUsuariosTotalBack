using HumanManagement.Domain.Empresa.Contracts;
using HumanManagement.Domain.Events;
using HumanManagement.Domain.WindowsService.ServerUs.Contracts;
using HumanManagement.Domain.WindowsService.ServerUs.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.StaffRequest.Events
{
   
    public class StaffRequestApprovedHandlerSend : IEventHandling<StaffRequestApproved>
    {
        private readonly IEmpresaRepository empresaRepository;
        private readonly ISUMovAsistenciaCabRepository movAsistenciaCabRepository;
        private readonly ISUMovAsistenciaDetRepository movAsistenciaDetRepository;

        public StaffRequestApprovedHandlerSend(IEmpresaRepository empresaRepository,
            ISUMovAsistenciaCabRepository movAsistenciaCabRepository,
            ISUMovAsistenciaDetRepository movAsistenciaDetRepository)
        {
            this.empresaRepository = empresaRepository;
            this.movAsistenciaCabRepository = movAsistenciaCabRepository;
            this.movAsistenciaDetRepository = movAsistenciaDetRepository;
        }

        public void Handler(StaffRequestApproved args)
        {
            var CompaniesList = empresaRepository.GetAll().Result;

            int? nIdIdentidad = CompaniesList.Where(i => i.Id == args.registerAsistenciaDto.IdCompany).Select(i => i.IdServerUs).FirstOrDefault();
            if (nIdIdentidad == null)
            {
                return;
            }

            SUGetNewIdFilterDto newidFilterDto = new SUGetNewIdFilterDto();
            newidFilterDto.cod_tipo_solicitud = args.registerAsistenciaDto.CodTipoSolicitud;
            newidFilterDto.identidad = nIdIdentidad ?? 0; 
            int nNewNroSolicitud = movAsistenciaCabRepository.GetNewId(newidFilterDto).Result;

            int nidColaborador = movAsistenciaCabRepository.GetIdEmployee(newidFilterDto.identidad, args.registerAsistenciaDto.CodEmpleado).Result;

            SUInsertMovCabDto insertcabDto = new SUInsertMovCabDto();

            insertcabDto.identidad = nIdIdentidad ?? 0;

            insertcabDto.codtiposolicitud = args.registerAsistenciaDto.CodTipoSolicitud;
            insertcabDto.nrosolicitud = nNewNroSolicitud;
            insertcabDto.centroresp = args.registerAsistenciaDto.CentroResponsabilidad;
            insertcabDto.idtrabajador = nidColaborador;
            insertcabDto.codsubtipo = args.registerAsistenciaDto.CodSubTipoSolicitud;
            insertcabDto.fecha_mov_solicitud = args.registerAsistenciaDto.FechaSolicitud;
            insertcabDto.descripcion_solicitud = args.registerAsistenciaDto.DescripcionSolcitud;
            movAsistenciaCabRepository.Insert(insertcabDto).Wait();



            SUInsertMovDetDto insertdetDto = new SUInsertMovDetDto();
            insertdetDto.identidad = nIdIdentidad ?? 0;
            insertdetDto.num_solicitud = nNewNroSolicitud;

            insertdetDto.cod_tipo_solicitud = args.registerAsistenciaDto.CodTipoSolicitud;
            insertdetDto.cod_subtipo_solicitud = args.registerAsistenciaDto.CodSubTipoSolicitud;
            insertdetDto.fecha_movimiento = args.registerAsistenciaDto.FechaSolicitud;
            insertdetDto.idtrabajador = nidColaborador;
            insertdetDto.fecha_hora_inicio = args.registerAsistenciaDto.fecha_hora_inicio;
            insertdetDto.fecha_hora_final = args.registerAsistenciaDto.fecha_hora_final;
            insertdetDto.fecha_hora_inicio_real = args.registerAsistenciaDto.fecha_hora_inicio_real;
            insertdetDto.fecha_hora_final_real = args.registerAsistenciaDto.fecha_hora_final_real;
            movAsistenciaDetRepository.Insert(insertdetDto).Wait();
        }
    }
}
