using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookScript : MonoBehaviour
{
    // Start is called before the first frame update

 
    public CharacterController _CharacterController;
    private Vector2 _Turn;
    private float Xrotation = 0f;
    [SerializeField] float _MovementSpeed;
    [Range(0f,100f)]
    [SerializeField] float _MouseSensitivity = 100f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
     Movement();
     Rotation();
    }

    void Movement(){
        float _MoveX = Input.GetAxis("Horizontal");
        float _MoveZ = Input.GetAxis("Vertical");

        Vector3 _CharacterMovement = new Vector3(_MoveX,-1f,_MoveZ);
        _CharacterMovement = transform.TransformDirection(_CharacterMovement);
        if(_MoveX == 0 && _MoveZ==0){
            _CharacterMovement = Vector3.zero;
                    }
        _CharacterController.Move(_CharacterMovement * _MovementSpeed *Time.deltaTime);
    }
    void Rotation(){
    _Turn.x += Input.GetAxis("Mouse X")*_MouseSensitivity*Time.deltaTime;
    _Turn.y = Input.GetAxis("Mouse Y")*_MouseSensitivity*Time.deltaTime;
    Xrotation -= _Turn.y;//Minus agar tidak Invert dan stuck
    Xrotation = Mathf.Clamp(Xrotation,-60f,60f);//Limit ke 60 derajat
   transform.localRotation = Quaternion.Euler(Xrotation,_Turn.x,0f);
    //  _CharacterBody.Rotate(Vector3.up*_MouseX);
    }
}
