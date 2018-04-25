using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour{
 

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            Destroy(this.gameObject); // Destroy this cheese object
            // increase lives by 1 in player script
        }
    }

}
