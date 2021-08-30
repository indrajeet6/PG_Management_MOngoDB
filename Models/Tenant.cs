using System.ComponentModel;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;


namespace PG_Management_MongoDB.Models
{
    public class Tenant
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Tenant_Name")]
        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }

        [BsonElement("Tenant_Office_Address")]
        [DisplayName("Office Address")]
        [Required]
        public string Address { get; set; }

        [BsonElement("Tenant_Phone")]
        [Required]
        [MaxLength(10)]
        [DisplayName("Phone")]
        [RegularExpression(@"\d+", ErrorMessage = "Use numbers only please")]
        public string Phone { get; set; }

        [BsonElement("Tenant_Paid_Status")]
        [DisplayName("Rent Paid?")]
        public BsonBoolean PaidStatus { get; set; }
    }
}