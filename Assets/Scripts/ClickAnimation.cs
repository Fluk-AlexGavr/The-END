using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnimation : MonoBehaviour
{
    public Animator animator;
    [SerializeField]List<GameObject> distuctiveObjs = new List<GameObject>();

    private void Update()
    {
        foreach(GameObject obj in distuctiveObjs)
        {
            if (obj.activeInHierarchy)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    animator.SetBool("punch", true);
                }
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    animator.SetBool("punch", false);
                }
            }
        }      
    }
}
