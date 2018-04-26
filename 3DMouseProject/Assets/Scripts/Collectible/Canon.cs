using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour{

    /// <summary>
    /// If touched by player, will be destroyed by impact and "added" to UI. Used to win the game.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            UICollectible.instance.UpdateInventory(this.gameObject); // Update UI
            Destroy(this.gameObject);
        }
    }

}
