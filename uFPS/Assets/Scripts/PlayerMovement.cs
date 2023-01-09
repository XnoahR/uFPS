using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
public TextMeshProUGUI _SpeedText; 
//=====================================================//
    [Header("Player Movement")]
    [SerializeField] float _MoveSpeed;
    public Transform _PlayerOrientation;
    private float _Xmove;
    Rigidbody _Rigidbody;
    private float _Zmove;
    Vector3 _MoveDirection;
    Vector3 _CurrentMoveSpeed;
//=====================================================//
    [Header("Ground")]
    [SerializeField] float _PlayerHeight;
    [SerializeField] float _GroundDrag;
    [SerializeField] LayerMask WhatIsGround;
    [SerializeField] private bool Grounded;
//=====================================================//
    [Header("Jump")]
    [SerializeField] float _JumpForce;
    [SerializeField] float _JumpCooldown;
    [SerializeField] float _AirMultiplier;
    [SerializeField] private bool IsReadytoJump;

//=====================================================//
    // Start is called before the first frame update
    void Start()
    {
        _Rigidbody = GetComponent<Rigidbody>();
        _Rigidbody.freezeRotation = true;
        IsReadytoJump = true;
    }

    // Update is called once per frame
    void Update(){
        //GroundCheck
        /* Note: Bagian check ground dilakukan dengan menggunakan Raycast yang dimana
         akan melakukan pengecekan Ground dengan ukuran
         Setengah kali player dan ditambah 0.2f*/
        Grounded = Physics.Raycast(transform.position,Vector3.down,_PlayerHeight*0.5f+0.2f,WhatIsGround);

        MovementInput();
        SpeedControl();
        //Handle Drag
        if(Grounded){
            _Rigidbody.drag = _GroundDrag;
        }
        else
        _Rigidbody.drag = 0;

    }


    void FixedUpdate() {
        Movement();
    }
    void MovementInput()
    {
        //Input X dan Z Axis
        _Xmove = Input.GetAxisRaw("Horizontal");
        _Zmove = Input.GetAxisRaw("Vertical");

        //Jump Mechanic
        if(Input.GetKey(KeyCode.Space) && Grounded && IsReadytoJump){
            IsReadytoJump = false;
            Jump();
            Invoke("ResetJump",_JumpCooldown);
        }
    }
    
    void Movement(){
        //Menghitung Kecepatan Vector3 X dan Z axis
        _MoveDirection = _PlayerOrientation.forward * _Zmove + _PlayerOrientation.right*_Xmove;
        //Memberikan gaya untuk berjalan secara Continous(ForceMode.Force) apabila di Ground
        if(Grounded){
        _Rigidbody.AddForce(_MoveDirection.normalized*_MoveSpeed*10f,ForceMode.Force);
        }
        //Memberikan gaya saat di udara secara Continous
        else{
        _Rigidbody.AddForce(_MoveDirection.normalized*_MoveSpeed*10f*_AirMultiplier,ForceMode.Force);
        }
    }

    void SpeedControl(){
        //Note: Speed Control digunakan untuk mengstabilkan kecepatan yang dilakukan agar tetap pada batas maksimal kecepatan
        _CurrentMoveSpeed = new Vector3(_Rigidbody.velocity.x,0f,_Rigidbody.velocity.z);
        if(_CurrentMoveSpeed.magnitude > _MoveSpeed){
            Vector3 _LimitVelocity = _CurrentMoveSpeed.normalized * _MoveSpeed;
            _Rigidbody.velocity = new Vector3(_LimitVelocity.x,_Rigidbody.velocity.y,_LimitVelocity.z);
        }
        _SpeedText.text = "Speed : " + Mathf.Round(_CurrentMoveSpeed.magnitude).ToString();
    }

    void Jump(){
        //Mereset kecepatan(Velocity) dari y
        _Rigidbody.velocity = new Vector3(_Rigidbody.velocity.x,0f,_Rigidbody.velocity.z);
        //Memberi gaya lompatan, Note: ForceMode Impulse digunakan karena hanya sekali input saja
        _Rigidbody.AddForce(transform.up*_JumpForce,ForceMode.Impulse);
    }

    void ResetJump(){
        IsReadytoJump = true;
    }
}
