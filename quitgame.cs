using System.Collections;
using UnityEngine;

public class quitgame : MonoBehaviour
{
    public GameModeManager gameModeManager;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 在用户按下ESC键时退出游戏
            gameModeManager.QuitGame();
        }
    }
}
