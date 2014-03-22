using BeerXml.RecipeFormat;
using BeerXml.RecipeSource;

namespace BeerXml.Recipe
{
    public interface IRecipe
    {
        RecipeAsJson ToJson();
        RecipeAsObject ToObject();
        RecipeAsXml ToXml();
        IRecipe From(ILoadFromXml xml);
    }
}
