using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareConnect.Data.Models
{
    public class EntityAddress
    {
        [Key]
        public long Id { get; set; }
        public long ClientId { get; set; }
        public long? EntityId { get; set; }
        public int AddressTypeId { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        public string? AddressLine4 { get; set; }
        public string? City { get; set; }
        public string? County { get; set; }
        public int? StateProvinceId { get; set; }
        public int? CountryRegionId { get; set; }
        public string? PostalCode { get; set; }
        public bool? IsPrimary { get; set; }
        public bool? IsActive { get; set; }
        public bool? Archived { get; set; }
        public DateTime? CreatedAt { get; set; }
        public long CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }
        public long ModifiedBy { get; set; }
        public Client Client { get; set; }
    }
}
