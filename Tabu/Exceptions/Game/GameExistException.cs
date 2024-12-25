namespace Tabu.Exceptions.Game
{
    public class GameExistException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }
        public GameExistException()
        {
            ErrorMessage = "Game already added database!";
        }
        public GameExistException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}

