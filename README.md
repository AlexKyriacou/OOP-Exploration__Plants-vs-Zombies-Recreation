# Final Design Report for Plants VS Zombies

### Name: Alex Kyriacou

### Student ID: 103059830

## Final Summary of Program

My program is a replication of the classic flash game Plants Vs Zombies.
The program uses the Splash kit library to implement some of the main features of the game including:

- Auto Spawning Zombie Enemies of different types that gradually increase in difficulty over
    time
- Creation of different plant (tower) types that have different game functionality
- The ability to both place and remove towers from the game grid.
- Management of a money system controlling what options are available to the player
- Different Bullet types that have different effects on the Zombies they hit
- An intuitive GUI that allows the user to interact with different game elements
- A start screen allowing the user to start the game when desired
- An end screen displaying the users final score the player

![Figure 1: Image of the game running](https://github.com/AlexKyriacou/PlantVsZombiesFinalProject/blob/master/Game%20Images/DifferentZombieTypesArriveInLaterRounds.jpg)


## Gameplay

The game operates on a 2D grid whereby the user is able to purchase defences to protect their base
(Located on the left side of the screen) from the oncoming horde of zombies. Money within the game
can be produced in 2 ways. The first is by waiting for sun (The currency within the game) to fall from
the top of the map onto a random cell on the game grid (Figure 2), this can then be clicked on by the
user for a small currency boost. The second way is by purchasing a sunflower tower and placing it on
the game grid. Here the sunflower will generate sun after a period of time allowing the user to click on
the plant to receive a currency boost. Zombies will arrive from the right side of the screen and eat


through anything in their way to get to your base on the left side of the screen. The lawnmowers
pictured on the left side of Figure 2 will activate when a zombie reaches their position and ‘mow’ down
the row of zombies exposing that map lane but giving the player a small opportunity to recover.

![Figure 2: Falling Sun Within The Game](https://github.com/AlexKyriacou/PlantVsZombiesFinalProject/blob/master/Game%20Images/FallingSunPickup.jpg)


## Documentation

Full documentation can be found at:
https://alexkyriacou.github.io/html/15a39290-8a66-40f7-1f8c-0633d0517f56.htm
This includes explanations of all classes, methods fields’ events and enumerations and serves as the
basis for this design report.

## Debugging & Testing

In order to test this program I make the decision to use white-box testing techniques rather than using
unit testing to debug the project. This was due to the high level nature of the project and graphical
dependency on all elements of the game that would conventionally require testing. In order to ensure
that the program still worked as intended I implemented a debug mode using pre-processor directives
that allows me to override and force events within the game such that all game features can be tested
appropriately. In addition, while I have no records I also used breakpoints and the call stack to recognise
flaws within the functionality.

```C#
Public class Game
{
...
#if DEBUG
private DebugController _debug;
#endif
...
}
```
![Debug Mode](https://github.com/AlexKyriacou/PlantVsZombiesFinalProject/blob/master/Game%20Images/DebugModeOptions.jpg)

## Design Patterns
![Design Patterns](https://github.com/AlexKyriacou/PlantVsZombiesFinalProject/blob/master/UML%20and%20Sequence%20Diagrams/DesignPatterns.png)
- Singleton
    The singleton design pattern serves as a method of creating only a single instance of a class.
    This way a global access point can be created such that different classes throughout the program
    are able to manipulate the same data. Classes that use the singleton design pattern can be
    summarised within the image below. For example the entity repository class uses the singleton
    design pattern so that the various game manager classes are able to access the same list of
    currently active entities within the game.
- State Pattern
    The state pattern is used when changes in an object require dependant objects to be notified
    automatically. This is used within the game so that the game keeps track of what the player is
    trying to do at a given time. When the player clicks of one of the plant icons at the bottom of
    the game window, the current active tool is immediately set to a plant placement tool so that
    the game knows how to handle future inputs.


- Model View Controller Pattern
    The Model View Controller pattern or MVC pattern is a method that allows the decoupling
    of the program logic, object data and user interface. This promotes better encapsulation of
    class roles and responsibilities and creates a great amount of reusability of code. This program
    uses MVC as the basis for its operation, as seen below each cluster of classes serves as a basis
    for how that portion of the MVC pattern operates. For example the interactions between the
    entity repository and the entity updater serves as the core functionality of the ‘model’ part of
    the MVC pattern.


- Factory and Repository pattern
    The repository pattern serves to add a layer of abstraction between the data access and the
    logic of a program. The factory pattern is used when a layer of abstraction is required for new
    object creation. In this case, the entity factory class is responsible for all object creation
    within the game, when a new entity is made it is added to the entity repositories list before it
    is returned to the caller. The entity factory class contains a single method for each class type
    (eg. Zombie, Plant, Icon) so that when adding new plant of zombie types to the game the
    classes need not be edited.


## Possible Future Implementations and Their Design Patterns
![Future Implemenations](https://github.com/AlexKyriacou/PlantVsZombiesFinalProject/blob/master/UML%20and%20Sequence%20Diagrams/FutureImplementations.drawio.png)
- Strategy Pattern used to implement different difficulties

The strategy design pattern allows the use of different behaviour to be encapsulated and chosen during
runtime. In this case we could use the strategy pattern to create a difficulty option for the player, where
the current ZombieEngine class has an IDifficulty field added to it that determines the algorithm used
for zombie creation. Then the ZombieEngines ‘MakeZombie()’ function would become a wrapper
function for the IDifficulty MakeZombie() function. This way the same ZombieEngine class can be used
within infinite difficulties and there is appropriate encapsulation between the game and its difficulty.
This can be seen within the UML below.

- Memento Pattern used to implement Ctrl Z undo feature

The memento pattern allows you to restore an objects state to a previous desired version.
Using this, we could add undo functionality to the game so that in the case of a misplaced plant,
it can be easily undone. To do this a memento class would be created that would capture the
internal state of the EntityRepository class and another tool class would be created that
subscribes to the user clicking Ctrl Z in order to activate the memento.


## UMLS

![FullUML](https://github.com/AlexKyriacou/PlantVsZombiesFinalProject/blob/master/UML%20and%20Sequence%20Diagrams/FullUML.tiff)
![Main Inheritance Tree](https://github.com/AlexKyriacou/PlantVsZombiesFinalProject/blob/master/UML%20and%20Sequence%20Diagrams/MainInheritanceTreeUML.tiff)
![EntityFactoryUML](https://github.com/AlexKyriacou/PlantVsZombiesFinalProject/blob/master/UML%20and%20Sequence%20Diagrams/EntityFactoryUML.drawio.png)
![Entity Repository UML](https://github.com/AlexKyriacou/PlantVsZombiesFinalProject/blob/master/UML%20and%20Sequence%20Diagrams/EntityRepositoryUML.drawio.png)
![Entity Updater](https://github.com/AlexKyriacou/PlantVsZombiesFinalProject/blob/master/UML%20and%20Sequence%20Diagrams/EntityUpdaterUML.drawio.png)
## Sequence Diagrams:
![Bullet Firing Sequence Diagram](https://github.com/AlexKyriacou/PlantVsZombiesFinalProject/blob/master/UML%20and%20Sequence%20Diagrams/BulletFiringSequenceDiagram.tiff)
![Collision Sequence Diagram](https://github.com/AlexKyriacou/PlantVsZombiesFinalProject/blob/master/UML%20and%20Sequence%20Diagrams/CollisionSequenceDiagram.tiff)

## Game Images
Game images can be found at:
https://github.com/AlexKyriacou/PlantVsZombiesFinalProject/tree/master/Game%20Images
