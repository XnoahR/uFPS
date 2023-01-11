using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

[SerializeField] public float _Damage;
[SerializeField] public float _Range;
[SerializeField] public float _FireRate;
[SerializeField] public float _BulletForce;
public float _FireCooldown = 0;
public Camera FpsCam;
public ParticleSystem _MuzzleFlash;
public GameObject _BulletImpact;

    // Start is called before the first frame update

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShotInput();

    }

    protected virtual void ShotInput(){
        //Input Shot
    if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    protected virtual void Shoot(){
        //Play muzzle flash when get input
        _MuzzleFlash.Play();

        //Check hit object
       RaycastHit Hit;
       if(Physics.Raycast(FpsCam.transform.position,FpsCam.transform.forward,out Hit,_Range)){
        Debug.Log(Hit.transform.name);
        GameObject ImpactGO =  Instantiate(_BulletImpact,Hit.point,Quaternion.LookRotation(Hit.normal));
        Destroy(ImpactGO,0.5f);

        if(Hit.transform.tag == "box"){
            if(Hit.rigidbody != null){
                Hit.rigidbody.AddForce(-Hit.normal * 50f);
            }
        }
       }
    }
}
