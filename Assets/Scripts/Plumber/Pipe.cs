using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Rendering;

public class Pipe : MonoBehaviour
{
    public GameObject Shine;
    public bool isCorrect = false;
    public bool isMain = false;
    public byte state;
    public TrackedItemList trackedItems;
    public byte currentstate=0;
    public void Rotate()
    {
        byte stats= currentstate;
        this.gameObject.transform.Rotate(0, 0, 90);
        if (this.gameObject.transform.rotation.z == 0) { stats = 0; }
        else { stats += 1; }
        currentstate = stats;
    }
    private void Update()
    {
        if (currentstate == state)
        {
            isCorrect = true;
        }
        else 
        {
            isCorrect = false;
        }
        if (isCorrect)
        {
            Shine.SetActive(true);
        }
        else Shine.SetActive(false);

        if (!trackedItems.list.Contains(this.gameObject)){
            Shine.SetActive(false);
        }
    }
    private void Start()
    {
        Shine.SetActive (false);
    }


}