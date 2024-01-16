using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.WindowsService.Exactus.Models
{
    

    [Table("E_ALL.PUESTO")]
    public partial class ExactusPuesto
    {
        [Key]
        [Column("PUESTO")]
        [StringLength(8)]
        public string PUESTO { get; set; }

        [Required]
        [StringLength(254)]
        public string DESCRIPCION { get; set; }

        public decimal? SALARIO_MINIMO { get; set; }

        public decimal? SALARIO_INTERM1 { get; set; }

        public decimal? SALARIO_INTERM2 { get; set; }

        public decimal? SALARIO_MAXIMO { get; set; }

        public decimal? SALARIO_ACTUAL { get; set; }

        [Required]
        [StringLength(8)]
        public string CONSECUTIVO_PLAZA { get; set; }

        [Column(TypeName = "text")]
        public string NOTAS { get; set; }

        [Required]
        [StringLength(1)]
        public string ACTIVO { get; set; }

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

        [StringLength(200)]
        public string U_GRUPOPUESTO { get; set; }

        [StringLength(200)]
        public string U_CATEGORIASALARIAL { get; set; }

        public decimal? U_PUNTAJECATMINIMO { get; set; }

        public decimal? U_PUNTAJECATMAXIMO { get; set; }

        [StringLength(200)]
        public string U_BANDASALARIALINTMINIMA { get; set; }

        [StringLength(200)]
        public string U_BANDASALARIALINTMAXIMA { get; set; }

        [StringLength(200)]
        public string U_BANDASALARIALEXTMINIMO { get; set; }

        [StringLength(200)]
        public string U_BANDASALARIALEXTMAXIMA { get; set; }
    }
}
