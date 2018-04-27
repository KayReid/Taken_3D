using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	int health = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// FIGURE  SHIT OUT
	void OnCollisionEnter(Collision other){
		if (other.collider.GetComponent<Poop>()){
			health--;
		}
		if (other.gameObject.tag == "Player") {
			Player.instance.Injure(); 
		}
		if (health <= 0) {
			Destroy (gameObject);
		}
	}

}
	
