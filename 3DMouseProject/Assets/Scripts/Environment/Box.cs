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


            Quaternion keyRotation = Quaternion.Euler(new Vector3(-80.5f, -159.2f, 183.5f));
            Vector3 keyPosition = new Vector3(transform.position.x, .5f, transform.position.z);

            if (hits == 0)
            {
                // If an item is "inside" the box, spawn it
                if (item != null)
                {
                    Instantiate(item, keyPosition, keyRotation);
                }
                Destroy(gameObject);
            }
        }
    }
}
