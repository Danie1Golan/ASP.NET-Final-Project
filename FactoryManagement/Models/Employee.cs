using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FactoryManagement.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StartWorkYear { get; set; }
        public int DepartmentID { get; set; }

        public virtual Department Deparment { get; set; }

        public virtual ICollection <EmployeeShift> EmployeeShifts { get; set; }

        
       
        


    }
    



}
