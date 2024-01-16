using HumanManagement.Domain.Postulant.Person.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.InformationPostulant.Dto
{
    public class InformationPostulantAllDto
    {
        public List<InformationComputerSkillsDto> InformationComputerSkillsDtos { get; set; }
        public List<InformationLangDto> InformationLangDtos { get; set; }
        public List<InformationEducationDto> InformationEducationDtos { get; set; }
        public List<InformationWorkDto> InformationWorkDtos { get; set; }
        public List<InformationFamilyDto> InformationFamilyDtos { get; set; }
        public InformationAditionalDto InformationAditionalDtos { get; set; }
        public PersonDto InformationPerson { get; set; }
        public InformationExtraDto InformationExtraDto { get; set; }
        public List<ArchivosPostulante> listaDocumentos { get; set; }
        public List<DocumentoAdicional> listaDocumentosAdicionales { get; set; }
        public int IdEvaluation { get; set; }
    }

    public class ArchivosPostulante
    {
        public int nidinformationfile { get; set; }
        public string tipo_archivo { get; set; }
        public string archivo_base64 { get; set; }
        public string filename { get; set; }
        public string extension { get; set; }
        public string ruta_archivo { get; set; }
    }

    public class FilterListaArchivos
    {
        public int nidinformationextra { get; set; }
        public int nidreferences { get; set; }
        public string stipo_archivo { get; set; }
        public int ntipo_archivo { get; set; }
    }

    public class DocumentoAdicional
    {
        public int IdDocumentAditional { get; set; }
        public int IdEvaluation { get; set; }
        public int IdPostulant { get; set; }
        public int IdMaster { get; set; }
        public string Document { get; set; }
        public string Description { get; set; }
        public bool IndicadorCheck { get; set; }
        public bool IndicadorPlantilla { get; set; }
        public string PathPlantilla { get; set; }
        public bool IndicadorFile { get; set; }
        public string NombreFile { get; set; }
        public string PathFile { get; set; }
        public string FileBase64 { get; set; }
        public bool Checked { get; set; }
    }
}
