using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abfirstapplicationapi.Models
{
    [Table("Usersss")]
    public class Employee
    {
        [Key]
        public int uid { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only alphabets allowed")]
        public string fname { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only alphabets allowed")]
        public string lname { get; set; }
        public DateTime dob { get; set; }
        [Required]
        [EmailAddress]
        public string email {  get; set; }
        public string gender {  get; set; }
        public string address { get; set; }
        [Required]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Pincode must be 6 digits")]
        public int pincode { get; set; }
        public int cid { get; set; }  
        public int sid { get; set; }   
        public int ctid { get; set; }

        public bool isDeleted { get; set; }
        public bool isActive { get;set; }
    }
}
