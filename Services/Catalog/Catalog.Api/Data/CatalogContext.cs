using Catalog.Api.Entities;
using MongoDB.Driver;

namespace Catalog.Api.Data
{
	public class CatalogContext : ICatalogContext
	{
		public IMongoCollection<Products> products { get; }

		public CatalogContext(IConfiguration configuration)
		{
			var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
			var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
			products = database.GetCollection<Products>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
		}
	}
}
