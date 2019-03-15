using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Exceptions
{
    class RecordNotFoundException : Exception // не найдено что??? record? params table, id? логирование ошибок где?
    {
        private readonly string[] _errors;

        public RecordNotFoundException(params string[] errors)
        {
            this._errors = errors;
        }
        public RecordNotFoundException(string message)
            : base(message)
        {
        }
        public RecordNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        public string[] GetMessages()
        {
            return _errors;
        }
    }
}
