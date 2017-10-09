using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour {

	public GameObject[] obstaclePrefabs;
	public float spawnRate;

	private float spawnPositionX = 15f;
	private float spawnPositionY = 0f;
	private Vector2 obstaclePoolPosition = new Vector2 (-10f, -20f);
	private GameObject[] obstacles;
	private float lastSpawnTime = 10f;
	private int currentObstacle = 0;
	private int lastObstacle = -1;
	private int secondLastObstacle = -1;
	private int obstacleSetsSize;

	// Use this for initialization
	void Start () 
	{
		obstacleSetsSize = obstaclePrefabs.Length*2;
		obstacles = new GameObject[obstacleSetsSize];
		currentObstacle = Random.Range (0, obstacleSetsSize);

		for (int i = 0; i < obstacleSetsSize/2; i++) 
		{
			obstacles [i] = (GameObject)Instantiate (obstaclePrefabs[i], obstaclePoolPosition, Quaternion.identity);
			obstacles [i+3] = (GameObject)Instantiate (obstaclePrefabs[i], obstaclePoolPosition, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		lastSpawnTime += Time.deltaTime;

		if (GameControl.instance.gameOver == false && lastSpawnTime >= spawnRate) 
		{
			lastSpawnTime = 0;

			setNextObstacle ();
			obstacles [currentObstacle].transform.position = new Vector2 (spawnPositionX, spawnPositionY);
		}

	}

	void setNextObstacle ()
	{
		int currentObstacleClone = findClone (currentObstacle);
		while (currentObstacle == lastObstacle || currentObstacleClone == lastObstacle) {
			currentObstacle = Random.Range (0, obstacleSetsSize);
			currentObstacleClone = findClone (currentObstacle);
		}

		if (currentObstacle == secondLastObstacle) {
			currentObstacle = currentObstacleClone;
		}

		secondLastObstacle = lastObstacle;
		lastObstacle = currentObstacle;
	}

	int findClone (int original)
	{
		if (original < 3) {
			return original + 3;
		}
		return original - 3;
	}
}
