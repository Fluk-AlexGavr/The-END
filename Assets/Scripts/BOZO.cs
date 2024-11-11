using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOZO : MonoBehaviour
{
    [SerializeField]AudioSource audioSource;
    private int count;
    public void click()
    {
        print("click");
        if (count > 5)
        {
            audioSource.Play();
        }
        else
        {
            count++;
        }
    }
}
