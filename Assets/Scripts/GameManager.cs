using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public PlayerController player;
    public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    public FinishPoint goalFlag;
    public bool end = false;

	// Use this for initialization
	void Start () {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;

        
	}
	
    public SpawnPoint GetSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Count)];
    }
	// Update is called once per frame
	void Update () {
        
	}
}
