using System.ComponentModel.DataAnnotations.Schema;

namespace ArmoblaProject.Models
{
    [Table("mueble_tipo")]
    public class MuebleTipo
    {
        [Column("id_mueble")]
        public int MuebleId { get; set; }
        public Mueble Mueble { get; set; }

        [Column("id_tipo")]
        public int TipoId { get; set; }
        public Tipo Tipo { get; set; }

        [Column("costo_prod")]
        public decimal CostoProd { get; set; }

        [Column("utilidad")]
        public decimal Utilidad { get; set; }

        [Column("demanda")]
        public int Demanda { get; set; }

        [Column("cant_max")]
        public int CantMax { get; set; }

    }
}
