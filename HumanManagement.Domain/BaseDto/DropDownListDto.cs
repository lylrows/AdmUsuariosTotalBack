
namespace HumanManagement.Domain.BaseDto
{
    public class DropDownListDto<T>
    {
        public T Code { get; set; }
        public string Description { get; set; }
    }

    public class ListGroupDto
    {
        public int Code { get; set; }
        public string Description { get; set; }
    }

    public class DropDownListString
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class ListCompetencesDto<T>
    {
        
        public int IdCompetence { get; set; }
        public string NameCompetence { get; set; }
        public string DescriptionCompetence { get; set; }
        public string DescriptionLevel1 { get; set; }
        public string DescriptionLevel2 { get; set; }
        public string DescriptionLevel3 { get; set; }
        public string DescriptionLevel4 { get; set; }

        public int NidSelected { get; set; }
        public int IdLevel { get; set; }
        public bool IsExpanded { get; set; }
        public string IconCompetence { get; set; }
        public bool IsConfigured { get; set; }

    }
}
