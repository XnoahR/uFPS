
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
   public GameObject[] Weapons = new GameObject[3];
    [SerializeField] int _CurrentIndex;
    [SerializeField] int _PreviousIndex;
    private void Start() {
        _CurrentIndex = 0;
        _PreviousIndex = _CurrentIndex;
        SwitchWeapon();
    }
    private void Update() {
        InputWeapon();
        
    }

    void InputWeapon(){
        _PreviousIndex = _CurrentIndex;

        if(Input.GetKeyDown(KeyCode.Alpha1) && Weapons[0].transform.childCount >=1){
            _CurrentIndex = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2 )&& Weapons[1].transform.childCount >=1){
            _CurrentIndex = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)&& Weapons[2].transform.childCount >=1){
            _CurrentIndex = 2;
        }
        
        if(_PreviousIndex != _CurrentIndex){
            SwitchWeapon();
        }
    }

    void SwitchWeapon(){
        int i = 0;
        foreach(GameObject x in Weapons){
            if(i == _CurrentIndex){
                x.gameObject.SetActive(true);
            }
            else{
                x.gameObject.SetActive(false);
            }
        i++;
        }


    }

    
}
