using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotIntegration;
using RobotSdk;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Robot.UnitTests
{

    [TestClass]
    public class CachedMethodTests
    {

        public CachedMethodTests()
        {
        }


        #region public

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {

            // Initialize Robots
            Robots = new Dictionary<string, IIdentifiableRobot>();
            //Initialize in memory methods
            RobotMethodCache = new Dictionary<string, List<MethodSignature>>();
            string id = null;
            MockNotificationRobot mockRobot = null;

            for (int i = 0; i < Constants.NumberOfTestRobots; i++)
            {

                id = Guid.NewGuid().ToString();
                mockRobot = new MockNotificationRobot();

                RobotMethodCache[id] = new List<MethodSignature>();

                mockRobot.MethodCalled += (s, e) =>
                {

                    IIdentifiableRobot robot = Robots.Values.FirstOrDefault(x => x.Robot == s);

                    if (robot != null)
                    {
                        RobotMethodCache[robot.Id].Add(e.MethodSignature);
                    }
                    
                };

                Robots[id] = new IdentifiableRobot(id, Guid.NewGuid().ToString(), mockRobot);

            }

        }

        [TestMethod, TestCategory(Constants.TestCategory)]
        public void Cache_Beep_Success()
        {

            Random random = new Random(Environment.TickCount);
            int robot1Index = random.Next(Constants.NumberOfTestRobots);

            IIdentifiableRobot identifiableRobot1 = Robots[Robots.Keys.ElementAt(robot1Index)];
            Mock<IRobot> mockRobot = new Mock<IRobot>();

            mockRobot.Setup(x => x.Beep());

            identifiableRobot1.Robot.Beep();
            mockRobot.Object.Replay(RobotMethodCache[identifiableRobot1.Id].LastOrDefault());

            mockRobot.Verify(x => x.Beep(), Times.Once);

        }

        [TestMethod, TestCategory(Constants.TestCategory)]
        public void Cache_Move_Success()
        {

            Random random = new Random(Environment.TickCount);
            int robot1Index = random.Next(Constants.NumberOfTestRobots);

            IIdentifiableRobot identifiableRobot1 = Robots[Robots.Keys.ElementAt(robot1Index)];
            Mock<IRobot> mockRobot = new Mock<IRobot>();

            mockRobot.Setup(x => x.Move(Constants.MoveDistance));

            identifiableRobot1.Robot.Move(Constants.MoveDistance);
            mockRobot.Object.Replay(RobotMethodCache[identifiableRobot1.Id].LastOrDefault());

            mockRobot.Verify(x => x.Move(Constants.MoveDistance), Times.Once);

        }

        [TestMethod, TestCategory(Constants.TestCategory)]
        public void Cache_Turn_Success()
        {

            Random random = new Random(Environment.TickCount);
            int robot1Index = random.Next(Constants.NumberOfTestRobots);

            IIdentifiableRobot identifiableRobot1 = Robots[Robots.Keys.ElementAt(robot1Index)];
            Mock<IRobot> mockRobot = new Mock<IRobot>();

            mockRobot.Setup(x => x.Turn(Constants.TurnAngle));

            identifiableRobot1.Robot.Turn(Constants.TurnAngle);
            mockRobot.Object.Replay(RobotMethodCache[identifiableRobot1.Id].LastOrDefault());

            mockRobot.Verify(x => x.Turn(Constants.TurnAngle), Times.Once);

        }

        #endregion

        #region private

        private static IDictionary<string, IIdentifiableRobot> Robots { get; set; }
        private static IDictionary<string, List<MethodSignature>> RobotMethodCache { get; set; }

        #endregion

    }

}
