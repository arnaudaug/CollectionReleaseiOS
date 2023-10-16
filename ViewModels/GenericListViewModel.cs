using System.Collections.ObjectModel;
using CollectionReleaseiOS.Models;

namespace CollectionReleaseiOS.ViewModels;

public class GenericListViewModel<TEntity, TType>
	where TEntity : IListableItem
	where TType : IEntityType
{
	public ObservableCollection<TEntity> Items { get; set; } = new();
	public ObservableCollection<TType> EntityTypes { get; set; } = new();
}

