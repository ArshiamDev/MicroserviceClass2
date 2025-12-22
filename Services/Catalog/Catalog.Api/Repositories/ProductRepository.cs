using Catalog.Api.Data;
using Catalog.Api.Entities;
using MongoDB.Driver;
using System.Xml.Linq;

namespace Catalog.Api.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly ICatalogContext _Context;
		public ProductRepository(ICatalogContext catalogContext)
		{
			_Context = catalogContext;
		}
		public async Task CreateProduct(Products product)
		{
			 await _Context.products.InsertOneAsync(product);
		}

		public async Task<bool> DeleteProduct(string id)
		{
			FilterDefinition<Products> filter = Builders<Products>.Filter.Eq(p => p.ID , id);
			DeleteResult DeleteResualt = await _Context.products.DeleteOneAsync(filter);
			return DeleteResualt.IsAcknowledged && DeleteResualt.DeletedCount > 0;
		}

		public async Task<IEnumerable<Products>> GetProducts()
		{
			return await _Context.products.Find(_ => true).ToListAsync();
		}

		public async Task<Products> GetProducts(string id)
		{
			return await _Context.products.Find(_ => _.ID == id).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Products>> GetProductsByCategory(string category)
		{
			return await _Context.products.Find(_ => _.Category.Contains(category)).ToListAsync();
		}

		public async Task<IEnumerable<Products>> GetProductsByName(string name)
		{
			return await _Context.products.Find(_ => _.Name.Contains(name)).ToListAsync();
		}

		public async Task<bool> UpdateProduct(Products product)
		{
			var UpdateResualt = await _Context.products.ReplaceOneAsync(filter : p => p.ID == product.ID , replacement: product);
			return UpdateResualt.IsAcknowledged && UpdateResualt.ModifiedCount > 0;
		}
	}
}