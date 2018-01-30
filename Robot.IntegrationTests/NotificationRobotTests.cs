using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotIntegration;
using System;
using System.Linq;

namespace Robot.IntegrationTests
{

    [TestClass]
    public class NotificationRobotTests
    {

        public NotificationRobotTests()
        {
        }


        #region public

        [TestMethod, TestCategory(Constants.TestCategory)]
        public void Raises_BeepCalled_Success()
        {

            NotificationRobot notificationRobot = new NotificationRobot();
            bool beepCalled = false;

            notificationRobot.MethodCalled += (s, e) => beepCalled = e.MethodSignature.MethodName.Equals(nameof(notificationRobot.Beep), StringComparison.Ordinal);
            notificationRobot.Beep();

            Assert.IsTrue(beepCalled);

        }

        [TestMethod, TestCategory(Constants.TestCategory)]
        public void Raises_MoveCalled_Success()
        {

            NotificationRobot notificationRobot = new NotificationRobot();
            double moveDistance = 0;

            notificationRobot.MethodCalled += (s, e) =>
            {

                if (e.MethodSignature.MethodName.Equals(nameof(notificationRobot.Move), StringComparison.Ordinal))
                {
                    double.TryParse(e.MethodSignature.Arguments.First().ToString(), out moveDistance);
                }

            };

            notificationRobot.Move(Constants.MoveDistance);
            Assert.IsTrue(moveDistance == Constants.MoveDistance);

        }

        [TestMethod, TestCategory(Constants.TestCategory)]
        public void Raises_TurnCalled_Success()
        {

            NotificationRobot notificationRobot = new NotificationRobot();
            double turnAngle = 0;

            notificationRobot.MethodCalled += (s, e) =>
            {

                if (e.MethodSignature.MethodName.Equals(nameof(notificationRobot.Turn), StringComparison.Ordinal))
                {
                    double.TryParse(e.MethodSignature.Arguments.First().ToString(), out turnAngle);
                }

            };

            notificationRobot.Turn(Constants.TurnAngle);
            Assert.IsTrue(turnAngle == Constants.TurnAngle);

        }

        #endregion

    }

}
