﻿namespace Tabu.Exceptions.Word
{
    public class InvalidBannedWordCountException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status400BadRequest;

        public string ErrorMessage { get; }
        public InvalidBannedWordCountException()
        {
            ErrorMessage = "Banned word count must be equal to 8!";
        }
        public InvalidBannedWordCountException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
