using System;

namespace PizzariaUDS.Exceptions
{
    public class BusinessExcpetion : Exception
    {
        public BusinessExcpetion(string message)
            : base(message)
        {
        }
    }
}
