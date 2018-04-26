using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour{

    /// <summary>
    /// If touched by player, will be destroyed by impact and "added" to UI. Used to win the game.
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            UICollectible.instance.UpdateInventory(this.gameObject); // Update UI
            Destroy(this.gameObject);
        }
    }

}
