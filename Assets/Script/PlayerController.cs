using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Varibles
    public float Speed;
    public float jumpForce;
    public float gravity = 9.807f;
    private float _FallVelocity = 0;
    private CharacterController _characterController;
    private Vector3 _moveVector;
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    private void Update()
    {
        _moveVector = Vector3.zero;


        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward * Speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward * Speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right * Speed;

        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right * Speed;
        }

        if (Input.GetKeyDown(KeyCode.Space)&& _characterController.isGrounded)
        {
            _FallVelocity = 0;
            _FallVelocity = -jumpForce;
        }
    }
    void FixedUpdate()
    {
        _characterController.Move( _moveVector * Speed * Time.fixedDeltaTime);
        _FallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _FallVelocity * Time.fixedDeltaTime);
    }
}
