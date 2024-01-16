namespace HumanManagement.Domain.General.Dto
{
    public class ParameterFilterDto
    {
        public string ApplicationName { get; set; }
        public string Module { get; set; }
        public string Key { get; set; }
        public ParameterTypeValue TypeValue { get; set; }
    }

    public enum ParameterTypeValue
    {
        Numeric = 1,
        String = 2
    }
}
