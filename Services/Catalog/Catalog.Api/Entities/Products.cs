using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Api.Entities
{
	public class Products
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string ID { get; set; }
		[BsonElement("Name")]
		public string Name { get; set; }
		public string Category { get; set; }
		public string Summary { get; set; }
		public string Dscription { get; set; }
		public string ImageFile { get; set; }
		public decimal Price { get; set; }
	}
}