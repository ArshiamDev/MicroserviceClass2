using Catalog.Api.Entities;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Catalog.Api.Data
{
	public class CatalogContextSeed
	{
		public static  async Task SeedData(IMongoCollection<Products> ProductCollection)
		{
			bool existsProduct = await ProductCollection.Find(p => true).AnyAsync();
			if (!existsProduct)
			{
				await ProductCollection.InsertManyAsync(GetSeedData());

			}
		}

		private static IEnumerable<Products> GetSeedData()
		{
			return new List<Products>()
			{
				new Products()
				{
					//ID = "6947af69646fbca5878de66d" ,
					Name = "ip1" ,
					Summary = "asdsdsdsd" ,
					Dscription = "sdsdsd" , 
					ImageFile = "sdsdsd" , 
					Price = 950.25M ,
					Category = "Smart Phone"
				},
				new Products()
				{
					//ID = "6947af69646fbca5878de66f" ,
					Name = "ip2" ,
					Summary = "asdsdsdsd2" ,
					Dscription = "sdsdsd2" ,
					ImageFile = "sdsdsd2" ,
					Price = 950.262M ,
					Category = "Smart Phone"
				},
				new Products()
				{
					//ID = "6947af69646fbca5878de66j" ,
					Name = "ip3" ,
					Summary = "asdsdsdsd3" ,
					Dscription = "sdsdsd3" ,
					ImageFile = "sdsdsd3" ,
					Price = 950.263M ,
					Category = "Smart Phone3"
				}
			};
		}

	}
}