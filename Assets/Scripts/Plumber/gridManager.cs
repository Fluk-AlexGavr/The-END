using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridManager : MonoBehaviour
{
    public int SizeX;
    public int SizeY;
    public List<GameObject> childObj = new List<GameObject>();
    public GameObject parent;
    public void getcoord(int x, int y,GameObject obj)
    {
        int index = childObj.IndexOf(obj);
        x= index%SizeY;
        y= index/SizeY;
    }
    public void getindex(int x,int y, int index)
    {
        index =y*SizeX+x;
    }
    void getChildObj()
    {
        foreach (Transform g in parent.transform)
        {
            childObj.Add(g.gameObject);
            Debug.Log(g.gameObject);

        }
    }
    private void Start()
    {
        getChildObj();
    }
}
