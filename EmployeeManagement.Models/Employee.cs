using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    public class Employee:BaseModel
    {
        [Key]
        public int EmplId { get; set; }
        public string EmplName { get; set; }
        public string EmplCode { get; set; }
        public int EmplRoleId { get; set; }
    }
}
