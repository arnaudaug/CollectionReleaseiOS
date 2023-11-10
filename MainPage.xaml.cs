using System.Collections.ObjectModel;
using Newtonsoft.Json;
using CollectionReleaseiOS.Models;
using CollectionReleaseiOS.Views.Generic;
using CollectionReleaseiOS.ViewModels;

namespace CollectionReleaseiOS;

public partial class MainPage : ContentPage
{
	int count = 0;
	private ObservableCollection<Room> _rooms = new();

	public ObservableCollection<Room> Rooms {
		get => _rooms;
		set {
			if (_rooms != value) {
				_rooms = value;
				OnPropertyChanged();
			}
		}
	}

	public MainPage()
	{
		InitializeComponent();
	}
	
	private async void NavigateEditListPageTry1(object sender, EventArgs e)
	{
		var json = "{\"id\":5,\"address\":\"68316 Klein Lake Apt. 826\\nShyannetown, NV 52467\",\"description\":\"Quasi ut dicta sunt ipsa maiores qui. Deleniti veritatis quos et tempore nihil. Consequatur est neque consequatur et minima explicabo et quibusdam.\",\"price\":397810,\"bedroom\":0,\"bathroom\":1,\"size\":115,\"created_at\":\"2023-08-11T16:05:19.000000Z\",\"updated_at\":\"2023-08-11T16:05:19.000000Z\",\"locagest_id\":0,\"agency_id\":1,\"property_type_id\":11,\"property_model_id\":null,\"rooms\":[{\"id\":94,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":14,\"order\":0,\"room_type\":{\"id\":14,\"name_fr\":\"Salle de bains\",\"name_en\":\"Bathroom\",\"created_at\":null,\"updated_at\":null}},{\"id\":95,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":3,\"order\":0,\"room_type\":{\"id\":3,\"name_fr\":\"Chambre\",\"name_en\":\"Bedroom\",\"created_at\":null,\"updated_at\":null}},{\"id\":96,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":5,\"order\":0,\"room_type\":{\"id\":5,\"name_fr\":\"Comble non am\u00E9nag\u00E9\",\"name_en\":\"Unconverted attic\",\"created_at\":null,\"updated_at\":null}},{\"id\":97,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":7,\"order\":0,\"room_type\":{\"id\":7,\"name_fr\":\"Couloir\",\"name_en\":\"Hallway\",\"created_at\":null,\"updated_at\":null}},{\"id\":98,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":9,\"order\":0,\"room_type\":{\"id\":9,\"name_fr\":\"Entr\u00E9e\",\"name_en\":\"Entrance\",\"created_at\":null,\"updated_at\":null}},{\"id\":99,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":1,\"order\":0,\"room_type\":{\"id\":1,\"name_fr\":\"Box\",\"name_en\":\"Garage\",\"created_at\":null,\"updated_at\":null}},{\"id\":100,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":15,\"order\":0,\"room_type\":{\"id\":15,\"name_fr\":\"S\u00E9jour\",\"name_en\":\"Living room\",\"created_at\":null,\"updated_at\":null}},{\"id\":101,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":8,\"order\":0,\"room_type\":{\"id\":8,\"name_fr\":\"Cuisine\",\"name_en\":\"Kitchen\",\"created_at\":null,\"updated_at\":null}}]}";
		var property = JsonConvert.DeserializeObject<Property>(json);
		var rooms = property.Rooms;

		if (rooms != null) {
			Rooms.Clear();
			foreach (var room in rooms) Rooms.Add(room);

			try {
				var roomTypeViewModel = new RoomTypeViewModel();
				var loadedViewModel = await roomTypeViewModel.LoadDataAndCreateViewModelAsync();
				loadedViewModel.Items = new ObservableCollection<Room>(rooms);
				var genericListPage = new ListPageTry1<Room, RoomType>(loadedViewModel) {
					Callback = ReturnData
				};
				// Crash in Invoked property in SwipeView of ItemsCollectionView
				await Navigation.PushAsync(genericListPage);
			} catch (Exception ex) {
				Console.WriteLine($"Exception: {ex}");
				await Application.Current.MainPage.DisplayAlert("Stop", $"Exception: {ex}", "OK");
			}
		}
	}
	
