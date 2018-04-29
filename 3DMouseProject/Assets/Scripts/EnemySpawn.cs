using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawn : MonoBehaviour {


	public GameObject catPrefab;
	public GameObject dogPrefab;
	List<GameObject> enemyList = new List<GameObject>();
	int prefabIndex;

	// Use this for initialization
	void Start () {
		enemyList.Add(catPrefab);
		enemyList.Add(dogPrefab);
		StartCoroutine (SpawnEnemyCoroutine ());
	}

	IEnumerator SpawnEnemyCoroutine () {
		// forever
		while (true) {

			if (transform.childCount < 1) {
				yield return new WaitForSeconds(Random.Range(5,10));
				prefabIndex = UnityEngine.Random.Range(0,2);
				// Vector3 spawnPosition = NavMeshAgent.Warp(transform.position);
				Vector3 spawnPosition = transform.position;
				GameObject enemy = Instantiate(enemyList[prefabIndex], spawnPosition, Quaternion.identity);
				enemy.transform.parent = gameObject.transform;

			}


		}

	}

}
