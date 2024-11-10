using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pipeRotate : MonoBehaviour
{
    public string type;
    public WireManager wireManager;
    public GameObject main;
    public WireConnectionCheck check;
    // Start is called before the first frame update
    public void click()
    {
        main.transform.Rotate(0, 0, 90);

        if (wireManager.type[0] == type) 
        {
            if (main.transform.eulerAngles.z == 0 || main.transform.eulerAngles.z == 90)
            {
                check.LeftCon = true;
                check.RightCon = true;
                check.bottomCon = false;
                check.topCon = false;
            }
            else
            {
                check.topCon= true;
                check.bottomCon= true;
                check.LeftCon= false;
                check.RightCon= false;
            }

        };
        if (wireManager.type[1] == type)
        {
            if (main.transform.eulerAngles.z == 0)
            {
                check.RightCon= true;
                check.bottomCon = true;
                check.topCon = false;
                check.LeftCon = false;
            }
            if (main.transform.eulerAngles.z == 90)
            {
                check.bottomCon = true;
                check.LeftCon= true;
                check.RightCon = false;
                check.topCon = false ;
            }
            if (main.transform.eulerAngles.z == 180)
            {
                check.LeftCon=true;
                check.topCon=true;
                check.bottomCon=false;
                check.RightCon=false;
            }
            if (main.transform.eulerAngles.z == 270)
            {
                check.bottomCon= false;
                check.LeftCon = false;
                check.topCon = true;
                check.RightCon= true;
            }
        }
        if (wireManager.type[2]== type)
        {
            if(main.transform.eulerAngles.z == 0)
            {
                check.LeftCon = false;
                check.topCon = true;
                check.bottomCon = true;
                check.RightCon = true;
            }
            if (main.transform.eulerAngles.z == 90) 
            {
                check.bottomCon= true;
                check.RightCon= true;
                check.LeftCon = true;
                check.topCon = false;
            }
            if (main.transform.eulerAngles.z == 180) 
            {
                check.RightCon= true;
                check.LeftCon= true;
                check.topCon = true;
                check.bottomCon = false;
            }
            if (main.transform.eulerAngles.z == 270) 
            {
               check.LeftCon = true;
               check.topCon = true;
               check.RightCon = true;
            } 
        }
        if (wireManager.type[3]== type) 
        {
            check.topCon = true;
            check.bottomCon = true;
            check.LeftCon = true;
            check.RightCon = true;
        }

    }
}
