using System.ComponentModel;

namespace X4Foundations.Model.WeaponSystem
{
	public class WeaponModel : IWeaponSystemModel, INotifyPropertyChanged
	{
		private string _name;
		private WeaponSystemSize? _size;
		private WeaponSystemClass? _class;
		private FactionType? _faction;
		private WeaponSystemType? _type;
		private WeaponSystemGrade? _grade;
		private int? _version;
		private char? _versionLetter;
		private Properties _properties;

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

		public WeaponSystemSize? Size
		{
			get => _size;
			set
			{
				_size = value;
				OnPropertyChanged("Size");
			}
		}

		public WeaponSystemClass? Class
		{
			get => _class;
			set
			{
				_class = value;
				OnPropertyChanged("Class");
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

		public WeaponSystemType? Type
		{
			get => _type;
			set
			{
				_type = value;
				OnPropertyChanged("Type");
			}
		}

		public WeaponSystemGrade? Grade
		{
			get => _grade;
			set
			{
				_grade = value;
				OnPropertyChanged("Size");
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

		public Properties Properties
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
