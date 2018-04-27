using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {


	public GameObject catPrefab;
	public GameObject dogPrefab;
	List<GameObject> enemyList = new List<GameObject>();
	int prefabIndex;

	public int numEnemies = 0;
	public int maxEnemies = 3;

	public static EnemySpawn instance;

	// Use this for initialization
	void Start () {
		instance = this;
		enemyList.Add(catPrefab);
		enemyList.Add(dogPrefab);
		// StartCoroutine (SpawnEnemyCoroutine ());
	}
	void Update(){
		StartCoroutine (SpawnEnemyCoroutine ());
	}

	IEnumerator SpawnEnemyCoroutine () {
		// forever
		while (true) {
			if (numEnemies < maxEnemies) {
				print ("Start");
				prefabIndex = UnityEngine.Random.Range(0,1);
				Vector3 spawnPosition = transform.position;
				Instantiate(enemyList[prefabIndex], spawnPosition, Quaternion.identity);
				numEnemies++;
			}
			// yield return new WaitForSeconds(2);
			yield return new WaitForSeconds(Random.Range(3,5));

		}

	}
}
