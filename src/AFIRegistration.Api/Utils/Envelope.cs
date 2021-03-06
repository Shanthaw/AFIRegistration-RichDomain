﻿using System;

namespace AFIRegistration.Api.Utils
{
    public class Envelope<T>
    {
        public T Result { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime TimeGenerated { get; set; }

        protected internal Envelope(T result, string errorMessage)
        {
            Result = result;
            ErrorMessage = errorMessage;
            TimeGenerated = DateTime.UtcNow;
        }
    }
    public class Envelope : Envelope<string>
    {
        protected internal Envelope(string errorMessage)
            : base(null, errorMessage)
        {
        }
        public static Envelope Ok()
        {
            return new Envelope(null);
        }
        public static Envelope<T> Ok<T>(T result)
        {
            return new Envelope<T>(result, null);
        }
        public static Envelope Error(string errorMessage)
        {
            return new Envelope(errorMessage);
        }
    }
}
