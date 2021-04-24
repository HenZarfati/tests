using System;

namespace TestProject
{
    public class Reservation
    {
        private User maidBy;
        private string ReservationToken;
        public Reservation(User user)
        {
            maidBy = user;
            Guid g = Guid.NewGuid();
            ReservationToken = Convert.ToBase64String(g.ToByteArray());
        }
        public bool IsAllowedToCancelledBy(User user)
        {
            return (user.IsAdmin || user.Id == maidBy.Id);
        }
    }
}
