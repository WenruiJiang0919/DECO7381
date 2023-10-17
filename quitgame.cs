using System.Collections;
using UnityEngine;

public class quitgame : MonoBehaviour
{
    public GameModeManager gameModeManager;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Exit the game when the user presses the ESC key
            gameModeManager.QuitGame();
        }
    }
}
