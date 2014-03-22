using System.IO;

namespace BeerXml.RecipeSource
{
    public interface ILoadFromFile
    {
        Stream Stream { get; set; }
    }
}
