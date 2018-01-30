using RobotIntegration;

namespace Robot.UnitTests
{

    // This is to prevent the actual robot from 
    // being called while at the same time
    // allowing us to test cached methods
    public class MockNotificationRobot :  NotificationRobot
    {

        public MockNotificationRobot() : base()
        {
        }


        #region public

        public override void Beep()
        {
            OnMethodCalledCalled(null);
        }

        public override void Move(double distance)
        {
            OnMethodCalledCalled(new object[] { distance });
        }

        public override void Turn(double angle)
        {
            OnMethodCalledCalled(new object[] { angle });
        }

        #endregion

    }

}
