using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCheck : MonoBehaviour
{
    WeaponManager _WeaponManager;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Primary")){
         
            Debug.Log("Hey its a gun!");
        }
    }
}
