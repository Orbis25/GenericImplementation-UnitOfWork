using System;

namespace GenericUnitOfWork.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    /// <summary>
    /// Only example, this is a bad practice
    /// </summary>
    public class Test
    {
        public string Grettings { get; set; }
    }
}
