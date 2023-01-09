using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] float _MouseSens;
    public Transform _PlayerOrientation;
    private float Yrotation;
    private float Xrotation;
    
    
        // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;        
    }

    // Update is called once per frame
    void Update()
    {

        //Get Mouse Input
        float _MouseX = Input.GetAxisRaw("Mouse X")*_MouseSens*Time.deltaTime;
        float _MouseY = Input.GetAxisRaw("Mouse Y")*_MouseSens*Time.deltaTime;

        Yrotation += _MouseX;
        Xrotation -= _MouseY; 
        Xrotation = Mathf.Clamp(Xrotation,-90f,90f);

        //Set the Rotation
        transform.rotation = Quaternion.Euler(Xrotation,Yrotation,0);
        _PlayerOrientation.rotation = Quaternion.Euler(0,Yrotation,0);
    }
}
