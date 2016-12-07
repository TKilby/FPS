using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour {

	public GameObject enemyPrefab;
	public int numEnemies;
	void Start() {
		if (isLocalPlayer) {

		}
	}
	public override void OnStartServer()
	{
		NetworkStartPosition[] spawnPoints;
		spawnPoints = FindObjectsOfType<NetworkStartPosition>();

		for (int i=0; i < numEnemies; i++)
		{


			var pos = new Vector3 (0, 0, 0);
			if (spawnPoints != null && spawnPoints.Length > 0) {
				pos = spawnPoints [Random.Range (0, spawnPoints.Length)].transform.position;

			}

			var rotation = Quaternion.Euler( Random.Range(0,1), Random.Range(0,1), Random.Range(0,1));

			var enemy = (GameObject)Instantiate(enemyPrefab, pos, rotation);
			NetworkServer.Spawn(enemy);
		}
	}
}
