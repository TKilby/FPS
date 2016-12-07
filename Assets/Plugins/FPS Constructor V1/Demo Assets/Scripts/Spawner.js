#pragma strict
var curWave : int = 0;
var waypoints : Waypoint[];
var waves : Wave[];
var spawners : Transform[];
var spawnDelay : float = 3;
var enemyPrefab: GameObject = null;
var newCube: GameObject = null;
var spawnTime : float = .2;
var POS : Vector3;
var spawned : GameObject;
private var spawning : boolean = false;
private var nextSpawnTimme : float;


function Spawn () {
	var w : Wave;
	var cs : CubeSet;
	
	while(curWave < waves.length){	
		w = waves[curWave];
		for(var i : int = 0; i < 10; i++){
			cs = w.cubeSets[i];
			cs.SpawnCS(spawners[i], waypoints[i], spawnTime);
			var pos = new Vector3(
				Random.Range(.1f, .1f),
				.1f,
				Random.Range(.1f,.1f)
			);

			var rotation = Quaternion.Euler( Random.Range(0,1), Random.Range(0,1), Random.Range(0,1));

			 		Instantiate(enemyPrefab, pos, rotation);
			 		NetworkServer.Spawn(spawned);
		//	NetworkServer.Spawn(newCube);
		}
		while(EnemyMovement.enemies > 0){
			yield WaitForFixedUpdate;
		}
		curWave++;
		yield new WaitForSeconds(spawnDelay + 1*curWave);
		if(curWave >= waves.length)
			curWave = 0;
	}
}

function OnTriggerEnter (other : Collider) {
	//if(other.tag == "Player")
	if(!spawning){
		spawning = true;
		Spawn();
	}
}