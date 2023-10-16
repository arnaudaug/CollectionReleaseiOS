using System.ComponentModel;
using Newtonsoft.Json;

namespace CollectionReleaseiOS.Models;

public class Room : IListableItem, INotifyPropertyChanged
{
	private int _listNumber; // Pour mettre à jour l'ordre dans la liste

	[JsonProperty("created_at")] public DateTime? CreatedAt { get; set; }

	[JsonProperty("updated_at")] public DateTime? UpdatedAt { get; set; }

	[JsonProperty("property_id")] public int PropertyId { get; set; }

	[JsonProperty("room_type_id")] public int RoomTypeId { get; set; }
	[JsonProperty("order")] public int Order { get; set; }

	[JsonProperty("room_type")] public RoomType RoomType { get; set; }

	public string DisplayName {
		get { return Globals.CurrentLanguage == "fr" ? RoomType?.NameFr : RoomType?.NameEn; }
		set => throw new NotImplementedException();
	}

	public int Id { get; set; }

	public int ListNumber {
		get => _listNumber;
		set {
			if (_listNumber != value) {
				_listNumber = value;
				OnPropertyChanged(nameof(ListNumber));
			}
		}
	}

	public void SetEntityType(IEntityType entityType)
	{
		RoomTypeId = entityType.Id;
		RoomType = entityType as RoomType;
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected virtual void OnPropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}