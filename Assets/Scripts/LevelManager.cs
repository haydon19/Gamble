using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance;
    public PlayerController player;
    public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    public FinishPoint goalFlag;
    public bool end = false;
    public float timeInLevel;

	// Use this for initialization
	void Start () {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;

        //set the level timer to 0
        timeInLevel = 0;

    }
	
    public SpawnPoint GetSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Count)];
    }

    public void Update()
    {
        timeInLevel += Time.deltaTime;
    }

}
