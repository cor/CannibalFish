using UnityEngine;
using System.Collections;

public class FishSpawn : MonoBehaviour {

	public GameObject enemyToSpawn;
	public float previousSpawnTimeStamp;
	public float delayBetweenSpawns = 5f;

	// Use this for initialization
	void Start () {
		previousSpawnTimeStamp = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > previousSpawnTimeStamp + delayBetweenSpawns) {
			SpawnEnemyNow();

		}


	}

	void SpawnEnemyNow() {
		GameObject clone;
		clone = Instantiate(enemyToSpawn, transform.position, transform.rotation) as GameObject;
		clone.GetComponent<AIFishController>().enabled = true;
		previousSpawnTimeStamp = Time.time;
	}
}
