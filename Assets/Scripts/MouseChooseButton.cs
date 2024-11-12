using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class MouseChooseButton: MonoBehaviour
{
    [SerializeField] Material material;
    Transform Player;
    [SerializeField] float distanceGrab; 
    [SerializeField] Color ImageColorActive;
    [SerializeField] Color ImageColorActiveButNotAllowedAccess;
    [SerializeField] Color ImageColorNotActive;
    [SerializeField] Image image;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Animator animator;
    [SerializeField] Shot ShotScript;
    private bool accessAlowed;
    [SerializeField] TerminalProvider terminalProvider;
    
    public void PopUp()
    {
        animator.SetBool("pop", true);
    }

    private void Update()
    {
        if (animator.GetBool("pop") == true)
        {
                    PopDown();
        }
        if(accessAlowed == false) 
        {
            accessAlowed = terminalProvider.isWin;
        }
    }
    public void PopDown()
    {
        animator.SetBool("pop", false);
    }


    private void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        image.color = ImageColorNotActive;
        material.SetFloat("_Outline_Range", 0.05f);
    }

    private void OnMouseEnter()
    {
        material.SetFloat("_Outline_Range", 1.05f);
    }
    private void OnMouseOver()
    {
        if ((Player.position - transform.position).magnitude < distanceGrab && accessAlowed)
        {
            image.color = ImageColorActive;
        }
        else if((Player.position - transform.position).magnitude < distanceGrab)
        {
            image.color = ImageColorActiveButNotAllowedAccess;
        }
        else
        {
            image.color = ImageColorNotActive;
        }
    }
    private void OnMouseExit()
    {
        material.SetFloat("_Outline_Range", 0.05f);
        image.color = ImageColorNotActive;
    }

    private void OnMouseDown()
    {
        if ((Player.position - transform.position).magnitude < distanceGrab)
        {
            image.color = ImageColorNotActive;
            ButtonClick();
        }
    }

    private void ButtonClick()
    {
        if(accessAlowed)
        {
            ShotScript.buttonClick = true;
        }
        audioSource.Play();
        animator.SetTrigger("Click");
        PopUp();
    }
}
