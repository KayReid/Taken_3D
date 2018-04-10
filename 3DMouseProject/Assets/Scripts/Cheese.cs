using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour {
    int cheeseCounter; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            cheeseCounter++;
            Destroy(this.gameObject); // Destroy this cheese object
            Debug.Log("Player hit!, Cheese Counter: " + cheeseCounter);

        }
    }

}
