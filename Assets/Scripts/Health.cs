using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

/// <summary>
/// Ryan Scopio
/// Dictates health of an object
/// Regenative health an option
/// </summary>
/// 
/// 
/// edited for networking
public class Health : NetworkBehaviour
{
    public GameObject GameOver;
    public GameObject DeathAnimation;
	[SyncVar(hook = "UpdateHealth")]
    public float CurrentHealth;
    public float MaxHealth;
    

   
	[SyncVar]
	private bool hasZeroHealth;

    

  

	public void UpdateHealth(float health){

		CurrentHealth = health;
	}


	public void takeDamage(float damage){
		if (!isServer) {
			return;
		}

		var newHealth = CurrentHealth - damage;
		Debug.Log ("new health is " + newHealth);
		if (newHealth <= 0) {
			//make explosions or something

			Instantiate (GameOver);
			Instantiate (DeathAnimation, transform.position, transform.rotation, null);
			transform.gameObject.SetActive (false);


			RpcDeath ();
		} else {
			CurrentHealth = newHealth;
		}
	
	
	}

	[ClientRpc]
	void RpcDeath(){

		if (isLocalPlayer) {
			Instantiate (GameOver);
			Instantiate (DeathAnimation, transform.position, transform.rotation, null);
			transform.gameObject.SetActive (false);
			CmdDeath ();
		} 
	}

	[Command]
	void CmdDeath(){
		
		if (isLocalPlayer) {
			Instantiate (GameOver);
			Instantiate (DeathAnimation, transform.position, transform.rotation, null);
			transform.gameObject.SetActive (false);
		}
	}



}//health

