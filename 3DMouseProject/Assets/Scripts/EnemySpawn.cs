using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
			print ("Start");
			prefabIndex = UnityEngine.Random.Range(0,1);
			Vector3 spawnPosition = transform.position;
			Instantiate(enemyList[prefabIndex], spawnPosition, Quaternion.identity);

			yield return new WaitForSeconds(Random.Range(10,15));
			// yield return new WaitForSeconds(2);

		}

	}
}
