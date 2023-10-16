# Yuyuan Pan
# Multi-Unit Management（RTScontrol，RTSManager，RTSUtils）
A selection box that scales with mouse drag and a list of control units make up the two main components of the multi-unit control's functionality.
#Select Box
The selection box lacks a collision body, making it effectively a game user interface. Where the player's mouse lands affects how big it is. The first corner of the selection box is where the player's mouse click is initially detected and set. The diagonally opposite corner is then continuously interpreted as the player's mouse drop point. Based on the separation of these two locations, the selection box is sized. Because the drop point needs to be retrieved in two dimensions on the screen, Vector 2 is the variable type that was used to read it instead of Vector 3.

Each object in a scene created using Unity has a 3D coordinate. You must navigate through all of the game objects and translate their coordinates to a 2D coordinate, or the screen coordinate, if you wish to use a 2D checkbox to pick an item in 3D space. To choose multiple units, check to see if the object's screen coordinates are included in the selection box.

It is vital to provide the chosen unit's special effect in order to inform the player whether or not a unit has been chosen. To do this, make a pattern that doesn't have any collision bodies, place it beneath the unit, check to see whether the unit is in the list of controlled units, and then enable the Sprite Renderer if the result is true.
# npcGenerator
The NPC Generator is a code utility designed to assist in generating units that the player can control. It is intended for use in Unity game development.The function of this code has not been implemented due to some problems, and will be completed in the future work。

# camara control
Code used to control camera movement
# others
Some test code to use while learning unity
