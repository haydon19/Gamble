using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBullet : Projectile
{

    public float altitude = 5;

    public float frequency = 2;
    public float flyTime;
    // Use this for initialization
      void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
