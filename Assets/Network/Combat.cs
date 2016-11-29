using UnityEngine;

using UnityEngine.Networking;
public class Combat : NetworkBehaviour {
	public bool destroyOnDeath;
	public const int maxHealth=100;
	[SyncVar]
	public int health = maxHealth;

	public void TakeDamage(int amount)
	{
		if (!isServer)
			return;
		health -= amount;
		if (health <= 0) {
			if (destroyOnDeath) {
				Destroy (gameObject);
			} else {
				health = maxHealth;

				// called on the server, will be invoked on the clients
				RpcRespawn ();
			}
		}
	}
	[ClientRpc]
	void RpcRespawn()
	{
		if (isLocalPlayer)
		{
			// move back to zero location
			transform.position = Vector3.zero;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
