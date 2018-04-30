using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour{

	public static int cannonCounter;
    public AudioClip collectSound;
    /// <summary>
    /// If touched by player, will be destroyed by impact and "added" to UI. Used to win the game.
    /// </summary>
    /// <param name="collision"></param>
	/// 
	/// 

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            UICollectible.instance.UpdateInventory(this.gameObject); // Update UI
            AudioSource.PlayClipAtPoint(collectSound, transform.position); // play sound clip
            Destroy(this.gameObject);
			cannonCounter++;
        }
    }

}
