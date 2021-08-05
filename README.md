# iRobot Nasa Project

Hi!
This mars rover project has been developed for a **case study.**

**I am sharing you about function flows below.**

#### Class names and their responsibilities:
- **Surface class:** It represents Mars surface.
- **SurfaceCreator class:** It provides to create a Mars surface with given size.
- **Rover class:** It represents rover which wanderers on Mars and it provides rover functionalities such as moving functions, getting location informations and coordinates.
- **RoverCreator class:** It provides creating a new rover on a specific coordinates and uses RoverManager to deploy on Mars.
- **RoverManager class:** It provides sending a new rover on mars, getting rover list and active current rover on mars.
- **RoverEngine class:** It provides execution of commands by using Rover class.
- **CommandExecuter:** It provides execution of commands function.
