using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeRandomScaleAndRotation : MonoBehaviour
{
    [SerializeField] float minSize;
    [SerializeField] float maxSize;
    private void Start()
    {
        float scale = Random.Range(minSize, maxSize);
        gameObject.transform.rotation = Quaternion.Euler(-90, 0, Random.Range(0f, 360f));
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
    }
}
