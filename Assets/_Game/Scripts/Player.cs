using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : Character
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject player;
    private bool unmove = false;
    private Vector3 moveVector;
    private void FixedUpdate()
    {
        //_rigidbody.velocity = new Vector3(_joystick.Horizontal * moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * moveSpeed);

        moveVector.x = _joystick.Horizontal * moveSpeed;
        if (!unmove) moveVector.z = _joystick.Vertical * moveSpeed;
        else
        {
            if (_joystick.Vertical > 0) moveVector.z = 0;
            else moveVector.z = _joystick.Vertical * moveSpeed;
        }
        _rigidbody.MovePosition(moveVector * moveSpeed + transform.position);
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(_joystick.Horizontal, 0, _joystick.Vertical));
        }

    }
    private void OnTriggerEnter(Collider other)
    {
  
        if (other.CompareTag(conststring.BRICK)
            && other.GetComponent<Brick>().mycolor == GetComponent<Character>().colorCharater)
        {
            Addbrick(other.gameObject);
        }
        if (other.CompareTag(conststring.BRIDGEBRICK))
        {
            BridgeBrick bridgeBrick = other.GetComponent<BridgeBrick>();
            if(bridgeBrick.isreceived== true&& colorCharater!= bridgeBrick.brickColor&& listBrick.Count > 0)
            {
                ReturnBrick(other.gameObject);
                bridgeBrick.brickColor = colorCharater;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(conststring.BRIDGEBRICK))
        {
            BridgeBrick bridgeBrick = other.GetComponent<BridgeBrick>();
            if ((bridgeBrick.isreceived == false || bridgeBrick.brickColor != colorCharater) && listBrick.Count == 0)
                unmove = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(conststring.BRIDGEBRICK))
        {
            BridgeBrick bridgeBrick = other.GetComponent<BridgeBrick>();
            if ((bridgeBrick.isreceived == false || bridgeBrick.brickColor != colorCharater) && listBrick.Count == 0)
            unmove = true;
        }
    }
    
}

