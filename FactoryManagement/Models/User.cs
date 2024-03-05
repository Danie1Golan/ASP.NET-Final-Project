using System.ComponentModel.DataAnnotations;

namespace FactoryManagement.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        [Required]
        
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public int NumOfActions { get; set; }
        public DateTime lastActionDate { get; set; }

        
    }
}
