using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;    // Tableau de points de spawn (2 points minimum)
    public GameObject tankPrefab;      // Prefab du tank � instancier

    // M�thode pour spawn un tank pour un joueur donn� (ex: joueur 0 ou 1)
    public GameObject SpawnTank(int playerIndex)
    {
        if (playerIndex < 0 || playerIndex >= spawnPoints.Length)
        {
            Debug.LogError("Index de joueur invalide !");
            return null;
        }

        Vector3 spawnPos = spawnPoints[playerIndex].position;
        Quaternion spawnRot = spawnPoints[playerIndex].rotation;

        GameObject newTank = Instantiate(tankPrefab, spawnPos, spawnRot);
        newTank.name = $"Tank_Player_{playerIndex + 1}";

        // Ici tu peux assigner un ID ou autre donn�e li�e au joueur
        TankMovement tankCtrl = newTank.GetComponent<TankMovement>();
        if (tankCtrl != null)
        {
            tankCtrl.playerID = playerIndex;
        }

        return newTank;
    }
}
