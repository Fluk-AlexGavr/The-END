using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpSystem : MonoBehaviour
{
    public Animator animator;

    public void PopUp()
    {
        animator.SetTrigger("pop");
    }
}
