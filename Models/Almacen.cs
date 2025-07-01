using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArmoblaProject.Models
{
    [Table("almacen")]
    public class Almacen
    {
        [Key]
        [Column("id_almacen")]
        public int Id { get; set; }

        [Column("costo")]
        public decimal Costo { get; set; }

        [Column("ya")]
        public bool YA { get; set; }
    }
}
