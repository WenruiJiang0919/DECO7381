using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disapear : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("audience"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("npc"))
        {
            Destroy(collision.gameObject);

            count gameManager = FindObjectOfType<count>();
            if (gameManager != null)
            {
                if (gameObject.CompareTag("door"))  // ��������Ƿ���"Door"��ǩ
                {
                    gameManager.IncrementEscapeCount(); // ��������+1
                }
                else if (gameObject.CompareTag("fire"))  // ��������Ƿ���"Fire"��ǩ
                {
                    gameManager.IncrementCasualtyCount(); // ��������+1
                }
            }
        }
 
}


}