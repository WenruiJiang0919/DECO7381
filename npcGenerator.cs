using UnityEngine;

public class npcGenerator : MonoBehaviour
{
    public GameObject npcPrefab;
    public Vector3[] spawnPositions;

    private void Start()
    {
        // ����һ������������NPC
        GenerateNPCs();
    }

    public void GenerateNPCs()
    {
        foreach (var spawnPosition in spawnPositions)
        {
            // ʹ��Instantiate��������NPC
            Instantiate(npcPrefab, spawnPosition, Quaternion.identity);
        }
    }
}