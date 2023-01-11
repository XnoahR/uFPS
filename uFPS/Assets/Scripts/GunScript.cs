using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
public GameObject bullet;
public Transform FirePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Shoot();
        }
    }

    void Shoot(){
        Instantiate(bullet,FirePoint.position,FirePoint.rotation);
    }
}