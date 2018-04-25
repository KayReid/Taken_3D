using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    [Tooltip("An optional item that will appear when the box is destroyed.")]
    [SerializeField] GameObject item = null;

    // The number of times a box can be hit before it is destroyed by the player
    public int hits = 1;

    // Called when a bullet from the player hits the box. Will "hurt" the box by 1 each time
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Poop")
        {
            hits--;

            if (hits == 0)
            {
                // If an item is "inside" the box, spawn it
                if (item != null)
                {
                    Instantiate(item, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }
    }
}
