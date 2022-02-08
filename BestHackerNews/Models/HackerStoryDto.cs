using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BestHackerNews.Models
{
    public class HackerStoryDto
    {

        public string Title { get; set; }

        public string Uri { get; set; }

        public string PostedBy { get; set; }

        public DateTime Time { get; set; }

        public double Score { get; set; }

        public int CommentsCount { get; set; }

    }
}
