using RobotSdk;

namespace RobotIntegration
{

    public interface IIdentifiableRobot
    {
        string Id { get; }
        string Name { get; }
        IRobot Robot { get; }

    }

}
