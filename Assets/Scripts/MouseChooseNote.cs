using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseChooseNote : MonoBehaviour
{
    [SerializeField] Light light;
    [SerializeField] Material material;
    [SerializeField] float intensityNotChoosen;
    [SerializeField] float intensityChoosen;
    Transform Player;
    [SerializeField] float distanceGrab; 
    ChangeWeapon ChangeWeaponScript;
    [SerializeField] Color ImageColorActive;
    [SerializeField] Color ImageColorNotActive;
    [SerializeField] Image image;

    [SerializeField] string noteText;
    [SerializeField] GameObject noteUI;
    [SerializeField] TMP_Text textUI;
    public Animator animator;

    public void PopUp()
    {
        animator.SetBool("pop", true);
    }

    private void Update()
    {
        if (animator.GetBool("pop") == true)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                PopDown();
            }
        }
    }
    public void PopDown()
    {
        animator.SetBool("pop", false);
    }


    private void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        ChangeWeaponScript = Player.GetComponent<ChangeWeapon>();
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
        if ((Player.position - transform.position).magnitude < distanceGrab)
        {
            image.color = ImageColorActive;
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
        if ((Player.position - transform.position).magnitude < distanceGrab)
        {
            image.color = ImageColorNotActive;
            OpenNote();
        }
    }

    private void OpenNote()
    {
        
        noteUI.SetActive(true);
        textUI.text = noteText;
        PopUp();
    }
}
