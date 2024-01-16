using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Organigram.Dto
{
    public class OrganigramDto
    {
		public int Id { get; set; }
		public int IdEmpresa { get; set; }
		public int IdCargo { get; set; }
		public string Label { get; set; }
		public string Type { get; set; }
		public string StyleClass { get; set; }
		public bool Expanded { get; set; }
		public DataPerson Data { get; set; }
		public List<OrganigramDto> Children { get; set; }
	}

	public class DataPerson
	{
		public string Name { get; set; }
		public string Avatar { get; set; }
		public string Cargo { get; set; }
	}
}
