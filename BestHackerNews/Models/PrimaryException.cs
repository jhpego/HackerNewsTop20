using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BestHackerNews.Models
{
    public class ApiError
    {

        public string Type { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public ApiError(Exception ex)
        {
            Type = ex.GetType().Name;
            Message = ex.Message;
#if DEBUG
            StackTrace = ex.ToString();
#endif
        }

    }
}
