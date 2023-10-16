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
        // ��ʼ������
        escapeCount = 0;
    }

    public void IncrementEscapeCount()
    {
        // ���Ӽ���
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
        StartCoroutine(ShowCountAfterDelay(7f));  // 7���ӳ�
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
            style.normal.textColor = Color.white; // �����ѡ������Ҫ��������ɫ

            // ���� "Number of persons escaping: " �ı�
            GUI.Label(labelRect1, "Number of persons escaping: ", style);
            

            // �ı���ɫΪ��ɫ
            style.normal.textColor = Color.green;

            // ���� escapeCount ֵ����Ҫ������ǰһ����ǩ�Ŀ���������ȷ������
            GUI.Label(new Rect(labelRect1.x + 400, labelRect1.y + 3, labelRect1.width, labelRect1.height), escapeCount.ToString(), style);

           
        }
    }
    
}