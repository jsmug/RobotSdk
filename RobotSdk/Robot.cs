using System;

namespace RobotSdk
{

    // I took the liberty of assuming the
    // concrete class in the SDK had virtual 
    // methods available.
    public class Robot : IRobot
    {

        public Robot()
        {
        }


        #region public

        public virtual void Beep()
        {
            Console.Beep();
        }

        public virtual void Move(double distance)
        {
            Console.WriteLine($"Robot moved {distance} units.");
        }

        public virtual void Turn(double angle)
        {
            Console.WriteLine($"Robot turned {angle} degrees.");
        }

        #endregion

    }

}
