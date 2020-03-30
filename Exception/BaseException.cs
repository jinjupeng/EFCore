using System;
using System.Net;
using System.Runtime.Serialization;

namespace Exceptions
{
    public class BaseException : ApplicationException
    {
        public BaseException()
        {
        }


        public BaseException(string errorMessage, System.Exception innerException) : base(errorMessage, innerException)
        {
        }


        public BaseException(string errorMessage) : base(errorMessage)
        {
            this._exceptionCode = 1000;
            this._exceptionMessage = errorMessage;
        }
        public BaseException(int errorCode, string errorMessage) : base(errorMessage)
        {
            this._exceptionCode = errorCode;
            this._exceptionMessage = errorMessage;
        }

        public BaseException(HttpStatusCode errorCode, string errorMessage) : base(errorMessage)
        {
            this._exceptionCode = (int)errorCode;
            this._exceptionMessage = errorMessage;
        }

        protected BaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public virtual int ExceptionCode
        {
            get => this._exceptionCode;
            set => value = this._exceptionCode;
        }


        public virtual string ExceptionMessage
        {
            get => this._exceptionMessage;
            set => value = this._exceptionMessage;
        }





        private readonly int _exceptionCode;


        private readonly string _exceptionMessage;
	}
}