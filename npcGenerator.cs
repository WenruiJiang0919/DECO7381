using UnityEngine;

public class npcGenerator : MonoBehaviour
{
    public GameObject npcPrefab;
    public Vector3[] spawnPositions;

    private void Start()
    {
        // Call a method to generate an NPC
        GenerateNPCs();
    }

    public void GenerateNPCs()
    {
        foreach (var spawnPosition in spawnPositions)
        {
            // Generating NPCs with the Instantiate function
            Instantiate(npcPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
