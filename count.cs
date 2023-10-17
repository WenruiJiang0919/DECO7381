using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class count : MonoBehaviour
{
    public GameModeManager gameModeManager;
    public int escapeCount = 0;
    public int casualtyCount = 0;
    public bool showCount = false;

    private void Start()
    {
        // Initialization Count
        escapeCount = 0;
    }

    public void IncrementEscapeCount()
    {
        // increment
        escapeCount++;
        if (escapeCount == 9)
        {
            gameModeManager.EndGame(true); // Notify GameModeManager of win
        }

    }
    public void IncrementCasualtyCount()
    {
        if (casualtyCount == 1)
        {
            gameModeManager.EndGame(false); // Notify GameModeManager of win
        }

    }
    public void Escape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameModeManager.EndGame(false); // Notify GameModeManager of win
        }

    }


    public void StartCounting()
    {
        StartCoroutine(ShowCountAfterDelay(7f));  // 7 seconds delay
    }

    IEnumerator ShowCountAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        showCount = true;
    }

    private void OnGUI()
    {
        if (showCount)
        {
            GUI.skin.label.fontSize = 30;
            Rect labelRect1 = new Rect(20, 20, 500, 50);
            

            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.normal.textColor = Color.white; // choose the color of the text you want

            // Drawing of the text "Number of escaping: " Text
            GUI.Label(labelRect1, "Number of persons escaping: ", style);

            style.normal.textColor = Color.green;

            // Draws the escapeCount value. You need to add it to the width of the previous label to place it correctly
            GUI.Label(new Rect(labelRect1.x + 400, labelRect1.y + 3, labelRect1.width, labelRect1.height), escapeCount.ToString(), style);

           
        }
    }
    
}
