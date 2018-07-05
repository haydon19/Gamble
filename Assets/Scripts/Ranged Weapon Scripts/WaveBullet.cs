using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBullet : ProjectileBehaviour
{

    public float altitude = 5;

    public float frequency = 2;
    public float flyTime;
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        flyTime = 0;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        flyTime += Time.deltaTime;
        transform.position += transform.up * (Mathf.Cos(flyTime * frequency) * altitude);
    }

}
