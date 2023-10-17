# DECO7381
This is part of the unity functionality done by Kai Wang and Wenrui Jiang. Kai Wang is responsible for setting up the flame start location, delayed generation of the flame, and the spread of the flame. Jiang Wenrui is responsible for the game start screen, main camera position switching and the game success and failure page.

## 🔥 Kai Wang part
- ### Step 1️⃣

    Searching for flame materials in Unity asset and communicating with the team members, I chose a flame material library. After downloading it and testing it in the scene, I finally picked the most suitable flame instance.

- ### Step 2️⃣

    Using the "**Move Tool**" I placed the selected flame instances into the initially built scene model. By changing the "**Size over Lifetime**" property in the "**Particle Effects**" settings, I realized to manage the amount of particles released and thus regulate the intensity of the flames. In addition, by using the "**Start Delay**" function, I realized to control the delayed appearance of the flames in the scene.

- ### Step 3️⃣

    Using duplicated flame instances and adjusting the position of the cloned flame instances and the timing of the cloned flame instances, I have achieved a simulation of the spread of flames within the arena. Furthermore, I took into account that in a realistic scenario, as the flame particles burn and grow, the flames may come into contact with the roof or walls of the arena. In order to prevent mold penetration, I added collision to the flame instance and set the layer where the collision occurs, that is, when the flame touches the roof or the wall of the model, the flame's "**life cycle**" will be gradually reduced, thus preventing the flame from penetrating the mold.

- ### Step 4️⃣
  
    After going through the fieldwork and group discussions, I chose three areas with fire safety hazards and set fire points at corresponding locations in the arena model. At the same time, I wrote script code to make the flame instances realize more functions. By defining a variable for the flame diffusion direction and creating an array to store the flame diffusion direction and binding the corresponding module in Unity, I realized that I could freely set the delay generation time of the flame instances in Unity. By iterating through each spread direction in the **StartfireSpread** method and determining where the new flame is generated based on the current flame position I realize the freedom to set single or multiple spread directions for the flame in Unity.

- ### Step 5️⃣
  
    Then I carried out the current function with other group members and realized that when the user clicks PLAY GAME he will be randomly assigned to a fire-starting scene and only the flame instance of that fire-starting scene will be awakened, and the main camera will be shifted to the game NPC after giving a close-up of the spread of that flame for 3 seconds. At the same time, the flames are given a collision body that kills the NPC when it touches the flame collision body. The game jumps to the game failure page.

## 🎮 Wenrui Jiang part

### Part1: Fire & Camera Setting
At the first stage, My team member Kai Wang and I started by using a flame model from Unity and modifying it to fit our project's needs. Here's how we did it:
I added the flame model to the 3D arena, which was already set up by the teammate.
Next, I looked through many flame options to find the one that looked just right for our arena setting.
Once I picked the flame, we placed it in specific spots, like near the audience seats or close to the electrical boxes. I made sure the flame's size and spread looked natural.
Lastly, I added a feature to the flame so it behaves like real fire. For example, if the flame reaches the arena's roof, it will spread sideways. And if it touches something solid, it will change its path and might even get smaller.

At the second stage, after team member Kai Wang was responsible for adjusting the flame gave me the coordinates of the two fire starting points, I set the camera near the fire starting point according to the coordinates of the fire starting point. First, I manually pulled the coordinates of the camera so that the camera could accurately capture the entire process of the fire, then I copied the coordinates of the camera into the code, and controlled the position of the camera through the code so that the camera could be moved to its proper position after the player clicked to start the game. In this process, there are two main challenges, the first is to adjust the appropriate camera coordinates, through repeated debugging to find the right camera coordinates. The second challenge was to write a script to control the coordinates of the camera. Due to the lack of proficiency in C#, we did not succeed in controlling the coordinates of the camera through the script at first, and only after searching on the internet did we succeed in adjusting the camera to the right position.
2. The second part of the task is to add a three-second transition animation. When the player clicks to start the game, the camera will rotate accordingly and will switch after 3 seconds, and will then switch to the corresponding fire point. In this case, I wrote a c# script to control it so that the transitions are silky smooth.


### Part2: UI of the Start and End Screens
1. Start Screen:
The game start page and the game finish page were created in order to make the fire game's entire procedure more comprehensive. A figure of a few flames was picked for the start page to represent the game's fire background.

2. End Screen Slogans:
The game's final page is separated into two sections: one is for those who completed the game successfully, and the other is for those who didn't. The above "Escaped & Unscathed! You outshined the blaze!" phrase will appear in this mode, and the user clicks EXIT to exit the game. The game has successfully passed the setting for the user to evacuate all of the players out of the arena in the allotted time.


### Part3: Loading Bar Setting
When the game starts, there will be a progress bar at the top of the game showing the game's countdown. The right side of the progress bar shows the remaining game time, so players can check their remaining game time at any time.

The total duration of the game is 180 seconds. When the player has more than 50 seconds left to play, the colour of the countdown bar will be green, indicating that the player still has enough time to evacuate the crowd. When the player's remaining time is less than 50 seconds, the colour of the progress bar will turn red, indicating that the player has less time left to play and may face the risk of losing the game. At this point, the player needs to speed up the evacuation or change the evacuation method to achieve a more efficient crowd evacuation in order to successfully complete the game mission.
