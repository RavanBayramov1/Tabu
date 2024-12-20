namespace Tabu.Exceptions.Word
{
    public class WordCustomException : Exception, IBaseException
    {
        public int StatusCode => throw new NotImplementedException();

        public string ErrorMessage => throw new NotImplementedException();
    }
}
