namespace CollectionReleaseiOS.Models
{
	public interface IEntityType
	{
		int Id { get; }
		string NameFr { get; }
		string NameEn { get; }
		DateTime? CreatedAt { get; }
		DateTime? UpdatedAt { get; }
	}
}