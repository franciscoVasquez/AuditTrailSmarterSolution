using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace AuditTrailModel
{
    [Table("Auditoria")]
    public class Auditoria
    {
        [Key]
        public long ID_AUDIT { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserID { get; set; }

        [Required]
        public DateTime FechaCambio { get; set; }

        [Required]
        [MaxLength(100)]
        public string NombreTabla { get; set; }

        [Required]
        public string TipoEvento { get; set; }

        [Required]
        [MaxLength(100)]
        public string NombreColumnas { get; set; }

       
        [MaxLength(500)]
        public string ValorAnterior { get; set; }

       
        [MaxLength(500)]
        public string ValorActual { get; set; }


    }
}
