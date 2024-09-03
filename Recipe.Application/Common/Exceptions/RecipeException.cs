using System.Runtime.Serialization;

namespace Recipe.Common.Exceptions
{
    public class RecipeException : Exception
    {
        public int Code { get; set; }
        public RecipeException()
        {

        }
        public RecipeException(string message) : base(message)
        {

        }
        public RecipeException(string message, Exception inner) : base(message, inner)
        {

        }
        public RecipeException(string message, int code)
            : this(message)
        {
            Code = code;
        }
    }
}
