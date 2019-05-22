namespace AppSlider.Domain
{
    using System;
    using System.Collections.Generic;

    public class BusinessException : Exception
    {
        public List<String> Messages { get; set; }

        public String Orign { get; set; }

        public Boolean IsError { get; set; }

        public BusinessException()
        { }

        public BusinessException(String message, String orign = null, Boolean isError = true)
            : base(message)
        {
            IsError = isError;
            Orign = orign;
        }

        public BusinessException(String message, Exception innerException, String orign)
            : base(message, innerException)
        {
            Orign = orign;
            Messages = Messages ?? new List<string>();

            Messages.Add(message);
            Messages.Add(innerException?.Message ?? "");
        }

        public BusinessException(String message, List<String> detailsFromMessage, String orign = null) : base(message)
        {
            this.Messages = detailsFromMessage;
            this.Orign = orign;
        }
    }
}
