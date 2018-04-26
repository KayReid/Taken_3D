using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public static bool keyActivated;

    /// <summary>
    /// If touched by player, will be destroyed on impact and "added" to UI. Used to free wife from her cage.
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            UICollectible.instance.UpdateInventory(this.gameObject); // Update UI
            Destroy(this.gameObject); // Destroy this key object
            keyActivated = true;
            Debug.Log("Player hit!, Key is activated for the door");
        }
    }
}
