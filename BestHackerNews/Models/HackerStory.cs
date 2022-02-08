using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BestHackerNews.Models
{
    public class HackerStory
    {


        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string By { get; set; }

        public long Time { get; set; }

        public double Score { get; set; }

        public int[] Kids { get; set; }


        public HackerStoryDto ToHackerStoryDto() {
            return new HackerStoryDto()
            {
                Title = this.Title,
                Uri = this.Url,
                PostedBy = this.By,
                Time = new DateTime(this.Time),
                Score = this.Score,
                CommentsCount = this.Kids.Length
            };
        }
    }
}
