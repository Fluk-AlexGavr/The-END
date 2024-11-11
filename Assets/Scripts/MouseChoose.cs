using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseChoose : MonoBehaviour
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

    private void OnMouseUp()
    {
        if ((Player.position - transform.position).magnitude < distanceGrab)
        {
            
            image.color = ImageColorNotActive;
            SetWeapon();
            Destroy(gameObject);
            
        }
    }

    private void SetWeapon()
    {
        print(gameObject.tag);
        audioSource.Play();
        ChangeWeaponScript.weaponName = gameObject.tag;
    }

    private void OnDestroy()
    {
        image.color = ImageColorNotActive;
    }
}
