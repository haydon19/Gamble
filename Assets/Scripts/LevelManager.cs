using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance;
    public Player player;
    public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    public FinishPoint goalFlag;
    public bool end = false;
    public float timeInLevel;
    public List<Grid> maps; // a grid has multiple layers of tilemaps
	// Use this for initialization
	void Start () {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;

        //set the level timer to 0
        timeInLevel = 0;

        Debug.Log("setting level");
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
        foreach(Grid map in maps)
        {
            if (map.transform.parent != null)
                map.transform.parent.gameObject.SetActive(false);
            map.gameObject.SetActive(false);
        }

        if (maps[index].transform.parent != null)
            maps[index].transform.parent.gameObject.SetActive(true);
        maps[index].gameObject.SetActive(true);
    }

    public void ReturnToHub()
    {
        SceneManager.LoadScene("HubScene");
    }
}
