using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : GunScript
{
    void Awake() {
    this._Damage = 25;
        this._Range = 150;
        this._FireRate = 10f;
        this._BulletForce = 20f;
   }

    protected override void ShotInput()
    {
        if(Input.GetButton("Fire1") && Time.time >= _FireCooldown){
            _FireCooldown = Time.time + 1f/_FireRate;
            Shoot();
        }
    }

}
