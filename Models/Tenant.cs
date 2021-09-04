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
        [BsonElement("Rent Amount")]
        [Required]
        public int Rent {get; set;}
        [BsonElement("Parent's Name")]
        [Required]
        [DisplayName("Parent's Name")]
        public string ParentName{get; set;}

        [BsonElement("Parent's Phone Number")]
        [Required]
        [DisplayName("Parent's Phone Number")]
        [MaxLength(10)]
        [RegularExpression(@"\d+", ErrorMessage = "Use numbers only please")]
        public string ParentPhone{get; set;}

        [BsonElement("Parent's Address")]
        [Required]
        [DisplayName("Parent's Address")]
        public string ParentAddress{get; set;}


        [BsonElement("Tenant_Paid_Status")]
        [DisplayName("Rent Paid?")]
        public BsonBoolean PaidStatus { get; set; }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public string PaidStatusValue{get;set;}
        public static string[] PaidStatusValues = new [] {"Yes","No"};
    }
}