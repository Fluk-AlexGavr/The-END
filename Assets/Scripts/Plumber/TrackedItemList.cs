using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrackedItemList : MonoBehaviour
{
    public List<GameObject> list;

    public void CheckCorrected()
    {
        int a = 0;
        foreach(var item in list)
        {
            if (!item.GetComponent<Pipe>().isCorrect == true)
            {
                a = 1;
            }
        }
        if (a == 0)
        {
            return;
        }

    }
    private void Update()
    {
        CheckCorrected();
    }
}
