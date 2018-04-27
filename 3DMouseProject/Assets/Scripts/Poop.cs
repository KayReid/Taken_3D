using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour {
    
	public float lifeTime = 2f; // After how many seconds is the shit destroyed
	public float shitSpeed = 50f;
    public AudioClip shootSound;

	// Use this for initialization
	void Start () {
		StartCoroutine (KillAfterSeconds (lifeTime));
        AudioSource.PlayClipAtPoint(shootSound, transform.position); // play sound clip
    }
	
	// Update is called once per frame
	void Update () {

		transform.Translate (Vector3.forward * shitSpeed * Time.deltaTime);


	}
	/*

	// Will destroy an object if it is an enemy.
	void OnColliderStay(Collision col)
	{
		if (col.collider.CompareTag("enemy"))
		{
			print ("hit");
			col.collider.GetComponent<EnemyFollow> ().Hurt ();
			Destroy (gameObject);
		}


	}
	*/

	void OnCollisionEnter(Collision col)
	{
		if (col.collider.CompareTag ("enemy")) {
			print ("hit");
			Enemy enemy = col.collider.GetComponent<Enemy> ();
			enemy.health--;
			if (enemy.health <= 0) {
				Destroy (gameObject);
				EnemySpawn.instance.numEnemies--;
			}
			enemy.shakeTimeRemaining = enemy.shakeTimeStandard;
			Destroy (gameObject);
		} else {
			print ("hit something else");
			Destroy (gameObject);
		}

	}

	IEnumerator KillAfterSeconds (float seconds)
	{
		yield return new WaitForSeconds (seconds);
		Destroy (gameObject);
	}


}
