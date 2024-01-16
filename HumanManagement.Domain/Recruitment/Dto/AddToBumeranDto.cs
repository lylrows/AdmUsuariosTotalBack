using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HumanManagement.Domain.Recruitment.Dto
{
	[XmlRoot(ElementName = "Avisos")]
	public class AddToBumeranDto
	{

		[XmlElement(ElementName = "aviso")]
		public Aviso Aviso { get; set; }
	}

	[XmlRoot(ElementName = "DatosAdicionales")]
	public class DatosAdicionales
	{

		[XmlAttribute(AttributeName = "emp_idempresa")]
		public int EmpIdempresa { get; set; }

		[XmlAttribute(AttributeName = "emp_token")]
		public string EmpToken { get; set; }
	}

	[XmlRoot(ElementName = "aviso")]
	public class Aviso
	{

		[XmlElement(ElementName = "DatosAdicionales")]
		public DatosAdicionales DatosAdicionales { get; set; }

		[XmlElement(ElementName = "txAccion")]
		public string TxAccion { get; set; }

		[XmlElement(ElementName = "idPlanPublicacion")]
		public int IdPlanPublicacion { get; set; }

		[XmlElement(ElementName = "txAviso2Url")]
		public string TxAviso2Url { get; set; }

		[XmlElement(ElementName = "txCodigoReferencia")]
		public int TxCodigoReferencia { get; set; }

		[XmlElement(ElementName = "idPais")]
		public int IdPais { get; set; }

		[XmlElement(ElementName = "idArea")]
		public int IdArea { get; set; }

		[XmlElement(ElementName = "idTipoTrabajo")]
		public int IdTipoTrabajo { get; set; }

		[XmlElement(ElementName = "minSalario")]
		public int MinSalario { get; set; }

		[XmlElement(ElementName = "maxSalario")]
		public int MaxSalario { get; set; }

		[XmlElement(ElementName = "netoBruto")]
		public string NetoBruto { get; set; }

		[XmlElement(ElementName = "idFrecuenciaDePago")]
		public int IdFrecuenciaDePago { get; set; }

		[XmlElement(ElementName = "txPuesto")]
		public string TxPuesto { get; set; }

		[XmlElement(ElementName = "idIndustria")]
		public int IdIndustria { get; set; }

		[XmlElement(ElementName = "txDescripcion")]
		public string TxDescripcion { get; set; }

		[XmlElement(ElementName = "numCantidadVacantes")]
		public int NumCantidadVacantes { get; set; }

		[XmlElement(ElementName = "txAgradecimiento")]
		public object TxAgradecimiento { get; set; }

		[XmlElement(ElementName = "idSexo")]
		public object IdSexo { get; set; }

		[XmlElement(ElementName = "numApareceEmpresa")]
		public int NumApareceEmpresa { get; set; }

		[XmlElement(ElementName = "txNombreAlternativoEmpresa")]
		public object TxNombreAlternativoEmpresa { get; set; }

		[XmlElement(ElementName = "txCiudad")]
		public string TxCiudad { get; set; }

		[XmlElement(ElementName = "idZona")]
		public int IdZona { get; set; }

		[XmlElement(ElementName = "email")]
		public string Email { get; set; }
	}

	

}
