using System.ComponentModel.DataAnnotations;

namespace FactoryManagement.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; } 

        public virtual Employee Manager { get; set; }

        public virtual ICollection <Employee> Employees { get; set; }
       
    }
}
