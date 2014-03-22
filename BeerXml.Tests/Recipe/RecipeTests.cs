using System.Linq;
using BeerXml.Recipe;
using BeerXml.RecipeSource;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeerXml.Tests.Recipe
{
    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        public void Read_From_Uploaded_File()
        {
            var request = Fake.WebContextWithPostedFile.Create();

            var list = new Recipes()
                .From(new RecipeSourceFromFile(request.Files[0]))
                .ToList();

            Assert.IsTrue(list.Count == 4);
        }

        [TestMethod]
        public void Convert_From_File_To_Json()
        {
            var request = Fake.WebContextWithPostedFile.Create();

            var json = new Recipes()
                .From(new RecipeSourceFromFile(request.Files[0]))
                .ToList()
                .First()
                .ToJson();

            Assert.IsTrue(json.Json.Length > 0);
        }

        [TestMethod]
        public void Convert_From_File_To_Object()
        {
            var request = Fake.WebContextWithPostedFile.Create();

            var recipe = new Recipes()
                .From(new RecipeSourceFromFile(request.Files[0]))
                .ToList()
                .First()
                .ToObject();

            Assert.IsTrue(recipe.Name == "Burton Ale");
            Assert.IsTrue(recipe.Style == "English Pale Ale");
            Assert.IsTrue(recipe.Type == "All Grain");
            Assert.IsTrue(recipe.Efficiency == "72.0");
            Assert.IsTrue(recipe.Color == "");
            Assert.IsTrue(recipe.BatchSize == "18.92716800");
            Assert.IsTrue(recipe.Og == "1.05400000");
            Assert.IsTrue(recipe.Fg == "1.01500000");
        }
    }
}
