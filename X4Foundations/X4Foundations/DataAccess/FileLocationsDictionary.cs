using System.Collections.Generic;

namespace X4Foundations.DataAccess
{
	public class FileLocationsDictionary
	{
		private readonly string _languageId;

		public FileLocationsDictionary(int languageId = 44)
		{
			_languageId = languageId.ToString("###");
		}

		public Dictionary<FileLocationName, string> FileLocationsByName = new Dictionary<FileLocationName, string>
		{
			//todo - make this dynamic so it picks up from the variable
			{FileLocationName.TextReferences, $@"C:\Program Files (x86)\Steam\steamapps\common\X4 Foundations\unpacked\t\0001-l044.xml"}
		};
	}

	public enum FileLocationName
	{
		TextReferences
	}
}
