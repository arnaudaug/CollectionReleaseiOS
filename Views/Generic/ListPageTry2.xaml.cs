﻿using System.Collections.ObjectModel;
using CollectionReleaseiOS.Models;
using CollectionReleaseiOS.ViewModels;

namespace CollectionReleaseiOS.Views.Generic;

public class ListPageTry2<TEntity, TType> : ListBaseTry2
	where TEntity : class, IListableItem, new()
	where TType : class, IEntityType, new()
{
	public delegate void ReturnDataCallback(List<TEntity> items);

	public ListPageTry2(GenericListViewModel<TEntity, TType> viewModel)
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

	protected override void OnDeleteSwipeItemInvoked(object sender, EventArgs e)
	{
		if (sender is not SwipeItem swipeItem) return;
		var selectedItem = swipeItem.BindingContext as TEntity;
		if (selectedItem != null && Items != null) {
			Items.Remove(selectedItem);
			UpdateItemNumbers();
		}
	}
	
	protected override void OnMoveUpSwipeItemInvoked(object sender, EventArgs e)
	{
		if (sender is not SwipeItem swipeItem) return;
		var selectedItem = swipeItem.BindingContext as TEntity;
		if (selectedItem != null && Items != null)
		{
			var selectedIndex = Items.IndexOf(selectedItem);
			if (selectedIndex <= 0) return;
			Items.RemoveAt(selectedIndex);
			Items.Insert(selectedIndex - 1, selectedItem);
			UpdateItemNumbers();
		}
	}

	protected override void OnMoveDownSwipeItemInvoked(object sender, EventArgs e)
	{
		if (sender is not SwipeItem swipeItem) return;
		var selectedItem = swipeItem.BindingContext as TEntity;
		if (selectedItem != null && Items != null)
		{
			var selectedIndex = Items.IndexOf(selectedItem);
			if (selectedIndex >= Items.Count - 1) return;
			Items.RemoveAt(selectedIndex);
			Items.Insert(selectedIndex + 1, selectedItem);
			UpdateItemNumbers();
		}
	}
}