using System.Collections.ObjectModel;
using CollectionReleaseiOS.Models;

namespace CollectionReleaseiOS.Views.Generic;

public partial class ListPageClassic2
{
	public delegate void ReturnDataCallback(List<Room> items);
	public ListPageClassic2(List<Room> rooms)
	{
		InitializeComponent();

		Items = new ObservableCollection<Room>(rooms);
		UpdateRoomNumbers();
		BindingContext = this;
	}

	public ObservableCollection<Room> Items { get; set; }


	private void OnDeleteSwipeItemInvokedClassic(object sender, EventArgs e)
	{
		var selectedRoom = (sender as SwipeItem).BindingContext as Room;
		if (selectedRoom != null && Items != null) {
			// Removes the selected item from the list
			Items.Remove(selectedRoom);
			UpdateRoomNumbers();
		}
	}

	private void UpdateRoomNumbers()
	{
		for (var i = 0; i < Items.Count; i++) Items[i].ListNumber = i + 1;
	}
}