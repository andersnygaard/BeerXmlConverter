using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Moq;

namespace BeerXml.Tests.Fake
{
    public static class WebContextWithPostedFile
    {
        public static HttpRequestBase Create()
        {
            var stream = new FileStream("Assets/beerxmlv1example.xml", FileMode.Open);
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var files = new Mock<HttpFileCollectionBase>();
            var file = new Mock<HttpPostedFileBase>();
            context.Setup(x => x.Request).Returns(request.Object);

            file.Setup(x => x.InputStream).Returns(stream);
            file.Setup(x => x.ContentLength).Returns((int)stream.Length);
            file.Setup(x => x.FileName).Returns(stream.Name);

            files.Setup(x => x.Count).Returns(1);
            files.Setup(x => x.Get(0).InputStream).Returns(file.Object.InputStream);

            request.Setup(x => x.Files).Returns(files.Object);
            request.Setup(x => x.Files[0]).Returns(file.Object);

            return request.Object;
        }
    }
}
