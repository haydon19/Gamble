using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance;
    public PlayerController player;
    public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    public FinishPoint goalFlag;
    public bool end = false;
    public float timeInLevel;
    public List<Tilemap> maps;
	// Use this for initialization
	void Start () {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;

        //set the level timer to 0
        timeInLevel = 0;

        SetToMap(Random.Range(0, maps.Count));
    }
	
    public SpawnPoint GetSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Count)];
    }

    public void Update()
    {
        timeInLevel += Time.deltaTime;
    }

    public void SetToMap(int index)
    {
        foreach(Tilemap map in maps)
        {
            map.gameObject.SetActive(false);
        }

        maps[index].gameObject.SetActive(true);
    }
}
