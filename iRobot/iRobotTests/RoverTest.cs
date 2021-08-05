using iRobot.Enums;
using iRobot.HeadQuarter;
using iRobot.Planet;
using iRobot.Rover;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace iRobotTests
{
    [TestClass]
    public class RoverTest
    {
        private ISurface surface;
        private CommandExecuter commandExecuter;

        [TestInitialize]
        public void TestInit()
        {
            surface = new Surface();
            surface.Create(5, 5);
            commandExecuter = new CommandExecuter();
        }

        [TestMethod]
        public void RoverCreationTest()
        {
            const int coordinateX = 1;
            const int coordinateY = 2;
            const Direction direction = Direction.N;
            RoverManager roverManager = new RoverManager(surface);
            RoverCreator roverCreatorCommand = new RoverCreator(roverManager, coordinateX.ToString() + " " + coordinateY.ToString() + " " + direction.ToString());

            commandExecuter.ExecuteCommand(roverCreatorCommand);

            const int expectedCreatedRoverCount = 1;
            var roverCount = roverManager.GetRoverList().Count;
            Assert.AreEqual(expectedCreatedRoverCount, roverCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Rover location is out of bounds.")]
        public void RoverCreationOutOfSurfaceSize()
        {
            RoverManager roverManager = new RoverManager(surface);
            RoverCreator roverCreatorCommand = new RoverCreator(roverManager, "7 8 N");
            commandExecuter.ExecuteCommand(roverCreatorCommand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Direction Q is invalid in command line!")]
        public void RoverInvalidMovementCommand()
        {
            RoverManager roverManager = new RoverManager(surface);
            RoverCreator roverCreatorCommand = new RoverCreator(roverManager, "2 2 Q");
            commandExecuter.ExecuteCommand(roverCreatorCommand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid command!")]
        public void RoverInvalidCommandLine()
        {
            RoverManager roverManager = new RoverManager(surface);
            RoverCreator roverCreatorCommand = new RoverCreator(roverManager, "2 2N");
            commandExecuter.ExecuteCommand(roverCreatorCommand);
        }

        [TestMethod]
        public void RoverCheckTurnRightResultIsCorrect()
        {
            RoverManager roverManager = new RoverManager(surface);
            RoverCreator roverCreatorCommand = new RoverCreator(roverManager, "1 2 N");
            commandExecuter.ExecuteCommand(roverCreatorCommand);

            const string expectedLocation = "2 2 W";
            var roverEngineMoveCommand = new RoverEngine(roverManager, "RMRR");
            commandExecuter.ExecuteCommand(roverEngineMoveCommand);

            var actualLocation = roverManager.GetRoverList()[0].GetLocationAsString();
            Assert.AreEqual(expectedLocation, actualLocation);
        }

        [TestMethod]
        public void RoverCheckTurnRightResultIsCorrect_2()
        {
            RoverManager roverManager = new RoverManager(surface);
            RoverCreator roverCreatorCommand = new RoverCreator(roverManager, "3 2 W");
            commandExecuter.ExecuteCommand(roverCreatorCommand);

            const string expectedLocation = "3 3 S";
            var roverEngineMoveCommand = new RoverEngine(roverManager, "RMRR");
            commandExecuter.ExecuteCommand(roverEngineMoveCommand);

            var actualLocation = roverManager.GetRoverList()[0].GetLocationAsString();
            Assert.AreEqual(expectedLocation, actualLocation);
        }


        [TestMethod]
        public void RoverCheckTurnLeftResultIsCorrect()
        {
            RoverManager roverManager = new RoverManager(surface);
            RoverCreator roverCreatorCommand = new RoverCreator(roverManager, "3 2 N");
            commandExecuter.ExecuteCommand(roverCreatorCommand);

            const string expectedLocation = "2 2 E";
            var roverEngineMoveCommand = new RoverEngine(roverManager, "LMLL");
            commandExecuter.ExecuteCommand(roverEngineMoveCommand);

            var actualLocation = roverManager.GetRoverList()[0].GetLocationAsString();
            Assert.AreEqual(expectedLocation, actualLocation);
        }

        [TestMethod]
        public void RoverCheckTurnLeftResultIsCorrect_2()
        {
            RoverManager roverManager = new RoverManager(surface);
            RoverCreator roverCreatorCommand = new RoverCreator(roverManager, "3 2 N");
            commandExecuter.ExecuteCommand(roverCreatorCommand);

            const string expectedLocation = "3 2 E";
            var roverEngineMoveCommand = new RoverEngine(roverManager, "LMLLM");
            commandExecuter.ExecuteCommand(roverEngineMoveCommand);

            var actualLocation = roverManager.GetRoverList()[0].GetLocationAsString();
            Assert.AreEqual(expectedLocation, actualLocation);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid command: T!")]
        public void RoverCheckInvalidMoveCommand()
        {
            RoverManager roverManager = new RoverManager(surface);
            RoverCreator roverCreatorCommand = new RoverCreator(roverManager, "3 2 N");
            commandExecuter.ExecuteCommand(roverCreatorCommand);

            var roverEngineMoveCommand = new RoverEngine(roverManager, "LLMT");
            commandExecuter.ExecuteCommand(roverEngineMoveCommand);
        }

        [TestMethod]
        public void RoverShouldNotGoOutOfBounds()
        {
            RoverManager roverManager = new RoverManager(surface);
            RoverCreator roverCreatorCommand = new RoverCreator(roverManager, "3 2 N");
            commandExecuter.ExecuteCommand(roverCreatorCommand);

            var roverEngineMoveCommand = new RoverEngine(roverManager, "MMMMM");
            commandExecuter.ExecuteCommand(roverEngineMoveCommand);

            const string expectedLocation = "3 5 N";
            var actualLocation = roverManager.GetRoverList()[0].GetLocationAsString();
            Assert.AreEqual(expectedLocation, actualLocation);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Mars rovers cannot be at the same coordinates. Since rovers may crush each other")]
        public void BothRoverShouldNotBeAtTheSameCoordinate()
        {
            RoverManager roverManager = new RoverManager(surface);
            RoverCreator firstRoverCreatorCommand = new RoverCreator(roverManager, "3 2 N");
            commandExecuter.ExecuteCommand(firstRoverCreatorCommand);

            RoverCreator secondRoverCreatorCommand = new RoverCreator(roverManager, "3 2 N");
            commandExecuter.ExecuteCommand(secondRoverCreatorCommand);

            var firstRoverEngineMoveCommand = new RoverEngine(roverManager, "LMLM");
            commandExecuter.ExecuteCommand(firstRoverEngineMoveCommand);

            var secondRoverEngineMoveCommand = new RoverEngine(roverManager, "LMLM");
            commandExecuter.ExecuteCommand(secondRoverEngineMoveCommand);
        }
    }
}
