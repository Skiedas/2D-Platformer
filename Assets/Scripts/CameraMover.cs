using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _offsetY;

    private void Update()
    {
        transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y + _offsetY, transform.position.z);
    }
}
