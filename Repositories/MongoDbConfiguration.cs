using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Repositories
{
    public class MongoDbConfiguration
    {
        public static IMongoDatabase DB { get; private set; }

        public MongoDbConfiguration(IConfiguration configuration)
        {
            var url = configuration.GetConnectionString("MongoConnection");

            // Configure the database settings
            if (string.IsNullOrEmpty(url))
            {
                throw new Exception("A connection string for the database must be provided.");
            }
            else
            {
                var client = new MongoClient(url);
                DB = client.GetDatabase("ms-production");
            }

        }
    }
}