		private async void NavigateEditListPageTry2(object sender, EventArgs e)
	{
		var json = "{\"id\":5,\"address\":\"68316 Klein Lake Apt. 826\\nShyannetown, NV 52467\",\"description\":\"Quasi ut dicta sunt ipsa maiores qui. Deleniti veritatis quos et tempore nihil. Consequatur est neque consequatur et minima explicabo et quibusdam.\",\"price\":397810,\"bedroom\":0,\"bathroom\":1,\"size\":115,\"created_at\":\"2023-08-11T16:05:19.000000Z\",\"updated_at\":\"2023-08-11T16:05:19.000000Z\",\"locagest_id\":0,\"agency_id\":1,\"property_type_id\":11,\"property_model_id\":null,\"rooms\":[{\"id\":94,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":14,\"order\":0,\"room_type\":{\"id\":14,\"name_fr\":\"Salle de bains\",\"name_en\":\"Bathroom\",\"created_at\":null,\"updated_at\":null}},{\"id\":95,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":3,\"order\":0,\"room_type\":{\"id\":3,\"name_fr\":\"Chambre\",\"name_en\":\"Bedroom\",\"created_at\":null,\"updated_at\":null}},{\"id\":96,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":5,\"order\":0,\"room_type\":{\"id\":5,\"name_fr\":\"Comble non am\u00E9nag\u00E9\",\"name_en\":\"Unconverted attic\",\"created_at\":null,\"updated_at\":null}},{\"id\":97,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":7,\"order\":0,\"room_type\":{\"id\":7,\"name_fr\":\"Couloir\",\"name_en\":\"Hallway\",\"created_at\":null,\"updated_at\":null}},{\"id\":98,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":9,\"order\":0,\"room_type\":{\"id\":9,\"name_fr\":\"Entr\u00E9e\",\"name_en\":\"Entrance\",\"created_at\":null,\"updated_at\":null}},{\"id\":99,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":1,\"order\":0,\"room_type\":{\"id\":1,\"name_fr\":\"Box\",\"name_en\":\"Garage\",\"created_at\":null,\"updated_at\":null}},{\"id\":100,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":15,\"order\":0,\"room_type\":{\"id\":15,\"name_fr\":\"S\u00E9jour\",\"name_en\":\"Living room\",\"created_at\":null,\"updated_at\":null}},{\"id\":101,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":8,\"order\":0,\"room_type\":{\"id\":8,\"name_fr\":\"Cuisine\",\"name_en\":\"Kitchen\",\"created_at\":null,\"updated_at\":null}}]}";
		var property = JsonConvert.DeserializeObject<Property>(json);
		var rooms = property.Rooms;

		if (rooms != null) {
			Rooms.Clear();
			foreach (var room in rooms) Rooms.Add(room);

			try {
				var roomTypeViewModel = new RoomTypeViewModel();
				var loadedViewModel = await roomTypeViewModel.LoadDataAndCreateViewModelAsync();
				loadedViewModel.Items = new ObservableCollection<Room>(rooms);
				var genericListPage = new ListPageTry2<Room, RoomType>(loadedViewModel) {
					Callback = ReturnData
				};
				// Crash in Invoked property in SwipeView of ItemsCollectionView
				await Navigation.PushAsync(genericListPage);
			} catch (Exception ex) {
				Console.WriteLine($"Exception: {ex}");
				await Application.Current.MainPage.DisplayAlert("Stop", $"Exception: {ex}", "OK");
			}
		}
	}

	private async void NavigateEditListPageClassic(object sender, EventArgs e)
	{
		var json = "{\"id\":5,\"address\":\"68316 Klein Lake Apt. 826\\nShyannetown, NV 52467\",\"description\":\"Quasi ut dicta sunt ipsa maiores qui. Deleniti veritatis quos et tempore nihil. Consequatur est neque consequatur et minima explicabo et quibusdam.\",\"price\":397810,\"bedroom\":0,\"bathroom\":1,\"size\":115,\"created_at\":\"2023-08-11T16:05:19.000000Z\",\"updated_at\":\"2023-08-11T16:05:19.000000Z\",\"locagest_id\":0,\"agency_id\":1,\"property_type_id\":11,\"property_model_id\":null,\"rooms\":[{\"id\":94,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":14,\"order\":0,\"room_type\":{\"id\":14,\"name_fr\":\"Salle de bains\",\"name_en\":\"Bathroom\",\"created_at\":null,\"updated_at\":null}},{\"id\":95,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":3,\"order\":0,\"room_type\":{\"id\":3,\"name_fr\":\"Chambre\",\"name_en\":\"Bedroom\",\"created_at\":null,\"updated_at\":null}},{\"id\":96,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":5,\"order\":0,\"room_type\":{\"id\":5,\"name_fr\":\"Comble non am\u00E9nag\u00E9\",\"name_en\":\"Unconverted attic\",\"created_at\":null,\"updated_at\":null}},{\"id\":97,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":7,\"order\":0,\"room_type\":{\"id\":7,\"name_fr\":\"Couloir\",\"name_en\":\"Hallway\",\"created_at\":null,\"updated_at\":null}},{\"id\":98,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":9,\"order\":0,\"room_type\":{\"id\":9,\"name_fr\":\"Entr\u00E9e\",\"name_en\":\"Entrance\",\"created_at\":null,\"updated_at\":null}},{\"id\":99,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":1,\"order\":0,\"room_type\":{\"id\":1,\"name_fr\":\"Box\",\"name_en\":\"Garage\",\"created_at\":null,\"updated_at\":null}},{\"id\":100,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":15,\"order\":0,\"room_type\":{\"id\":15,\"name_fr\":\"S\u00E9jour\",\"name_en\":\"Living room\",\"created_at\":null,\"updated_at\":null}},{\"id\":101,\"created_at\":\"2023-10-07T16:19:31.000000Z\",\"updated_at\":\"2023-10-07T16:19:31.000000Z\",\"property_id\":5,\"room_type_id\":8,\"order\":0,\"room_type\":{\"id\":8,\"name_fr\":\"Cuisine\",\"name_en\":\"Kitchen\",\"created_at\":null,\"updated_at\":null}}]}";
		var property = JsonConvert.DeserializeObject<Property>(json);
		var rooms = property.Rooms;
		
		if (rooms != null) {
			Rooms.Clear();
			foreach (var room in rooms) Rooms.Add(room);

			try {
				var roomTypeViewModel = new RoomTypeViewModel();
				var loadedViewModel = await roomTypeViewModel.LoadDataAndCreateViewModelAsync();
				loadedViewModel.Items = new ObservableCollection<Room>(rooms);
				var genericListPage = new ListPageClassic2(rooms);
				await Navigation.PushAsync(genericListPage);
			} catch (Exception ex) {
				Console.WriteLine($"Exception: {ex}");
				await Application.Current.MainPage.DisplayAlert("Stop", $"Exception: {ex}", "OK");
			}
		}
	}

	private async void ReturnData(List<Room> items)
	{
		if (items == null)
			// Handle the case where items is null
			return;

		var text = "";

		foreach (var item in items) text += item.DisplayName + "\n";
		if (Application.Current != null && Application.Current.MainPage != null)
			await Application.Current.MainPage.DisplayAlert("Stop", text, "OK");
	}
}
