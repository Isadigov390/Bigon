namespace Bigon.Infrastructure.Exceptions
{
    public class CircleReferenceException : Exception
    {
        public CircleReferenceException(string propertyName)
            :base($"Circle reference occured by {propertyName}")
        {
            
        }
    }
}
