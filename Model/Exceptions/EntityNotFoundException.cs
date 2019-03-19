using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Exceptions
{
    public class EntityNotFoundException : Exception // не найдено что??? record? params table, id? логирование ошибок где?
    {
        private readonly string[] _errors;

        public EntityNotFoundException(params string[] errors)
        {
            this._errors = errors;
        }
        public EntityNotFoundException(string message)
            : base(message)
        {
        }
        public EntityNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        public string[] GetMessages()
        {
            return _errors;
        }
    }
}
