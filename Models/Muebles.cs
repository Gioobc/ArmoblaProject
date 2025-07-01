using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArmoblaProject.Models
{
    public class Mueble
    {
        [Key]
        [Column("id_mueble")]
        public int Id { get; set; }

        [Column("costo_insta")]
        public decimal CostoInsta { get; set; }
    }

    [Table("tipo")]
    public class Tipo
    {
        [Key]
        [Column("id_tipo")]
        public int Id { get; set; }
    }

    [Table("material")]
    public class Material
    {
        [Key]
        [Column("id_material")]
        public int Id { get; set; }

        [Column("cant_disponible")]
        public decimal CantDisponible { get; set; }
    }

    [Table("mueble_tipo")]
    public class MuebleTipo
    {
        [Key]
        [Column("id_mueble_tipo")]
        public int Id { get; set; }

        [Column("id_mueble")]
        public int MuebleId { get; set; }

        [Column("id_tipo")]
        public int TipoId { get; set; }

        [Column("utilidad")]
        public decimal Utilidad { get; set; }

        [Column("costo_prod")]
        public decimal CostoProd { get; set; }

        [Column("demanda")]
        public int Demanda { get; set; }

        [Column("cant_max")]
        public int CantMax { get; set; }
    }

    [Table("mueble_mat")]
    public class MuebleMat
    {
        [Key]
        [Column("id_mueble_mat")]
        public int Id { get; set; }

        [Column("id_mueble")]
        public int MuebleId { get; set; }

        [Column("id_material")]
        public int MaterialId { get; set; }

        [Column("uso_mat")]
        public decimal UsoMat { get; set; }
    }

    [Table("zona")]
    public class Zona
    {
        [Key]
        [Column("id_zona")]
        public int Id { get; set; }

        [Column("costo_deliv")]
        public decimal CostoDeliv { get; set; }
    }

}
