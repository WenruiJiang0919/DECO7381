using System.Collections;
using UnityEngine;

public class quitgame : MonoBehaviour
{
    public GameModeManager gameModeManager;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ���û�����ESC��ʱ�˳���Ϸ
            gameModeManager.QuitGame();
        }
    }
}
