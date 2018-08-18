using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
public abstract class Character : MonoBehaviour
{

    #region Components

    public abstract MovementComponent MovementComponent { get; }

    public abstract JumpComponent JumpComponent { get; }

    public abstract DeathComponent DeathComponent { get; }

    #endregion

    /*
    public abstract string[] Actions { get; }

    public abstract string CurrentAction { get; }

    public abstract int CurrentActionIndex { get; }

    */

    public abstract WallCheck WallCheck { get; }

    public abstract GroundCheck GroundCheck { get; }

    public abstract Rigidbody2D Rigidbody2D { get; }

    public abstract Health Health { get; }

    //public abstract Collider2D Collider2D { get; }

   // public abstract Animator Animator { get; }

    //public abstract AudioSource Audio { get; }

    public abstract void Reset();

}
