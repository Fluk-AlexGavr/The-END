using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrackedItemList : MonoBehaviour
{
    public List<GameObject> list;
    [SerializeField]private PlumberManager plumberManager;
    bool check = true;

    public void CheckCorrected()
    {
        int a = 0;
        if (check)
        {
            foreach (var item in list)
            {
                if (!item.GetComponent<Pipe>().isCorrect == true)
                {
                    a = 1;
                }
            }

            if (a == 0)
            {
                plumberManager.isWin = true;
                check = false;
                return;
            }
        }
    }
    private void Update()
    {
        CheckCorrected();
    }
}
