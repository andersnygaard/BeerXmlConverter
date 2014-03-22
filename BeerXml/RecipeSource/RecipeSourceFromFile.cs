using System.IO;
using System.Web;

namespace BeerXml.RecipeSource
{
    public class RecipeSourceFromFile : IRecipeSource, ILoadFromFile
    {
        public Stream Stream { get; set; }

        public RecipeSourceFromFile(string path)
        {
            Stream = new FileStream(path, FileMode.Open);
        }

        public RecipeSourceFromFile(HttpPostedFileBase file)
        {
            Stream = file.InputStream;
        }
    }
}
