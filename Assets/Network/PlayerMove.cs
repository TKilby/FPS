using UnityEngine;

using UnityEngine.Networking;
public class PlayerMove : NetworkBehaviour {
	public GameObject bulletPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer)
			return;
		var x = Input.GetAxis("Horizontal")*0.1f;
		var z = Input.GetAxis("Vertical")*0.1f;

		transform.Translate(x, 0, z);
		if (Input.GetKeyDown(KeyCode.Space))
		{
			CmdFire();
		}

	}
	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer>().material.color = Color.red;
	}
	[Command]
	void CmdFire()
	{
		//Command code is run on the server
		// create the bullet object from the bullet prefab
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			transform.position - transform.forward,
			Quaternion.identity);

		// make the bullet move away in front of the player
		bullet.GetComponent<Rigidbody>().velocity = -transform.forward*4;

		//Spawn the bullets
		NetworkServer.Spawn(bullet);
		// make bullet disappear after 2 seconds
		Destroy(bullet, 2.0f);        
	}
}
