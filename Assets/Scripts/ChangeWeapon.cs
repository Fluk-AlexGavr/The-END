using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField] List<GameObject> weapons = new List<GameObject>();
    string lastWeaponName;
    public string weaponName;
    private void Start()
    {
        lastWeaponName = weaponName;
    }
    private void Update()
    {
        if( weaponName != lastWeaponName )
        {  
            foreach( GameObject weapon in weapons )
            {
                if (weapon.tag == weaponName)
                {
                    weapon.SetActive(true);
                }
                else
                {
                    weapon.SetActive(false);
                }
            }
            lastWeaponName = weaponName;
        }
    }
}
