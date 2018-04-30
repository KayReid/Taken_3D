using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public static bool keyActivated; 
    public AudioClip collectSound;

    /// <summary>
    /// If touched by player, will be destroyed on impact and "added" to UI. Used to free wife from her cage.
    /// </summary>
    /// <param name="collision"></param>
	/// 

	void Start () {
		keyActivated = false;
	}

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            UICollectible.instance.UpdateInventory(this.gameObject); // Update UI
            AudioSource.PlayClipAtPoint(collectSound, transform.position); // play sound clip
            Destroy(this.gameObject); // Destroy this key object
            keyActivated = true;
        }
    }
}
