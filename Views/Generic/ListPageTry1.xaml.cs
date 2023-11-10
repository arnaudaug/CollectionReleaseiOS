using System.Collections.ObjectModel;
using CollectionReleaseiOS.Models;
using CollectionReleaseiOS.ViewModels;

namespace CollectionReleaseiOS.Views.Generic;

public class ListPageTry1<TEntity, TType> : ListBaseTry1
	where TEntity : class, IListableItem, new()
	where TType : class, IEntityType, new()
{
	public delegate void ReturnDataCallback(List<TEntity> items);

	public ListPageTry1(GenericListViewModel<TEntity, TType> viewModel)
	{
		Items = new ObservableCollection<TEntity>(viewModel.Items);
		EntityTypes = new ObservableCollection<TType>(viewModel.EntityTypes);
		UpdateItemNumbers();
		BindingContext = this;
	}

	public ObservableCollection<TType> EntityTypes { get; set; }
	public ObservableCollection<TEntity> Items { get; set; }
	public ReturnDataCallback Callback { get; set; }

	private void UpdateItemNumbers()
	{
		var itemNumber = 1;
		foreach (var item in Items) {
			item.ListNumber = itemNumber;
			itemNumber++;
		}
	}
	
	protected override async void OnDeleteSwipeItemInvoked(object sender, EventArgs e)
	{
		try
		{
			if (sender is not SwipeItem swipeItem) return;
			var selectedItem = swipeItem.BindingContext as TEntity;
			if (selectedItem != null && Items != null)
			{
				Items.Remove(selectedItem);
				UpdateItemNumbers();
			}
		}
		catch (Exception ex)
		{
			// Remplacez 'this' par votre instance de Page si nécessaire
			await this.DisplayAlert("Erreur", $"Une erreur est survenue : {ex.Message}", "OK");
		}
	}
}