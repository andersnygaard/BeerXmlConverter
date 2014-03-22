using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using BeerXml.RecipeFormat;
using BeerXml.RecipeSource;

namespace BeerXml.Recipe
{
    public class Recipe : IRecipe
    {
        private readonly XslCompiledTransform _xsltCompiler;
        private XmlDocument _document;

        public Recipe()
        {
            _xsltCompiler = new XslCompiledTransform();
            _xsltCompiler.Load(AppDomain.CurrentDomain.BaseDirectory + System.Configuration.ConfigurationSettings.AppSettings["beerxml2json"]);
        }

        public IRecipe From(ILoadFromXml xml)
        {
            _document = xml.Document;

            return this;
        }

        public RecipeAsObject ToObject()
        {
            var nav = _document.CreateNavigator();

            var recipe = new RecipeAsObject
            {
                Name = nav.SelectSingleNode("RECIPE/NAME") == null ? "" : nav.SelectSingleNode("RECIPE/NAME").Value,
                Style = nav.SelectSingleNode("RECIPE/STYLE/NAME") == null ? "" : nav.SelectSingleNode("RECIPE/STYLE/NAME").Value,
                Color = nav.SelectSingleNode("RECIPE/COLOR") == null ? "" : nav.SelectSingleNode("RECIPE/COLOR").Value,
                Type = nav.SelectSingleNode("RECIPE/TYPE") == null ? "" : nav.SelectSingleNode("RECIPE/TYPE").Value,
                BatchSize = nav.SelectSingleNode("RECIPE/BATCH_SIZE") == null ? "" : nav.SelectSingleNode("RECIPE/BATCH_SIZE").Value,
                Efficiency = nav.SelectSingleNode("RECIPE/EFFICIENCY") == null ? "" : nav.SelectSingleNode("RECIPE/EFFICIENCY").Value,
                Og = nav.SelectSingleNode("RECIPE/OG") == null ? "" : nav.SelectSingleNode("RECIPE/OG").Value,
                Fg = nav.SelectSingleNode("RECIPE/FG") == null ? "" : nav.SelectSingleNode("RECIPE/FG").Value,
            };

            return recipe;
        }

        public RecipeAsJson ToJson()
        {
            var json = "";

            using(var writer = new StringWriter()){
                _xsltCompiler.Transform(_document, null, writer);
                json = writer.ToString();
            }

            return new RecipeAsJson(json);
        }

        public RecipeAsXml ToXml()
        {
            return new RecipeAsXml(_document);
        }
    }
}
