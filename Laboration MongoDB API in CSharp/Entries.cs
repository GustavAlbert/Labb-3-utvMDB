namespace Laboration_MongoDB_API_in_CSharp
{
    public class Entries
    //Object and Document converter
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Reference ID")]
        public int? InternalDbId { get; set; }

        [BsonElement("Manufacturer")]
        public string? Manufacturer { get; set; }

        [BsonElement("Size")]
        public int? Size { get; set; }

        [BsonElement("Price")]
        public int? Price { get; set; }

        [BsonElement("Quantity in stock")]
        public int? QuantityInStock { get; set; }
    }
}
