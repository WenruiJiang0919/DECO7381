# DECO7381
## 🏹 Bin Tang part
This is a pointer function. The purpose of this function is to help the user to complete the game better, by guiding the user's way forward in the game with arrows, and preventing the user from not being able to find the correct escape route because the model is too big.
First of all, after learning Unity's code, I wanted to design an arrow model by finding materials on the web that correspond to arrows, such as images, lines or Unity materials. In my initial idea, I wanted to generate a large Plane, design a material for the arrow, assign the material to the Plane, and design multiple planes in the scene to be combined to realize the function of the arrow.
## Introduction of Package
This package is all the code used to implement the Pointer function.
An image to create the material for the pointer.
A C# file to control the speed of the pointer, and to find all the path points in the Plane, sort the path points, and display the paths from the first to the last path point.
Shader file, used to adjust the parameters to render the path.
## Introduction to Functionality
In the code, I will be the path point command Pointer, Pointer can be realized to connect the initial position and the end position of any Pointer, between the Pointer to form a piece of changeable path, in the model, by changing the position of the Pointer, in any position to make the path, and then the Pointer's attributes to hide, so that the user can only observe the path The path is then hidden so that the user can only observe the path.
