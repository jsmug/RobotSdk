using RobotSdk;
using System;
using System.Linq;
using System.Reflection;

namespace RobotIntegration
{
    public static class RobotExtensions
    {

        public static void Replay(this IRobot robot, MethodSignature cachedMethod)
        {

            if (robot == null)
            {
                throw new ArgumentNullException(nameof(robot));
            }

            if (cachedMethod == null)
            {
                throw new ArgumentNullException(nameof(cachedMethod));
            }

            MethodInfo method = robot.GetType().GetMethod(cachedMethod.MethodName);

            if (method != null)
            {
                method.Invoke(robot, cachedMethod.Arguments.ToArray());
            }

        }

    }

}
