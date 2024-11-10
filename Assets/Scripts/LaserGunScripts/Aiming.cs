using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;

    private void Update()
    {
        Aim();
    }

    private void Aim()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), speed * Time.deltaTime);
    }
}
