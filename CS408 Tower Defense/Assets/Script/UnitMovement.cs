using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitMovement : MonoBehaviour {

    protected CharacterController controller;
    protected Transform thisTransform;

    private float baseSpeed = 5.0f;
    private float baseGravity = 25.0f;

    public float Speed { get { return baseSpeed; } }
    public float Gravity { get { return baseGravity; } }
    public Vector3 MoveVector { set; get; }

    protected abstract void UpdateMovement();

	// Use this for initialization
	protected virtual void Start () {
        controller = gameObject.AddComponent<CharacterController>();
        thisTransform = transform;
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateMovement();
		
	}

    protected virtual void Move()
    {
        controller.Move(MoveVector * Time.deltaTime);
    }
}
