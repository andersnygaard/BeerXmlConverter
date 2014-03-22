using System.IO;
using BeerXml.RecipeSource;

namespace BeerXml.RecipeFormat
{
    public class RecipeAsJson : ISaveToFile, IRecipeSource
    {
        public string Json { get; set; }

        public RecipeAsJson(string json)
        {
            Json = json;
        }

        public byte[] ToByteArray()
        {
            var bytes = new byte[Json.Length * sizeof(char)];
            System.Buffer.BlockCopy(Json.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public void Save(string path)
        {
            using (var writer = new StreamWriter(path))
            {
                writer.Write(Json);
            }
        }
    }
}
