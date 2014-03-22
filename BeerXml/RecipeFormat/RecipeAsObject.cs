using BeerXml.RecipeSource;

namespace BeerXml.RecipeFormat
{
    public class RecipeAsObject : IRecipeSource
    {
        public string Name { get; set; }
        public string Style { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public string BatchSize { get; set; }
        public string Efficiency { get; set; }
        public string Og { get; set; }
        public string Fg { get; set; }
    }
}
