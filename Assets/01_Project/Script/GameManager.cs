using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SpawnManager spawnManager;

    void Start()
    {
        // Spawn les deux tanks aux positions définies
        spawnManager.SpawnTank(0);
        spawnManager.SpawnTank(1);
    }
}
