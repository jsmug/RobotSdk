namespace RobotSdk
{

    public interface IRobot
    {
        void Beep();
        void Move(double distance);
        void Turn(double angle);
    }

}
