using System.ComponentModel.DataAnnotations;

namespace FactoryManagement.Models
{
    public class Shift

    {
        [Key]
        public int Id { get; set; } 
        public DateTime Date { get; set; }   
        public int StartTime { get; set; }  
        public int EndTime { get; set; }    

        public virtual ICollection <EmployeeShift> EmployeeShifts { get; set; }
        


    }
}
