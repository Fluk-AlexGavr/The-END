using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseChoose : MonoBehaviour
{
    [SerializeField] Light light;
    [SerializeField] float intensityNotChoosen;
    [SerializeField] float intensityChoosen;
    private void OnMouseEnter()
    {
        light.intensity = intensityChoosen;
    }
    private void OnMouseExit()
    {
        light.intensity = intensityNotChoosen;
    }
}
