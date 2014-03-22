using System.Collections.Generic;
using BeerXml.RecipeSource;

namespace BeerXml.Recipe
{
    public interface IRecipes
    {
        IRecipes From(ILoadFromFile file);
        IList<IRecipe> ToList();
    }
}
