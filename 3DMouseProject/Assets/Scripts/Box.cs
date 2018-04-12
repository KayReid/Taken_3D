using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    [Tooltip("An optional item that will appear when the box is destroyed.")]
    [SerializeField] GameObject item = null;

    // Destroy box when shot 
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Poop")
        {
            if (item != null)
            {
                Instantiate(item);
            }
            Destroy(gameObject);
        }
    }
}
