using Catalog.Api.Entities;

namespace Catalog.Api.Repositories
{
	public interface IProductRepository
	{
		Task<IEnumerable<Products>> GetProducts();
		Task<Products> GetProducts(string id);
		Task<IEnumerable<Products>> GetProductsByName(string name);
		Task<IEnumerable<Products>> GetProductsByCategory(string category);
		Task CreateProduct(Products product);
		Task<bool> UpdateProduct(Products product);
		Task<bool> DeleteProduct(string id);
	}
}