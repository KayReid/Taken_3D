using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawn : MonoBehaviour {


	public GameObject catPrefab;
	public GameObject dogPrefab;
	List<GameObject> enemyList = new List<GameObject>();
	int prefabIndex;

	public float Timer = 15f;

	// Use this for initialization
	void Start () {
		enemyList.Add(catPrefab);
		enemyList.Add(dogPrefab);
	}

	void Update(){
		Spawn ();
	}

	void Spawn () {
		if (transform.childCount < 1) {
			Timer -= Time.deltaTime;
			if (Timer <= 0) {
				prefabIndex = UnityEngine.Random.Range (0, 2);
				Vector3 spawnPosition = transform.position;
				GameObject enemy = Instantiate (enemyList [prefabIndex], spawnPosition, Quaternion.identity);
				enemy.transform.parent = gameObject.transform;
				Timer = 15f;
			}
		}
	}
		

}
