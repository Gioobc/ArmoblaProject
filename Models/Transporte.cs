using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArmoblaProject.Models
{
    [Table("transporte")]
    public class Transporte
    {
        [Key]
        [Column("id_transporte")]
        public int Id { get; set; }

        [Column("costo")]
        public decimal Costo { get; set; }

        [Column("ytr")]
        public bool YTR { get; set; }
    }
}
