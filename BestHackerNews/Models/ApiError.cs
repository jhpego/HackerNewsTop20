using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BestHackerNews.Models
{
    [Serializable]
    public class PrimaryException : Exception
    {
        public PrimaryException()
        { }

        public PrimaryException(string message)
            : base(message)
        { }

        public PrimaryException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
