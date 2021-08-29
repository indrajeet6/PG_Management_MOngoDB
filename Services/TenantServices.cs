using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using PG_Management_MongoDB.Models;

namespace PG_Management_MongoDB.Services
{
    public class TenantServices
    {
        private readonly IMongoCollection<Tenant> _tenants;

        public TenantServices(IConfiguration configuration)
        {
            var settings = MongoClientSettings.FromConnectionString(configuration.GetConnectionString("TenantsDB"));
            MongoClient client = new MongoClient(settings);
            IMongoDatabase database = client.GetDatabase("PG_Management");
            _tenants = database.GetCollection<Tenant>("Tenants");
        }
        public List<Tenant> Get()
        {
            return _tenants.Find(tenant => true).ToList();
        }

        public Tenant Get(string id)
        {
            return _tenants.Find(car => car.Id == id).FirstOrDefault();
        }

        public Tenant Create(Tenant tenant)
        {
            _tenants.InsertOne(tenant);
            return tenant;
        }

        public void Update(string id, Tenant tenantIn)
        {
            _tenants.ReplaceOne(tenant => tenant.Id == id, tenantIn);
        }

        public void Remove(Tenant tenantIn)
        {
            _tenants.DeleteOne(tenant => tenant.Id == tenantIn.Id);
        }

        public void Remove(string id)
        {
            _tenants.DeleteOne(tenant => tenant.Id == id);
        }
    }
}