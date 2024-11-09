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

    private void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        ChangeWeaponScript = Player.GetComponent<ChangeWeapon>();
        image.color = ImageColorNotActive;
    }

    private void OnMouseEnter()
    {
        material.SetFloat("_Outline_Range", 1.05f);
        light.intensity = intensityChoosen;
        if ((Player.position - transform.position).magnitude < distanceGrab)
        {
            image.color = ImageColorActive;
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
            Destroy(gameObject);
            material.SetFloat("_Outline_Range", 1.05f);
            image.color = ImageColorNotActive;
            SetWeapon();
        }
    }

    private void SetWeapon()
    {
        print(gameObject.tag);
        ChangeWeaponScript.weaponName = gameObject.tag;
    }
}
