using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class iswireactive : MonoBehaviour
{
    public bool isSource;
    public GameObject glow;
    public bool isTarget;
    public WireManager wireManager;
    public gridManager gridManager;
    public WireConnectionCheck check;
    public iswireactive[] adjacentPipes;
    public GameObject main;
    public bool checkConnections(iswireactive adjactentPipe)
    {
        Debug.Log("Checking Connection");
        int t=0, b=0, r=0, l=0;
        FindNearbyElements(t, b, r, l);
        GameObject top = gridManager.childObj[t].gameObject,
            bottom = gridManager.childObj[b].gameObject,
            left = gridManager.childObj[l].gameObject,
            right = gridManager.childObj[r].gameObject;
        WireConnectionCheck topp = top.GetComponent(typeof(WireConnectionCheck)) as WireConnectionCheck,
            bottomm = bottom.GetComponent(typeof(WireConnectionCheck)) as WireConnectionCheck,
            leftt = left.GetComponent(typeof(WireConnectionCheck)) as WireConnectionCheck,
            rightt = right.GetComponent(typeof(WireConnectionCheck)) as WireConnectionCheck;
        if (topp.bottomCon == true && check.topCon == true){return true;}
        if (rightt.LeftCon == true && check.RightCon == true){return true;}
        if (leftt.RightCon == true && check.LeftCon == true) { return true;}
        if (bottomm.topCon == true && check.bottomCon == true) { return true;}
        return false;
    }
    public void FindNearbyElements(int top, int bottom, int right, int left)
    {
        int x = 0, y = 0;
        gridManager.getcoord(x, y, main);
        gridManager.getindex(x, y + 1, top);
        gridManager.getindex(x, y - 1, bottom);
        gridManager.getindex(x - 1, y, left);
        gridManager.getindex(x + 1, y, right);
    }
    private void Start()
    {
        glow.SetActive(false);
    }
    public void StartWaterFlow()
    {
        Debug.Log("started");
        // For the first pipe (source), initiate the flow
        if (check.topCon || check.bottomCon || check.LeftCon || check.RightCon)
        {
            Debug.Log("initiate");
            // Flow can start, so check connected pipes
            foreach (iswireactive adjacent in adjacentPipes)
            {
                if (adjacent != null && adjacent.checkConnections(this))
                {
                    // Start flow to the connected adjacent pipe
                    glow.SetActive(true);
                    adjacent.StartWaterFlow();
                    
                }
                else
                {
                    // If no connection, stop the water flow
                    StopWaterFlow();
                }
            }
        }
    }
    public void StopWaterFlow()
    {
        Debug.Log("stopped");
    }
}
