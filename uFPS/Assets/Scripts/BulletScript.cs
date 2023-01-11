using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(-Vector3.forward*100*Time.deltaTime);
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
