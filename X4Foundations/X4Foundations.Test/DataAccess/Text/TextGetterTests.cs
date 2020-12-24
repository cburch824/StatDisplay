
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using X4Foundations.DataAccess.Text;
using X4Foundations.Model.Text;
using Xunit;

namespace X4Foundations.Test.DataAccess.Text
{
	public class TextGetterTests
	{
		private const string BaseFolderPath = @"DataAccess\TestData\Text";

		[Fact]
		public void GetShipTextReferences_ReturnsExpectedValues()
		{
			TextGetter textGetter = new TextGetter($@"{BaseFolderPath}\TextReferencesMinimal.xml");
			List<TextReference> shipTextReferences = textGetter.GetShipTextReferences().ToList();

			Assert.Equal("Discoverer", shipTextReferences[0].Value);
			Assert.Equal("10101", shipTextReferences[0].Id);
			Assert.Equal("Discoverer Vanguard", shipTextReferences[1].Value);
			Assert.Equal("10102", shipTextReferences[1].Id);
			Assert.Equal("Discoverer Sentinel", shipTextReferences[2].Value);
			Assert.Equal("10103", shipTextReferences[2].Id);

			Assert.Equal("Buster", shipTextReferences[3].Value);
			Assert.Equal("10201", shipTextReferences[3].Id);
			Assert.Equal("Buster Vanguard", shipTextReferences[4].Value);
			Assert.Equal("10202", shipTextReferences[4].Id);
			Assert.Equal("Buster Sentinel", shipTextReferences[5].Value);
			Assert.Equal("10203", shipTextReferences[5].Id);

			Assert.Equal("Nova", shipTextReferences[6].Value);
			Assert.Equal("10301", shipTextReferences[6].Id);
			Assert.Equal("Nova Vanguard", shipTextReferences[7].Value);
			Assert.Equal("10302", shipTextReferences[7].Id);
			Assert.Equal("Nova Sentinel", shipTextReferences[8].Value);
			Assert.Equal("10303", shipTextReferences[8].Id);

			Assert.Equal("Eclipse", shipTextReferences[9].Value);
			Assert.Equal("10401", shipTextReferences[9].Id);
			Assert.Equal("Eclipse Vanguard", shipTextReferences[10].Value);
			Assert.Equal("10402", shipTextReferences[10].Id);
			Assert.Equal("Eclipse Sentinel", shipTextReferences[11].Value);
			Assert.Equal("10403", shipTextReferences[11].Id);
		}
	}
}
