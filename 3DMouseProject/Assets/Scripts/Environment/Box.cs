using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    [Tooltip("An optional item that will appear when the box is destroyed.")]
    [SerializeField] GameObject item = null;

    // Destroy box when shot by player
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Poop")
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
