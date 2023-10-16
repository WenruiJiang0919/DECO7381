/*using UnityEngine;

public class NPCGenerator : MonoBehaviour
{
    public GameObject npcPrefab;
    public Vector3[] spawnPositions;

    private void Start()
    {
        // 调用一个方法来生成NPC
        GenerateNPCs();
    }

    void GenerateNPCs()
    {
        foreach (var spawnPosition in spawnPositions)
        {
            // 使用Instantiate函数生成NPC
            Instantiate(npcPrefab, spawnPosition, Quaternion.identity);
        }
    }
}*/