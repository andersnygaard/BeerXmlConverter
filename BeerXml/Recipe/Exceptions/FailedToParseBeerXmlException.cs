using System;

namespace BeerXml.Recipe.Exceptions
{
    public class FailedToParseBeerXmlException : Exception
    {
        public FailedToParseBeerXmlException(string message) : base(message)
        {
        }
    }
}
