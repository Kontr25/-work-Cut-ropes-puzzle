using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        Vector3 LookPosition = new Vector3(_target.position.x, _target.position.y, _target.position.z - 10);
        transform.LookAt(LookPosition);
    }
}
