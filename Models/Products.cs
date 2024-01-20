using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBAPI.Models
{
    public class ProductsModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string CollectionName { get; set; }
        public string Model { get; set; }
        public bool? IsSelected { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public List<VariationModel> Variations { get; set; }
        public ColorModel Color { get; set; }
        public ColorModel CaseColor { get; set; }
        public ColorModel StrapColor { get; set; }
        public List<string> StrapMaterial { get; set; }
        public List<string> Size { get; set; }
        public List<string> Space { get; set; }
        public string Cover { get; set; }
        public List<string> Images { get; set; }

        public ProductsModel()
        {
            Variations = new List<VariationModel>();
            Color = new ColorModel();
            CaseColor = new ColorModel();
            StrapColor = new ColorModel();
            StrapMaterial = new List<string>();
            Size = new List<string>();
            Space = new List<string>();
            Images = new List<string>();

            CollectionName = string.Empty;
            Model = string.Empty;
            Description = string.Empty;
            Category = string.Empty;
            Price = string.Empty;
            Cover = string.Empty;
        }
    }

    public class ColorModel
    {
        public string Name { get; set; }
        public string Hex { get; set; }

        public ColorModel()
        {
            Name = string.Empty;
            Hex = string.Empty;
        }
    }

    public class VariationModel
    {
        public string Space { get; set; }

        public VariationModel()
        {
            Space = string.Empty;
        }

        public int? Price { get; set; }
    }
}
