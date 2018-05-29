using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    // Update is called once per frame
    void Update () {
        
	}
}
