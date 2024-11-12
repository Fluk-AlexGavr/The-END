using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneRandomScaleRotation : MonoBehaviour
{
    [SerializeField] float minSize;
    [SerializeField] float maxSize;
    private void Start()
    {
        Vector3 scale = new Vector3(Random.Range(minSize, maxSize), Random.Range(minSize, maxSize), Random.Range(minSize, maxSize));
        gameObject.transform.rotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
        gameObject.transform.localScale = scale;
        gameObject.GetComponent<Rigidbody>().mass = Mathf.Round(scale.magnitude*12);
    }
}
