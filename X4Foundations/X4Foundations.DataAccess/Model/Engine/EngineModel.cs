using System.ComponentModel;

namespace X4Foundations.DataAccess.Model.Engine
{
	public class EngineModel : INotifyPropertyChanged
	{
		private string _name;
		private EngineSize? _size;
		private FactionType? _faction;
		private EngineType? _type;
		private EngineGrade? _grade;
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

		public EngineSize? Size
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
		public EngineType? Type
		{
			get => _type;
			set
			{
				_type = value;
				OnPropertyChanged("Type");
			}
		}
		public EngineGrade? Grade
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
