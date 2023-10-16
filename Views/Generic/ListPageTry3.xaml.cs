using System.Collections.ObjectModel;
using System.Windows.Input;
using CollectionReleaseiOS.Models;
using CollectionReleaseiOS.ViewModels;

namespace CollectionReleaseiOS.Views.Generic;

public class ListPageTry3<TEntity, TType> : ListBaseTry3
	where TEntity : class, IListableItem, new()
	where TType : class, IEntityType, new()
{
	public ICommand DeleteCommand { get; set; }

	public ListPageTry3(GenericListViewModel<TEntity, TType> viewModel)
	{
		DeleteCommand = new Command<object>(OnDeleteSwipeItemCommand);
		
		Items = new ObservableCollection<TEntity>(viewModel.Items);
		EntityTypes = new ObservableCollection<TType>(viewModel.EntityTypes);
		UpdateItemNumbers();
		BindingContext = this;
	}

	public ObservableCollection<TType> EntityTypes { get; set; }
	public ObservableCollection<TEntity> Items { get; set; }

	private void UpdateItemNumbers()
	{
		var itemNumber = 1;
		foreach (var item in Items) {
			item.ListNumber = itemNumber;
			itemNumber++;
		}
	}
	
	private void OnDeleteSwipeItemCommand(object sender)
	{
		if (sender is not SwipeItem swipeItem) return;
		var selectedItem = swipeItem.BindingContext as TEntity;
		if (selectedItem != null && Items != null) {
			Items.Remove(selectedItem);
			UpdateItemNumbers();
		}
	}
}