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
    [SerializeField] AudioSource audioSource;
    [SerializeField] string noteText;
    [SerializeField] GameObject noteUI;
    [SerializeField] TMP_Text textUI;
    public Animator animator;
    [SerializeField] MeshRenderer OutlineRender;

    private void Awake()
    {
        material = new Material(material);
        OutlineRender.material = material;
    }
    public void PopUp()
    {
        animator.SetBool("pop", true);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q)) { 
            
            PopDown();

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
            if (!noteUI.activeInHierarchy) 
            {
            OpenNote();
            }
            
        }
    }

    private void OpenNote()
    {
        audioSource.Play();
        noteUI.SetActive(true);
        textUI.text = noteText;
        PopUp();
    }
}
