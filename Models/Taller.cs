using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArmoblaProject.Models
{
    [Table("taller")]
    public class Taller
    {
        [Key]
        [Column("id_taller")]
        public int Id { get; set; }

        [Column("costo")]
        public decimal Costo { get; set; }

        [Column("yt")]
        public bool YT { get; set; }
    }
}
