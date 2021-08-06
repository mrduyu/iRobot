# iRobot Nasa Project

Hi!
This mars rover project has been developed for a **case study.**

#### Class names and their responsibilities:
- **Surface class:** It represents Mars surface.
- **SurfaceCreator class:** It provides to create a Mars surface with given size.
- **Rover class:** It represents rover which wanderers on Mars and it provides rover functionalities such as moving functions, getting location informations and coordinates.
- **RoverCreator class:** It provides creating a new rover on a specific coordinates and uses RoverManager to deploy on Mars.
- **RoverManager class:** It provides sending a new rover on mars, getting rover list and active current rover on mars.
- **RoverEngine class:** It provides execution of commands by using Rover class.
- **CommandExecuter:** It provides execution of commands function.


## Here is main function

![image](https://user-images.githubusercontent.com/40163745/128495964-4f0fe3f3-71cf-4599-bbcd-a04022b3010e.png)

#### Step-1
Get size of mars from user.
Create planet after given inputs.
#### Step-2
Get initial coordinates and positon of first rover.
Create rover and set it on surface according to the given inputs.
#### Step-3
Get command text line from user in order to reposition of rover.
Execute command line text.
#### Step-4
Get initial coordinates and positon of second rover.
Create rover and set it on surface according to the given inputs.
#### Step-5
Get command text line from user in order to reposition of rover.
Execute command line text.

**Note:** If any invalid inputs are sent or any exception occurs, a proper message will be shown to user.

Best Regards,
**Emre**
