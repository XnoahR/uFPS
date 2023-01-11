using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMaster : MonoBehaviour
{
    [SerializeField] private int _CurrentWeaponIndex;

    // Start is called before the first frame update
    void Start()
    {
        SwitchWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int _PreviousWeapon = _CurrentWeaponIndex;
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            _CurrentWeaponIndex = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >=2){
            _CurrentWeaponIndex = 1;
        }
        //if(Input.GetKeyDown(KeyCode.Alpha1) && transform.childCount >=2){
       // }

        if(_PreviousWeapon != _CurrentWeaponIndex){
            SwitchWeapon();
        }


    }

    void SwitchWeapon(){
        int i = 0;
        foreach(Transform Weapon in transform){
            if(i == _CurrentWeaponIndex){
                Weapon.gameObject.SetActive(true);
            }
            else{
                Weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
