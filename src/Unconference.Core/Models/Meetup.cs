using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unconference.Core.Models
{
    public class Meetup
    {
        private Meetup()
        {
            Sessions = new List<Session>();
        }

        public Meetup(string title, string description, DateTimeOffset startAt, DateTimeOffset endAt): this()
        {
            Title = title;
            Description = description;
            StartAt = startAt;
            EndAt = endAt;
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTimeOffset StartAt { get; set; }

        [Required]
        public DateTimeOffset EndAt { get; set; }

        public ICollection<Session> Sessions { get; set; }
    }
}
