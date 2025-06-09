using System;

namespace ClairTourTiny.Infrastructure.Exceptions
{
    public class PurchaseOrderServiceException : Exception
    {
        public PurchaseOrderServiceException(string message) : base(message) { }
        public PurchaseOrderServiceException(string message, Exception innerException) 
            : base(message, innerException) { }
    }

    public class PurchaseOrderNotFoundException : Exception
    {
        public PurchaseOrderNotFoundException(string message) : base(message) { }
        public PurchaseOrderNotFoundException(string message, Exception innerException) 
            : base(message, innerException) { }
    }

    public class PurchaseOrderValidationException : Exception
    {
        public PurchaseOrderValidationException(string message) : base(message) { }
        public PurchaseOrderValidationException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
} 