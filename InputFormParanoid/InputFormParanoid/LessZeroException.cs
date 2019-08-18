using System;

namespace InputFormParanoid
{
    class LessZeroException : SystemException
    {
        private readonly string message;

        public LessZeroException(string message) : base(message)
        {
            this.message = message;
        }

        public override string Message => $"У поля {message} введёно значение меньше 0.";
    }
}
