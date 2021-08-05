using iRobot.HeadQuarter;
using iRobot.Planet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace iRobotTests
{
    [TestClass]
    public class SurfaceTest
    {
        [TestMethod]
        public void SurfaceCreationSizeTest()
        {
            Surface surface = new Surface();
            CommandExecuter commandExecuter = new CommandExecuter();
            SurfaceCreator surfaceCreationCommand = new SurfaceCreator(surface, "6 8");
            const int expectedHeight = 8;
            const int expectedWidth = 6;

            commandExecuter.ExecuteCommand(surfaceCreationCommand);
            var actualWidth = surface.GetSurfaceWidth();
            var actualHeight = surface.GetSurfaceHeight();

            
            Assert.AreEqual(expectedWidth, actualWidth);
            Assert.AreEqual(expectedHeight, actualHeight);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Planet surface size cannot be 0 X 0.")]
        public void SurfaceCreationWithZeroSize()
        {
            Surface surface = new Surface();
            CommandExecuter commandExecuter = new CommandExecuter();
            SurfaceCreator surfaceCreationCommand = new SurfaceCreator(surface, "0 0");            

            commandExecuter.ExecuteCommand(surfaceCreationCommand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Planet surface size cannot be negative.")]
        public void SurfaceCreationWithBelowZeroSize()
        {
            Surface surface = new Surface();
            CommandExecuter commandExecuter = new CommandExecuter();
            SurfaceCreator surfaceCreationCommand = new SurfaceCreator(surface, "-1 0");

            commandExecuter.ExecuteCommand(surfaceCreationCommand);
        }
    }
}
