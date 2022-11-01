using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class MovementObject: MonoBehaviour, IMovement, IDistanceLimit
{

    private Rigidbody rb;

    private Transform _transform;
    private Vector3 currentPosition;

    private float speed;
    private float distance;

    public float Speed { get => speed; set => speed = value; }
    public float Distance { get => distance; set => distance = value; }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        currentPosition = _transform.position;
    }

    private void FixedUpdate()
    {
        Move(speed);
        DistanceLimit(distance);
    }

    public void Move(float speed)
    {
        rb.velocity = Vector3.forward * speed;
    }

    public void DistanceLimit(float distance)
    {
        if (Vector3.Distance(currentPosition, _transform.position) >= distance)
        {
            Destroy(this.gameObject);
        }
    }
}

