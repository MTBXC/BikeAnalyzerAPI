using System.Runtime.Serialization;

namespace BikeAnalyzerAPI.Services
{
    class BadRequestException : Exception
    {
       public BadRequestException(string message) : base(message)
        {

        }
    }
}