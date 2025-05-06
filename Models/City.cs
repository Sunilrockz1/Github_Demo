using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abfirstapplicationapi.Models
{
    [Table("city")]
    public class City
    {
        [Key]
        public int ctid { get; set; }
        public string ctname { get; set; }
        public int sid { get; set; }
    }
}
