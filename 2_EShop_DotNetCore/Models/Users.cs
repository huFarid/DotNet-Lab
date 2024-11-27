using System.ComponentModel.DataAnnotations;

namespace Shop_DotNetCore.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        public string  Name { get; set; }
        public string FamilyName { get; set; }
        [Required]
        [MaxLength(300)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        public bool IsAdmin {  get; set; }


    }
}
