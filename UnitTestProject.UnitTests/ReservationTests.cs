using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject;

namespace UnitTestProject.UnitTests
{
    [TestClass]
    public class ReservationTests
    {
        [TestMethod]
        public void CanBeCancelledByUser_UserIsAdmin_ReturnTrue()
        {
            //Arrange
            User user = new User { IsAdmin = true, Name = "hen" };
            Reservation reservation = new Reservation(user);
            //Act
            bool result = reservation.IsAllowedToCancelledBy(user);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CanBeCancelledByUser_SameUserCancellingTheReservation_ReturnTrue()
        {
            User user = new User { Id = 1, IsAdmin = false, Name = "hen" };
            Reservation reservation = new Reservation(user);

            bool result = reservation.IsAllowedToCancelledBy(user);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CanBeCancelledByUser_DifferentUserCancellingTheReservation_ReturnFalse()
        {
            User user = new User { Id = 1, IsAdmin = false, Name = "hen" };
            User otherUser = new User { Id = 2, IsAdmin = false, Name = "jon" };
            Reservation reservation = new Reservation(user);

            bool result = reservation.IsAllowedToCancelledBy(otherUser);

            Assert.IsFalse(result);
        }
    }
}
