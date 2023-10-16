namespace CollectionReleaseiOS.Models
{
	public interface IListableItem
	{
		public int Id { get; set; }

		int ListNumber { get; set; }
		string DisplayName { get; set; }

		void SetEntityType(IEntityType entityType);
	}
}