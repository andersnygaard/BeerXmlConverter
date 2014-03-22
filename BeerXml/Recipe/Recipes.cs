using System;
using System.Collections.Generic;
using System.Xml;
using BeerXml.Recipe.Exceptions;
using BeerXml.RecipeSource;

namespace BeerXml.Recipe
{
    public class Recipes : IRecipes
    {
        private XmlDocument _document;

        public IList<IRecipe> ToList()
        {
            if (_document == null)
                throw new FailedToParseBeerXmlException("Unable to parse recipe");

            var recipeNodes = _document.SelectNodes("//RECIPES/RECIPE");

            if(recipeNodes == null)
                throw new FailedToParseBeerXmlException("No recipes found");

            var list = new List<IRecipe>();

            foreach (XmlNode animalNode in recipeNodes)
            {
                var document = new XmlDocument();
                var targetNode = document.ImportNode(animalNode, true);
                document.AppendChild(targetNode);

                list.Add(new Recipe().From(new RecipeSourceFromXml(document)));
            }

            return list;
        }

        public IRecipes From(ILoadFromFile file)
        {
            using(var stream = file.Stream){
                _document = new XmlDocument();
                _document.Load(stream);
            }
            
            return this;
        }
    }
}
