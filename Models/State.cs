using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abfirstapplicationapi.Models
{
    [Table("States")]
    public class State
    {
        [Key]
        public int sid { get; set; }
        public string sname { get; set; }
        public int cid {  get; set; }
    }
}
