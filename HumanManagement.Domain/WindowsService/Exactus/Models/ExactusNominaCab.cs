using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.WindowsService.Exactus.Models
{
    public class ExactusNominaCab
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string NOMINA { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short NUMERO_NOMINA { get; set; }

        public DateTime FECHA_INICIO { get; set; }

        public DateTime FECHA_FIN { get; set; }

        public DateTime PERIODO { get; set; }

        public DateTime? FECHA_APROBACION { get; set; }

        public DateTime FECHA_PAGO { get; set; }

        [StringLength(25)]
        public string APROBADA_POR { get; set; }

        [StringLength(10)]
        public string ASIENTO { get; set; }

        public DateTime? FECHA_APLICACION { get; set; }

        [StringLength(25)]
        public string USUARIO_APLICACION { get; set; }

        public DateTime? FECHA_CALCULO { get; set; }

        [StringLength(20)]
        public string PRESUPUESTO { get; set; }

        [StringLength(4)]
        public string UNIDAD_OPERATIVA { get; set; }

        public int? NUMERO_APARTADO { get; set; }

        public int? NUMERO_EJERCIDO { get; set; }

        public byte NoteExistsFlag { get; set; }

        public DateTime RecordDate { get; set; }

        public Guid RowPointer { get; set; }

        [Required]
        [StringLength(30)]
        public string CreatedBy { get; set; }

        [Required]
        [StringLength(30)]
        public string UpdatedBy { get; set; }

        public DateTime CreateDate { get; set; }

    }
}
