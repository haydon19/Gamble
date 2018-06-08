using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTracker : MonoBehaviour {
    public FinishPoint goalFlag;
    PlayerController player;
    public GameObject arrow;
	// Use this for initialization
	void Start () {
        player = GetComponentInParent<PlayerController>();
        //goalFlag = GameManager.instance.goalFlag;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if(Mathf.Abs(Vector2.Distance(goalFlag.transform.position, player.transform.position)) < 3)
        {
            arrow.SetActive(false);
        }
        else
        {
            arrow.SetActive(true);
        }

        Vector2 difference = goalFlag.transform.position - player.transform.position;

        //var angle = Mathf.Atan2(difference.x, difference.y * Mathf.Rad2Deg - 90);

        var angle = Mathf.Atan2(difference.y, difference.x) * 180 / Mathf.PI;
        //print("Angle " + angle + " AngleDeg " + angleDeg);

        transform.rotation = Quaternion.Euler(0, 0, angle);

    }
}
