using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathComponent : MonoBehaviour {

    public bool isDead;

    public delegate void DeadHandler();

    public virtual event DeadHandler OnDead;

}
