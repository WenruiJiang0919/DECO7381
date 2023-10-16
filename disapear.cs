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
                if (gameObject.CompareTag("door"))  // 检查物体是否是"Door"标签
                {
                    gameManager.IncrementEscapeCount(); // 逃生人数+1
                }
                else if (gameObject.CompareTag("fire"))  // 检查物体是否是"Fire"标签
                {
                    gameManager.IncrementCasualtyCount(); // 伤亡人数+1
                }
            }
        }
 
}


}