using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float chaseSpeed = 5;

    private void Start()
    {
        if (!target)
        {
            target = GameObject.FindObjectOfType<Movement>().transform;
        }
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, chaseSpeed * Time.deltaTime);
    }

}
