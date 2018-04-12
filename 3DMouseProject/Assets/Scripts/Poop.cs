using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour {



	//public float lifeTime = 0.5f; // After how many seconds is the shit destroyed
	//public float shitSpeed;




	// Use this for initialization
	void Start () {
		//StartCoroutine (KillAfterSeconds (lifeTime));
	}
	
	// Update is called once per frame
	void Update () {

		//transform.Translate (Vector3.forward * shitSpeed * Time.deltaTime);


	}


	// Will destroy an object if it is an enemy.
	void OnTriggerEnter(Collider collision)
	{
		if (collision.CompareTag("enemy"))
		{
			collision.GetComponent<EnemyFollow> ().Hurt ();
		}
	}

	IEnumerator KillAfterSeconds (float seconds)
	{
		yield return new WaitForSeconds (seconds);
		Destroy (this);
	}


}
