using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public static bool keyActivated;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    	
	}


    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            Destroy(this.gameObject); // Destroy this cheese object
            keyActivated = true;
            Debug.Log("Player hit!, Key is activated for the door");

        }
    }
}
