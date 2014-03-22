using System.Xml;

namespace BeerXml.RecipeSource
{
    public interface ILoadFromXml
    {
        XmlDocument Document { get; set; }
    }
}
