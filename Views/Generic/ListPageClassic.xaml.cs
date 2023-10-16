using CollectionReleaseiOS.Models;

namespace CollectionReleaseiOS.Views.Generic;

public partial class ListPageClassic
{
	public delegate void ReturnDataCallback(List<Room> items);
	public ListPageClassic(List<Room> rooms)
	{
		InitializeComponent();

		Items = rooms;
		UpdateRoomNumbers();
		BindingContext = this;
	}

	public List<Room> Items { get; set; }

	private void OnDeleteSwipeItemInvokedClassic(object sender, EventArgs e)
	{
		var selectedRoom = (sender as SwipeItem).BindingContext as Room;
		if (selectedRoom != null && Items != null) {
			// Removes the selected item from the list
			Items.Remove(selectedRoom);
			UpdateRoomNumbers();
			// Refreshes the list to reflect changes
			ItemsCollectionView.ItemsSource = null;
			ItemsCollectionView.ItemsSource = Items;
		}
	}

	private void UpdateRoomNumbers()
	{
		for (var i = 0; i < Items.Count; i++) Items[i].ListNumber = i + 1;
	}
}