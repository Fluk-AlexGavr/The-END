using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeScript : MonoBehaviour
{
    float[] rotations = { 0, 90, 180, 270 };
    private void Start()
    {
        int rand = UnityEngine.Random.Range(0,rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);
    }
    private void OnMouseDown()
    {
        transform.rotation *= Quaternion.Euler(0, 0, 90);
        print("entered");
    }

}
