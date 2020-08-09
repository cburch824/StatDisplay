using System.ComponentModel;

namespace X4Foundations.Model.Engine
{
	public enum EngineSize
	{
		[Description("Extra Small")]
		xs,
		[Description("Small")]
		s,
		[Description("Medium")]
		m,
		[Description("Large")]
		l,
		[Description("Extra Large")]
		xl
	}

	public enum EngineType
	{
		allround,
		travel,
		combat,
		police,
		pv,
		buildingdrone,
		escapepod,
		repairdrone,
		spacesuit,
		Static,
		transporter
	}

	public enum EngineGrade
	{
		[Description("Mark 1")]
		mk1,
		[Description("Mark 2")]
		mk2,
		[Description("Mark 3")]
		mk3
	}

	public class EngineModel : INotifyPropertyChanged
	{
		private string _name;
		private EngineSize? _size;
		private FactionType? _faction;
		private EngineType? _type;
		private EngineGrade? _grade;
		private int? _version;
		private Properties _properties;

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

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
