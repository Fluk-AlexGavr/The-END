using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseChooseTerminal : MonoBehaviour
{
    [SerializeField] Light light;
    [SerializeField] Material material;
    [SerializeField] float intensityNotChoosen;
    [SerializeField] float intensityChoosen;
    Transform Player;
    [SerializeField] float distanceGrab; 
    ChangeWeapon ChangeWeaponScript;
    [SerializeField] Color ImageColorActive;
    [SerializeField] Color ImageColorActiveButNotActive;
    [SerializeField] Color ImageColorNotActive;
    [SerializeField] Image image;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject noteUI;
    public Animator animator;
    [SerializeField] float terminalDistance;
    public bool isOpen=false;
    public TerminalProvider terminalProvider;
    public bool canActivate;
    public TerminalProvider otherTerminal;
    public void PopUp()
    {
        animator.SetTrigger("Pop");
    }

    private void Update()
    {
        if ((Player.position - transform.position).magnitude >= terminalDistance)
                {
                    noteUI.SetActive(false);
        }

        if(!canActivate)
        {
            canActivate = otherTerminal.isWin;
        }

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
        light.intensity = intensityChoosen;
    }
    private void OnMouseOver()
    {
        if ((Player.position - transform.position).magnitude < distanceGrab && canActivate)
        {
            image.color = ImageColorActive;
        }
        else if((Player.position - transform.position).magnitude < distanceGrab)
        {
            image.color = ImageColorActiveButNotActive;
        }
        else
        {
            image.color = ImageColorNotActive;
        }
    }
    private void OnMouseExit()
    {
        material.SetFloat("_Outline_Range", 0.05f);
        light.intensity = intensityNotChoosen;
        image.color = ImageColorNotActive;
    }

    private void OnMouseDown()
    {

        if ((Player.position - transform.position).magnitude < distanceGrab && terminalProvider.isWin == false && canActivate) 
        {
            image.color = ImageColorNotActive;
            if (!isOpen)
            {
                print(terminalProvider.isWin);
                OpenNote();
            }
            
        }
    }

    private void OpenNote()
    {

        isOpen= true;
        print("open terminal");
        Cursor.lockState = CursorLockMode.None;
        Player.GetComponent<FirstPersonMovement>().enabled = false;
        Player.GetComponent<PlayerFootstepSounds>().enabled = false;
        noteUI.SetActive(true);
        PopUp();
    }
}
