using System.Xml;

namespace BeerXml.RecipeFormat
{
    public class RecipeAsXml: IRecipeFormat
    {
        public XmlDocument Document { get; set; }
    
        public RecipeAsXml(XmlDocument document)
        {
            Document = document;
        }
    }
}
