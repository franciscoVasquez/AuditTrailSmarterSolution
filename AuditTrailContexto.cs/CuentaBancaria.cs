using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Data;
namespace AuditTrailModel
{
    
        [Table("CuentaBancaria")]
        public class CuentaBancaria
        {
            [Key]
            public int Cod_Cuenta { get; set; }

            [Required]
            [MaxLength(100)]
            public string NroCuenta { get; set; }

            [Required]
            [MaxLength(100)]
            public string Banco { get; set; }

            [Required]
            [MaxLength(100)]
            public string TipoCuenta { get; set; }
           
    }




}
