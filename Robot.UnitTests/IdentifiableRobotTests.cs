using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotIntegration;
using RobotSdk;
using System;

namespace Robot.UnitTests
{

    [TestClass]
    public class IdentifiableRobotTests
    {

        public IdentifiableRobotTests()
        {
        }


        #region public

        [TestMethod, TestCategory(Constants.TestCategory)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_NullId_Fails()
        {

            Mock<IRobot> mockRobot = new Mock<IRobot>();
            IIdentifiableRobot robot = new IdentifiableRobot(null, Constants.DefaultRobotName, mockRobot.Object);

        }

        [TestMethod, TestCategory(Constants.TestCategory)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_EmptyName_Fails()
        {

            Mock<IRobot> mockRobot = new Mock<IRobot>();
            IIdentifiableRobot robot = new IdentifiableRobot(Guid.NewGuid().ToString(), string.Empty, mockRobot.Object);

        }

        [TestMethod, TestCategory(Constants.TestCategory)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_NullName_Fails()
        {

            Mock<IRobot> mockRobot = new Mock<IRobot>();
            IIdentifiableRobot robot = new IdentifiableRobot(Guid.NewGuid().ToString(), null, mockRobot.Object);

        }

        [TestMethod, TestCategory(Constants.TestCategory)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_WhitespaceName_Fails()
        {

            Mock<IRobot> mockRobot = new Mock<IRobot>();
            IIdentifiableRobot robot = new IdentifiableRobot(Guid.NewGuid().ToString(), " ", mockRobot.Object);

        }

        [TestMethod, TestCategory(Constants.TestCategory)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_NullRobot_Fails()
        {

            Mock<IRobot> mockRobot = new Mock<IRobot>();
            IIdentifiableRobot robot = new IdentifiableRobot(Guid.NewGuid().ToString(), Constants.DefaultRobotName, null);

        }

        #endregion

        [TestMethod, TestCategory(Constants.TestCategory)]
        public void Beep_Success()
        {

            Mock<IRobot> mockRobot = new Mock<IRobot>();
            mockRobot.Setup(x => x.Beep());

            IIdentifiableRobot identifiableRobot = new IdentifiableRobot(Guid.NewGuid().ToString(), Constants.DefaultRobotName, mockRobot.Object);
            identifiableRobot.Robot.Beep();

            mockRobot.Verify(x => x.Beep(), Times.Once);

        }

        [TestMethod, TestCategory(Constants.TestCategory)]
        public void Move_Success()
        {

            Mock<IRobot> mockRobot = new Mock<IRobot>();
            mockRobot.Setup(x => x.Move(It.IsAny<double>()));

            IIdentifiableRobot identifiableRobot = new IdentifiableRobot(Guid.NewGuid().ToString(), Constants.DefaultRobotName, mockRobot.Object);
            identifiableRobot.Robot.Move(Constants.MoveDistance);

            mockRobot.Verify(x => x.Move(Constants.MoveDistance), Times.Once);

        }

        [TestMethod, TestCategory(Constants.TestCategory)]
        public void Name_Matches_Success()
        {

            IIdentifiableRobot identifiableRobot = new IdentifiableRobot(Guid.NewGuid().ToString(), Constants.DefaultRobotName, new Mock<IRobot>().Object);
            Assert.IsTrue(identifiableRobot.Name.Equals(Constants.DefaultRobotName, StringComparison.Ordinal));

        }

        [TestMethod, TestCategory(Constants.TestCategory)]
        public void Turn_Success()
        {

            Mock<IRobot> mockRobot = new Mock<IRobot>();
            mockRobot.Setup(x => x.Turn(It.IsAny<double>()));

            IIdentifiableRobot identifiableRobot = new IdentifiableRobot(Guid.NewGuid().ToString(), Constants.DefaultRobotName, mockRobot.Object);
            identifiableRobot.Robot.Turn(Constants.TurnAngle);

            mockRobot.Verify(x => x.Turn(Constants.TurnAngle), Times.Once);

        }

    }

}
