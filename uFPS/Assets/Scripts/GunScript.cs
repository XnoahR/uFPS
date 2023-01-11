using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

[SerializeField] public float _Damage;
[SerializeField] public float _Range;
[SerializeField] public float _FireRate;
public Camera FpsCam;
public ParticleSystem _MuzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    public virtual void Shoot(){
        _MuzzleFlash.Play();
       RaycastHit Hit;

       if(Physics.Raycast(FpsCam.transform.position,FpsCam.transform.forward,out Hit,_Range)){
        Debug.Log(Hit.transform.name);
       }
    }
}
