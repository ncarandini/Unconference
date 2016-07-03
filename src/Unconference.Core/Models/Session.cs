using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unconference.Core.Models
{
    public class Session
    {
        private Session()
        {
            Votes = new List<SessionVote>();
        }

        public Session(ApplicationUser proponent): this(proponent, proponent)
        {
        }

        public Session(ApplicationUser proponent, ApplicationUser moderator): this()
        {
            ProposedAt = DateTimeOffset.Now;
            SessionState = SessionState.Proposed;
            ProponentId = proponent.Id;
            ModeratorId = moderator.Id;
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public SessionState SessionState { get; private set; }

        public DateTimeOffset ProposedAt { get; private set; }

        public DateTimeOffset? CancelledAt { get; private set; }

        public int MeetupId { get; set; }

        public Meetup Meetup { get; set; }

        [ForeignKey("Proponent")]
        public string ProponentId { get; set; }

        [Required]
        public ApplicationUser Proponent { get; set; }

        [ForeignKey("Moderator")]
        public string ModeratorId { get; set; }

        [Required]
        public ApplicationUser Moderator { get; set; }

        public ICollection<SessionVote> Votes { get; set; }

        public void CancelSession(DateTimeOffset cancelledAt)
        {
            CancelledAt = cancelledAt;
            SessionState = SessionState.Cancelled;
            Meetup = null;
        }

        public void SkeduleSession(Meetup meetup)
        {
            MeetupId = meetup.Id;
            SessionState = SessionState.Skeduled;
        }

        public void CompleteSession()
        {
            SessionState = SessionState.Done;
        }

    }
}
