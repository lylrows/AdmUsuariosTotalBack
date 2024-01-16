using HumanManagement.Domain.Empresa.Contracts;
using HumanManagement.Domain.WindowsService.ServerUs.Contracts;
using HumanManagement.Domain.WindowsService.ServerUs.Dto;

using System.Linq;

using WSHumanManagement.Application.ServerUs.Asistencia.IServices;

namespace WSHumanManagement.Application.ServerUs.Asistencia.Services
{
   
    public class ServerUsAsistenciaService : IServerUsAsistenciaService
    {
        private readonly IEmpresaRepository empresaRepository;
        private readonly ISUMovAsistenciaCabRepository movAsistenciaCabRepository;
        private readonly ISUMovAsistenciaDetRepository movAsistenciaDetRepository;

        public ServerUsAsistenciaService(IEmpresaRepository empresaRepository,
            ISUMovAsistenciaCabRepository movAsistenciaCabRepository,
            ISUMovAsistenciaDetRepository movAsistenciaDetRepository
            )
        {
            this.empresaRepository = empresaRepository;
            this.movAsistenciaCabRepository = movAsistenciaCabRepository;
            this.movAsistenciaDetRepository = movAsistenciaDetRepository;
        }

        public void Register(SURegisterAsistenciaDto dtoInsertAsistencia)
        {
            var CompaniesList = empresaRepository.GetAll().Result;

            int? nIdIdentidad = CompaniesList.Where(i => i.Id == dtoInsertAsistencia.IdCompany).Select(i => i.IdServerUs).FirstOrDefault();
            if (nIdIdentidad == null)
            {
                return;
            }

            SUGetNewIdFilterDto newidFilterDto = new SUGetNewIdFilterDto();
            newidFilterDto.cod_tipo_solicitud = dtoInsertAsistencia.CodTipoSolicitud;
            newidFilterDto.identidad = nIdIdentidad ?? 0;
            int nNewNroSolicitud = movAsistenciaCabRepository.GetNewId(newidFilterDto).Result;

            int nidColaborador = movAsistenciaCabRepository.GetIdEmployee(newidFilterDto.identidad, "07183324").Result;

            SUInsertMovCabDto insertcabDto = new SUInsertMovCabDto();

            insertcabDto.identidad = nIdIdentidad ?? 0;
            
            insertcabDto.codtiposolicitud = dtoInsertAsistencia.CodTipoSolicitud;
            insertcabDto.nrosolicitud = nNewNroSolicitud;
            insertcabDto.centroresp = dtoInsertAsistencia.CentroResponsabilidad;
            insertcabDto.idtrabajador = nidColaborador;
            insertcabDto.codsubtipo = dtoInsertAsistencia.CodSubTipoSolicitud;
            insertcabDto.fecha_mov_solicitud = dtoInsertAsistencia.FechaSolicitud;
            insertcabDto.descripcion_solicitud = dtoInsertAsistencia.DescripcionSolcitud;
            movAsistenciaCabRepository.Insert(insertcabDto).Wait();



            SUInsertMovDetDto insertdetDto = new SUInsertMovDetDto();
            insertdetDto.identidad = nIdIdentidad ?? 0;
            insertdetDto.num_solicitud = nNewNroSolicitud;
            
            insertdetDto.cod_tipo_solicitud = dtoInsertAsistencia.CodTipoSolicitud;
            insertdetDto.cod_subtipo_solicitud = dtoInsertAsistencia.CodSubTipoSolicitud;
            insertdetDto.fecha_movimiento = dtoInsertAsistencia.FechaSolicitud;
            insertdetDto.idtrabajador = nidColaborador;
            insertdetDto.fecha_hora_inicio = dtoInsertAsistencia.fecha_hora_inicio;
            insertdetDto.fecha_hora_final = dtoInsertAsistencia.fecha_hora_final;
            insertdetDto.fecha_hora_inicio_real = dtoInsertAsistencia.fecha_hora_inicio_real;
            insertdetDto.fecha_hora_final_real = dtoInsertAsistencia.fecha_hora_final_real;
            movAsistenciaDetRepository.Insert(insertdetDto).Wait();
        }

    }
}
