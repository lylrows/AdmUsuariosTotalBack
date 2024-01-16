using HumanManagement.Domain.Common;

namespace HumanManagement.Domain.Security.QueryFilter
{
    public class EmployeeQueryFilter
	{
		public int id { get; set; }
		public int idbussines { get; set; }
		public int idgerencia { get; set; }
		public int idarea { get; set; }
		public int nidsubarea { get; set; }
		public int nstate { get; set; }
		public int nid_typerequest { get; set; }
		public int ntypeseccion { get; set; }
		public string dateStart { get; set; }
		public string dateEnd { get; set; }
		public int nid_employee { get; set; }

		public PaginationEntity pagination { get; set; }
        public EmployeeQueryFilter()
        {
            pagination = new PaginationEntity();
        }
    }
}
