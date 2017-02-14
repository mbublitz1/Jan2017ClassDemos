using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace Chinook.Data.Enitities
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="Last Name is regquired.")]
        [StringLength(20,ErrorMessage ="Last Name is limited to 20 characters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "First Name is regquired.")]
        [StringLength(20, ErrorMessage = "First Name is limited to 20 characters.")]
        public string FirstName { get; set; }
        [StringLength(30, ErrorMessage = "Title is limited to 30 characters.")]
        public string Title { get; set; }
        public int? ReportsTo { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        [StringLength(70, ErrorMessage = "Address is limited to 70 characters.")]
        public string Address { get; set; }
        [StringLength(40, ErrorMessage = "City is limited to 40 characters.")]
        public string City { get; set; }
        [StringLength(40, ErrorMessage = "State is limited to 40 characters.")]
        public string State { get; set; }
        [StringLength(40, ErrorMessage = "Country is limited to 40 characters.")]
        public string Country { get; set; }
        [StringLength(10, ErrorMessage = "Postal Code is limited to 10 characters.")]
        public string PostalCode { get; set; }
        [StringLength(24, ErrorMessage = "Phone is limited to 24 characters.")]
        public string Phone { get; set; }
        [StringLength(24, ErrorMessage = "Faxis limited to 24 characters.")]
        public string Fax { get; set; }
        [StringLength(60, ErrorMessage = "Email is limited to 60 characters.")]
        public string Email { get; set; }

    }
}
