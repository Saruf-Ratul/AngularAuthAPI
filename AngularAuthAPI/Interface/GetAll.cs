using System.Runtime.Serialization;

namespace AngularAuthAPI.Interface
{
    [Serializable]
    internal class GetAll : Exception
    {
        public GetAll()
        {
        }

        public GetAll(string? message) : base(message)
        {
        }

        public GetAll(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected GetAll(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}