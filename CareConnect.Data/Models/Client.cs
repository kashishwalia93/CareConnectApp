using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareConnect.Data.Models
{
    public class Client
    {
        [Key]
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int? SalutationId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateTime? Dob { get; set; }
        public string? Gender { get; set; }
        public string? PrimaryEmail { get; set; }
        public string? SecondaryEmail { get; set; }
        public string? CellPhone { get; set; }
        public string? HomePhone { get; set; }
        public string? WorkPhone { get; set; }
        public int? PrimaryPhoneTypeId { get; set; }
        public string? Notes { get; set; }
        public bool? Archived { get; set; }
        public DateTime? CreatedAt { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public long ModifiedBy { get; set; }
        public ICollection<EntityAddress> EntityAddress { get; set; }
    }
}
