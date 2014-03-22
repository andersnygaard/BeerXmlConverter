using System.Xml;

namespace BeerXml.RecipeSource
{
    public class RecipeSourceFromXml : IRecipeSource, ILoadFromXml
    {
        public XmlDocument Document { get; set; }

        public RecipeSourceFromXml(XmlDocument document)
        {
            Document = document;
        }
    }
}
