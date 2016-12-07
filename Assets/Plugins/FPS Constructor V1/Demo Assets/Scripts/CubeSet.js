#pragma strict
var cubes : Transform[];
var amts : int[];
var newEnemy : GameObject;
var  enemyPrefab: GameObject;
function SpawnCS (pos : Transform, w : Waypoint, t : float) {
	var spawned : Transform;
	for(var j : int = 0; j < cubes.length; j++){
		for(var q : int = 0; q < amts[j]; q++){
		var newCube : GameObject;

	//	 Instantiate(newCube, pos.position+Vector3(0,4,0)*q, pos.rotation);
		
			//	var newEnemy = (GameObject)Instantiate(enemyPrefab, pos, rotation);
			EnemyMovement.enemies++;
			spawned.GetComponent(EnemyMovement).waypoint = w.transform;
	
			yield new WaitForSeconds(t);
		}
	}
}