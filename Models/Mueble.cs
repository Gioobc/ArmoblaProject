using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArmoblaProject.Models
{
    [Table("mueble")]
    public class Mueble
    {
        [Column("id_mueble")]
        public int Id { get; set; }

        [Column("costo_insta")]
        public decimal CostoInsta { get; set; }

        public ICollection<MuebleTipo> MuebleTipos { get; set; }
    }
}
