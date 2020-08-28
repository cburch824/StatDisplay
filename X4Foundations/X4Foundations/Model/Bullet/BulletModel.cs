using System.ComponentModel;

namespace X4Foundations.Model.Bullet
{
	public class BulletModel : INotifyPropertyChanged
	{
		private string _name;
		private BulletSize? _size;
		private FactionType? _faction;
		private BulletType? _type;
		private BulletGrade? _grade;
		private BulletWeaponType? _weaponType;
		private int? _version;
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

		public BulletSize? Size
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
		public BulletType? Type
		{
			get => _type;
			set
			{
				_type = value;
				OnPropertyChanged("Type");
			}
		}
		public BulletGrade? Grade
		{
			get => _grade;
			set
			{
				_grade = value;
				OnPropertyChanged("Size");
			}
		}
		public BulletWeaponType? WeaponType
		{
			get => _weaponType;
			set
			{
				_weaponType = value;
				OnPropertyChanged("WeaponType");
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
