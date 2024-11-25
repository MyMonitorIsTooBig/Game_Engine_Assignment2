**Link to Video Report:**

https://www.youtube.com/watch?v=swqnK_uXdTs



**Names and roles of all team members**



Andrew : Implementation: 100% : Overall: 100%

- Role: Programmer / Polish
- Responsibilities:
  - Design Pattern Improvements: Factory & Singleton
    - Diagrams, Explanation, and Implementation 
  - Optimizations: Flyweight & Object Pooling
    - Diagrams, Explanation, and Implementation 
  - Plugin: Cheating/Custom Modifications
    - Diagrams, Explanation, and Implementation
  - Performance Profling: 
    - Diagrams/Video, Explanation, and Implementation

  - Other work:
    -  Aesthetic Change
    -  Secret Freaky Mode
  

**Scenerio Information:**

The interactive media scene is a Labyrinth game where the player has to traverse through an auto generated labyrinth like area. The player must hunt down enemies that proactively flee from and evade the player while avoiding the evil enemies. The scene has two distinct game modes: countdown and time trial. Countdown has the player trying to reach a certain score before the time runs out and time trial allows the player to reach that same score goal but in as much time as they need. The enemies present will evade the player and to make it extra difficult, if they run into a run they will hop over it, something the player cannot do. The scene is simplistic in nature however this aspect makes it much harder to complete the goal as enemies are able to completely get out of the labyrinth causing the player to have to wait for more to spawn.


**Written Report/Explanations:**


Design Pattern Improvements:

The first improvement I’ve done to the design patterns is with the Enemy Spawner. The Enemy Spawner uses the factory design pattern however it would only spawn the same non-unique enemy which defeats the purpose of the factory design pattern. To improve this I added functionality for other types of enemies to be spawned. This was done to add more layer and depth to the scene. Not only do multiple enemies spawn now but the second enemy is very detrimental to kill so it adds complexity and strategy to the game. 


The second improvement I’ve done was related to the singletons. The current singletons in the game set up the labyrinth, timer, score, enemy placement, etc. on start. Because of how the singleton class works, when switching scenes these vital systems won’t re-activate. To counter this I modified every singleton to be more self contained so I could add these functions into the awake method without getting rid of the singleton functionality. This was done because it was a fairly bad bug that stopped the player from replaying the game upon winning, losing, or just going back to the main menu. Fixing this essentially added replayability.

**Design Improvements Showcased in Video Report**


Optimization Design Patterns:

The first optimization design pattern added was the flyweight pattern. This pattern was implemented with the enemies, bullets, and evil enemies. This pattern works by first having three different scriptable objects used to store static variables. Since the bullets, enemies, and evil enemies all have variables that never change (i.e: damage, distance, maxHealth, speed, etc.) creating scriptable objects that store these variables optimizes the game since there is only one instance of these variables that the bullets and enemies grab rather than every single instance of bullets and enemies storing these variables locally. This works with the project since these objects are being continuously instantiated so having one global reference to these variables rather than an indefinite number of local variables would be optimal.

![alt-text](https://github.com/MyMonitorIsTooBig/Game_Engine_Assignment2/blob/main/Flyweight.drawio.png)

The second optimization pattern added is the object pooling pattern. This pattern was added with the bullets. How it works is first it creates a dictionary of bullets then it instantiates a number of bullet objects. The amount depends on how much a variable amountToSpawn is set to. After instantiating the object it sets it as inactive and then adds it to the dictionary. Once this process is done you’re left with a dictionary of inactive bullets that can be called using the CreateEnemy function. This function is called when the player shoots and it takes in a string, position, and rotation. The function first checks to see if the string passed in correlates to an active pool and if it does it removes one of the bullets from the pool, activates it, then puts it back in the dictionary. It sets the object's position and rotation to the position and rotation passed into the function. This works with the project since bullets are constantly spammed by the player converting it to object pooling instead of constantly instantiating and destroying helps optimize it.


Plugin:

The plugin I implemented is a cheats/setting change plugin. The plugin works by first reading a text file that includes a series of numbers split up by commas. It saves these numbers into a list and then sets internal variables to these values. The variables relate to player score, move speed, damage, jump height, enemy health, distance, and speed. These values are then read in game and updates the related field. I.e the player’s speed is changed to what the plugin reads the player’s speed to be in the text file. You can choose in the editor which of these fields you want to update via the text document. This implementation works well with the game as it gives the player a chance to modify in game data to cheat. Cheating is fun in video games. This also allows the player to make the game easier if they find it too difficult and also lets them modify the game to make it more enjoyable. For example if they find the base movement speed too slow or too fast they can modify it themselves or increase damage or the enemy detection range/movement speed.

![alt-text](https://github.com/MyMonitorIsTooBig/Game_Engine_Assignment2/blob/main/plugin.drawio.png)

Performance Profiling:

The performance was implemented by modifying the enemies movement system and implementing object pooling. The enemy movement used to use the LookAt function to make the enemy constantly look at the player then their velocity would be set to make them move backwards away from the player. The LookAt function was removed and the movement was changed to just make the enemy move in the opposite direction of the player since the normalized vector of the enemy to the player is already set earlier with the player detection system of the enemy. This ended up optimizing the project by quite a bit, especially when a lot of enemies are loaded at once. The bullet object pooling optimization saves memory as bullets aren’t constantly being instantiated and deleted anymore and instead a pool of bullets are instantiated and the bullets are just being activated and deactivated.

![alt-text](https://github.com/MyMonitorIsTooBig/Game_Engine_Assignment2/blob/main/profiling.drawio.png)


