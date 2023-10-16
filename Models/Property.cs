using Newtonsoft.Json;

namespace CollectionReleaseiOS.Models
{
	public class Property
	{
		public int Id { get; set; }
		public string Address { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int Bedroom { get; set; }
		public int Bathroom { get; set; }
		public int Size { get; set; }
		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }
		[JsonProperty("updated_at")]
		public DateTime UpdatedAt { get; set; }
		[JsonProperty("locagest_id")]
		public int LocagestId { get; set; }
		[JsonProperty("agency_id")]
		public int AgencyId { get; set; }
		[JsonProperty("property_type_id")]
		public int PropertyTypeId { get; set; }
		[JsonProperty("property_model_id")]
		public int? PropertyModelId { get; set; }
		public List<Room> Rooms { get; set; }
		public Agency Agency { get; set; }
	}

	public class Agency
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}

