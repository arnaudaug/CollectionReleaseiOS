namespace CollectionReleaseiOS.Views.Generic;

public partial class ListBaseTry2 : ContentPage
{
	public ListBaseTry2()
	{
		InitializeComponent();
	}

	protected CollectionView InternalItemsCollectionView => ItemsCollectionView;

	protected virtual void OnDeleteSwipeItemInvoked(object sender, EventArgs e)
	{
	}

	protected virtual void OnMoveUpSwipeItemInvoked(object sender, EventArgs e)
	{
	}

	protected virtual void OnMoveDownSwipeItemInvoked(object sender, EventArgs e)
	{
	}
}