using System.Collections.ObjectModel;
using CollectionReleaseiOS.Models;

namespace CollectionReleaseiOS.ViewModels;

public class RoomTypeViewModel : BaseViewModel
{
	/*private readonly ApiTypeService _apiTypeService;
	private readonly TypesRepository _typesRepository;

	public RoomTypeViewModel(ApiTypeService apiTypeService)
	{
		_apiTypeService = apiTypeService;
		_typesRepository = new TypesRepository();
	}*/

	public GenericListViewModel<Room, RoomType> RoomsListViewModel { get; set; } = new();

	public ObservableCollection<RoomType> RoomTypes { get; set; } = new();

	public void LoadDataOffline()
	{
		var types = new List<RoomType>
		{
			new() { Id = 1, NameFr = "Box", NameEn = "Garage" },
			new() { Id = 2, NameFr = "Cave", NameEn = "Cellar" },
			new() { Id = 3, NameFr = "Chambre", NameEn = "Bedroom" },
			new() { Id = 4, NameFr = "Comble aménagé", NameEn = "Converted attic" },
			new() { Id = 5, NameFr = "Comble non aménagé", NameEn = "Unconverted attic" },
			new() { Id = 6, NameFr = "Balcon", NameEn = "Balcony" },
			new() { Id = 7, NameFr = "Couloir", NameEn = "Hallway" },
			new() { Id = 8, NameFr = "Cuisine", NameEn = "Kitchen" },
			new() { Id = 9, NameFr = "Entrée", NameEn = "Entrance" },
			new() { Id = 10, NameFr = "Escalier", NameEn = "Staircase" },
			new() { Id = 11, NameFr = "Garage", NameEn = "Garage" },
			new() { Id = 12, NameFr = "Grenier", NameEn = "Attic" },
			new() { Id = 13, NameFr = "Local", NameEn = "Room" },
			new() { Id = 14, NameFr = "Salle de bains", NameEn = "Bathroom" },
			new() { Id = 15, NameFr = "Séjour", NameEn = "Living room" },
			new() { Id = 16, NameFr = "Remise", NameEn = "Shed" },
			new() { Id = 17, NameFr = "Sous-sol", NameEn = "Basement" },
			new() { Id = 18, NameFr = "Terrasse", NameEn = "Terrace" },
			new() { Id = 19, NameFr = "Toilette", NameEn = "Toilet" },
			new() { Id = 20, NameFr = "Réserve", NameEn = "Storage room" },
			new() { Id = 21, NameFr = "Véranda", NameEn = "Veranda" },
			new() { Id = 22, NameFr = "Salle de bains + WC", NameEn = "Bathroom with toilet" },
			new() { Id = 23, NameFr = "Séjour + Cuisine", NameEn = "Living room with kitchen" },
			new() { Id = 24, NameFr = "Bureau", NameEn = "Office" },
			new() { Id = 25, NameFr = "Salle à manger", NameEn = "Dining room" },
			new() { Id = 26, NameFr = "Loggia", NameEn = "Loggia" },
			new() { Id = 27, NameFr = "Parking", NameEn = "Parking" },
			new() { Id = 28, NameFr = "Dressing", NameEn = "Dressing room" },
			new() { Id = 29, NameFr = "Hall d'entrée", NameEn = "Entrance hall" },
			new() { Id = 30, NameFr = "Débarras", NameEn = "Storage space" }
		};

		foreach (var type in types) RoomTypes.Add(type);
	}

	public async Task LoadDataAsync()
	{
		// Try loading data from SQLite
		/*var roomTypesFromDb = await _typesRepository.GetAllRoomType();

		if (roomTypesFromDb != null && roomTypesFromDb.Any()) {
			foreach (var type in roomTypesFromDb) RoomTypes.Add(type);
		} else {
			// Load data from API
			var roomTypesFromApi = await _apiTypeService.GetRoomTypesAsync();

			if (roomTypesFromApi != null) {
				RoomTypes.Clear();
				foreach (var type in roomTypesFromApi) RoomTypes.Add(type);

				// Save data to SQLite for future use
				await _typesRepository.InsertAllRoomType(roomTypesFromApi);
			} else {*/
		LoadDataOffline();
		/*}
	}*/
	}

	// Charge les types d'item
	public async Task<GenericListViewModel<Room, RoomType>> LoadDataAndCreateViewModelAsync()
	{
		var viewModel = new GenericListViewModel<Room, RoomType>();
		foreach (var type in RoomTypes) viewModel.EntityTypes.Add(type);

		return viewModel;
	}
}
