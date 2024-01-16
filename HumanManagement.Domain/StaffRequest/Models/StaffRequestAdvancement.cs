using HumanManagement.Domain.Employee.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.StaffRequest.Models
{
    public class StaffRequestAdvancement
    {
		[Column("nid_advancement")]
		public int nid_advancement { get; set; }

		[Column("nid_request")]
		public int nid_request { get; set; }

		[Column("nid_collaborator")]
		public int nid_collaborator { get; set; }

		[Column("namount")]
		public decimal namount { get; set; }

		[Column("nreason")]
		public int nreason { get; set; }

		[Column("sdetailreason")]
		public string sdetailreason { get; set; }

		[Column("nstate")]
		public int nstate { get; set; }

		[Column("dateapproval")]
		public DateTime dateapproval { get; set; }

		[Column("nid_approved")]
		public int? nid_approved { get; set; }

		[Column("dregister")]
		public DateTime dregister { get; set; }

		[Column("nuserregister")]
		public int nuserregister { get; set; }

		[Column("dupdate")]
		public DateTime? dupdate { get; set; }

		[Column("nuserupdate")]
		public int? nuserupdate { get; set; }

		public virtual StaffRequestModel Requests { get; set; }
		public virtual EmployeeModel Collaborators { get; set; }

		public void SetIdStaffRequest(int id)
		{
			nid_request = id;
		}
	}
}
