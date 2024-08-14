using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecommerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public double Price { get; set; }

        [ForeignKey("Category")]
        public int Categ_Id { get; set; }

        [JsonIgnore]
        public virtual Category? Category { get; set; }

    }
}
