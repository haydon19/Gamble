using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : EnemyBehaviour {

    float timeCounter = 0;

    public float speed;
    public float width;
    public float height;

    Vector3 startPos;

    public override void Start()
    {
        base.Start();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update () {
        timeCounter += Time.deltaTime *speed;

        float xWave = (Mathf.Cos(timeCounter) * width);
        float yWave = (Mathf.Sin(timeCounter) * height);

        if(yWave > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            GetComponent<SpriteRenderer>().flipX = false;

        }

        float x = startPos.x + xWave;
        float y = startPos.y + yWave;
        float z = startPos.z;

        transform.position = new Vector2(x, y);
    }
}
