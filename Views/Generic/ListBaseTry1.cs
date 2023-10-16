namespace CollectionReleaseiOS.Views.Generic;

public partial class ListBaseTry1 : ContentPage
{
	public ListBaseTry1()
	{
		InitializeComponent();
	}

	protected CollectionView InternalItemsCollectionView => ItemsCollectionView;

	protected virtual void OnDeleteSwipeItemInvoked(object sender, EventArgs e)
	{
	}
}