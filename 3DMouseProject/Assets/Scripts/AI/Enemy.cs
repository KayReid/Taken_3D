using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Enemy instance;

	public int health = 2;
    public AudioClip hurtSound;
    // The amount of time the enemy should be shaking
    public float shakeTimeStandard = 0.2f;
    // The strength of the enemy shake
    public float shakeStrengthStandard = 0.2f;

    public float shakeTimeRemaining;


    // Use this for initialization
    void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        if (shakeTimeRemaining > 0)
        {
            Vector3 shake = new Vector3(Random.Range(-.2f, .2f), 0, Random.Range(-.2f, .2f)) * shakeStrengthStandard;
            shakeTimeRemaining -= Time.deltaTime;
            transform.position += shake;
            return;
        }
		if (health <= 0) {
            Destroy (gameObject);

		}
    }


	void OnCollisionStay(Collision other){

		if (other.gameObject.tag == "Player" && Player.instance.invulnerable != true) {
			Player.instance.Injure();
		}

	}



}
	
