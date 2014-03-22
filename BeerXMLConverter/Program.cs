using System.Linq;
using BeerXml;
using BeerXml.Recipe;
using BeerXml.RecipeSource;

namespace BeerXMLConverter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Recipes()
                .From(new RecipeSourceFromFile("beerxmlv1example.xml"))
                .ToList()
                .First()
                .ToJson()
                .Save("beerxmlv1example.json");

            new Recipes()
                .From(new RecipeSourceFromFile("beerxmlv1example.xml"))
                .ToList()
                .First()
                .ToJson()
                .Save("brewmate.json");

            new Recipes()
                .From(new RecipeSourceFromFile("beerxmlv1example.xml"))
                .ToList()
                .First()
                .ToJson()
                .Save("brewsmith.json");

            new Recipes()
                .From(new RecipeSourceFromFile("beerxmlv1example.xml"))
                .ToList()
                .First()
                .ToObject();
        }
    }
}
