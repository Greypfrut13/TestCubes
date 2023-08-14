using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private float _speed;
    private float _distance;

    private Rigidbody _rigidbody;

    private Vector3 _startPosition;

    private void Start() 
    {
        _rigidbody = GetComponent<Rigidbody>();

        _startPosition = transform.position;
    }

    private void Update() 
    {
        CheckTraveledDistance();
    }

    private void FixedUpdate() 
    {
        _rigidbody.velocity = transform.forward * _speed;
    }

    private void CheckTraveledDistance()
    {
        float traveledPosition = transform.position.z - _startPosition.z;

        if(traveledPosition >= _distance)
        {
            Destroy(gameObject);
        }
    }

    public void Init(float speed, float distance)
    {
        _speed = speed;
        _distance = distance;
    }
}
