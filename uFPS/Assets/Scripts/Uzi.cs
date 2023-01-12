using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi : GunScript
{

  
    void Awake() {
    this._Damage = 15;
        this._Range = 100;
        this._FireRate = 20;
        this._BulletForce = 10f;
   }
    
    protected override void ShotInput()
    {
        if(Input.GetButton("Fire1") && Time.time >= _FireCooldown){
            _FireCooldown = Time.time + 1f/_FireRate;
            Shoot();
        }
    }

}
