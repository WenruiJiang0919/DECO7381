# DECO7381
## Kai Wang Part






## Wenrui Jiang Part
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
