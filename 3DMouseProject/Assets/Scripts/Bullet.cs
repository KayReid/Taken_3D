using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
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
		

	void OnCollisionEnter(Collision col)
	{
		if (col.collider.GetComponent<Enemy> ()) {
			Enemy enemy = col.collider.GetComponent<Enemy> ();
			enemy.health--;
			enemy.shakeTimeRemaining = enemy.shakeTimeStandard;
			Destroy (gameObject);
		} else {
			Destroy (gameObject);
		}



	}



	IEnumerator KillAfterSeconds (float seconds)
	{
		yield return new WaitForSeconds (seconds);
		Destroy (gameObject);
	}


}
