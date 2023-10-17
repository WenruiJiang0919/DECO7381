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
                if (gameObject.CompareTag("door"))  // Check if the object is labeled "Door".
                {
                    gameManager.IncrementEscapeCount(); // Number of escapees +1
                }
                else if (gameObject.CompareTag("fire"))  // Check if the object is labeled "Fire".
                {
                    gameManager.IncrementCasualtyCount(); // Casualties +1
                }
            }
        }
 
}


}
