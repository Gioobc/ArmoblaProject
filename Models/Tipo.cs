using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArmoblaProject.Models
{
    [Table("tipo")]
    public class Tipo
    {
        [Column("id_tipo")]
        public int Id { get; set; }

        public ICollection<MuebleTipo> MuebleTipos { get; set; }
    }
}
