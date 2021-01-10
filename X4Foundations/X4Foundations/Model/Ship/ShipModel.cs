using System.ComponentModel;

namespace X4Foundations.Model.Ship
{
	public class ShipModel
	{
		private string _name;
		private ShipSize? _size;
		private FactionType? _faction;
		private ShipType? _shipType;
		private int? _version;
		private char? _versionLetter;
		private Properties.Properties _properties;

		#region Properties
		public string Name
		{
			get => _name;
			set
			{
				_name = value;
				OnPropertyChanged("Name");
			}
		}

		public ShipSize? Size
		{
			get => _size;
			set
			{
				_size = value;
				OnPropertyChanged("Size");
			}
		}
		public FactionType? Faction
		{
			get => _faction;
			set
			{
				_faction = value;
				OnPropertyChanged("Faction");
			}
		}
		public ShipType? Type
		{
			get => _shipType;
			set
			{
				_shipType = value;
				OnPropertyChanged("Type");
			}
		}
		public int? Version
		{
			get => _version;
			set
			{
				_version = value;
				OnPropertyChanged("Version");
			}
		}
		public char? VersionLetter
		{
			get => _versionLetter;
			set
			{
				_versionLetter = value;
				OnPropertyChanged("VersionLetter");
			}
		}
		public Properties.Properties Properties
		{
			get => _properties;
			set
			{
				_properties = value;
				OnPropertyChanged("Properties");
			}
		}
		#endregion Properties

		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion INotifyPropertyChanged
	}
}
