using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.WebServices.Dto
{
   
	public class Aviso
	{


		public int idPosicion { get; set; }


		public int status { get; set; }


		public string mensaje { get; set; }
	}


	public class ReponseDto
	{


		public List<Aviso> aviso { get; set; }
	}
}
