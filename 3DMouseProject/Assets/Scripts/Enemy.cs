using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health = 2;
    // The amount of time the enemy should be shaking
    public float shakeTimeStandard = 0.2f;
    // The strength of the enemy shake
    public float shakeStrengthStandard = 0.15f;

    private float shakeTimeRemaining;

    // Use this for initialization
    void Start () {
		
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
    }

	// FIGURE  SHIT OUT
	void OnCollisionStay(Collision other){
		if (other.collider.GetComponent<Poop>()){
			health--;
            shakeTimeRemaining = shakeTimeStandard;
        }
		if (other.gameObject.tag == "Player" && Player.instance.invulnerable != true) {
			Player.instance.Injure();
		}
		if (health <= 0) {
			Destroy (gameObject);
			EnemySpawn.instance.numEnemies--;
		}
	}

}
	
