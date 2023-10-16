using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CollectionReleaseiOS.Models
{
	[Table("room_type")]
	public class RoomType : IEntityType, IHasName
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name_fr")]
		public string NameFr { get; set; }

		[JsonProperty("name_en")]
		public string NameEn { get; set; }

		[JsonProperty("created_at")]
		public DateTime? CreatedAt { get; set; }

		[JsonProperty("updated_at")]
		public DateTime? UpdatedAt { get; set; }
	}
}
