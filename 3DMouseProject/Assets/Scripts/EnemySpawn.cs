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

				prefabIndex = UnityEngine.Random.Range(0,2);
				Vector3 spawnPosition = transform.position;
				GameObject enemy = Instantiate(enemyList[prefabIndex], spawnPosition, Quaternion.identity);
				StartCoroutine(returnTimeCoroutine ());
				enemy.transform.parent = gameObject.transform;

			}
			yield return null;

		}

	}

	IEnumerator returnTimeCoroutine() {
		Debug.Log ("Wait to spawn");
		yield return new WaitForSeconds (5f);
	}

}
