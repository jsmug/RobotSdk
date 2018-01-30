using RobotSdk;
using System;
using System.Runtime.CompilerServices;

namespace RobotIntegration
{


    // The calls to OnMethodCalled could probably
    // be investigated for better implementation
    // so boxing doesn't occur on value types.
    public class NotificationRobot : Robot
    {

        public event EventHandler<MethodSignatureEventArgs> MethodCalled;


        public NotificationRobot() : base()
        {
        }


        #region public

        public override void Beep()
        {

            base.Beep();
            OnMethodCalledCalled(null);

        }

        public override void Move(double distance)
        {

            base.Move(distance);
            OnMethodCalledCalled(new object[] { distance });

        }

        public override void Turn(double angle)
        {

            base.Turn(angle);
            OnMethodCalledCalled(new object[] { angle });

        }

        #endregion

        #region protected

        protected virtual void OnMethodCalledCalled(object[] args, [CallerMemberName] string methodName = "")
        {

            if (string.IsNullOrWhiteSpace(methodName))
            {
                throw new ArgumentNullException(nameof(methodName));
            }

            MethodCalled(this, new MethodSignatureEventArgs(methodName, args));

        }


        #endregion

    }

}
