# DECO7381
## 🎬 Xinyi Tian part
## Player Controller & Mini-map

### 1 Player Movement
Combine unity animator controller and script to handle player movement and animation. Then the animator controller is used to realise the movement 
animation. Switch between walking and standing by speed control, and switch between running positions by monitoring whether there is Running or not.

To start, add a shift button in the project setting and set it to sprint. Add CharacterController to the player's game object according to the sprint, 
which is used to simplify the movement and collision detection of the character. In the code section, use Quaternion to rotate the direction the player 
is facing. Through Animator, control the animation of the character. Through Input to detect if the player has changed direction and speed.

### 2 Player Viewpoint Tracking
Get the instance of the PlayerControl component by FindObjectOfType and get the player's Transform from it. Smooth the transition between two points by 
Vector3.Lerp so that the camera moves smoothly to the target position. Achieve synchronised movement of the camera and the player.

### 3 Minimap
Create a mini-map canvas by adding UI - Raw Image. Adjust the mini map to the upper right corner by rect transform. Add miniMap Camera to Player's 
subclass, adjust the camera's viewpoint to the top of the character to get an overhead view. Project the content of this camera to the newly created 
Render Texture - miniMap and finally pass it to the miniMap canvas to complete the camera projection.

Create a new sphere to represent the character in the miniMap, by creating layers so that Main Camera does not get the sphere and miniMap Camera does 
not get the Player, complete the miniMap with the green sphere representing the character's location.


## Multi-Scene Switching

### version1
It is impossible to describe every element in the main scene since the venue model is replicated exactly, exactly as it is in real life. To help the 
user concentrate on the elements he wants to view, we have included a scene switching mechanism that allows him to adjust the venue through several 
scenarios.

At the moment, we just utilise one scene and one camera, and we change scenes by pressing a button. In all, there are three scenes: ground floor, floor 
2, and floor 3. The keyboard's arrow keys may be used to adjust the camera's horizontal movement, but its location is fixed.

### Version 2
Adopt multi-scene single-camera, button switching scene method to show the details of venues on different floors. According to the latest version of 
the model, the gameObject is categorised by floors to ensure that the camera only shoots the buildings on the corresponding floors. The updates 
compared to the first version are as follows:
a. Changed from side view to top view;
b. Changed the camera from moving horizontally to switching between four fixed positions on each floor.

### Final Version
The camera can move freely throughout the arena and rotate the view horizontally. Unrestricted by the architecture of the arena, users can walk through 
walls etc. to directly access the interior space for observation and operation. Compare to the second version of the update:
a. Eliminate the layering of venue buildings, the camera shows all the buildings of the whole venue;
b. Elimination of multiple scenes, only one main scene and a single camera;
c. The camera can be moved and rotated, so the user can manoeuvre the camera to wherever he wants to look.


## Escape and counting

Create four planes in unity and given the door label, place them where the model doors are, add Collision and check Is Trigger, place the disappear 
script on these four planes. Similarly in flame give fire label and repeat the above steps. Finally give your own label on the npc and audience object 
respectively. Also create an empty object and bind the count script. Finally bind the event to the play button click.
