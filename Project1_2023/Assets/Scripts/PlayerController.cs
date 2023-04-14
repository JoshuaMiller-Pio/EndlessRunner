using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject player = new GameObject();
    private Rigidbody _rigComp = new Rigidbody();
    private Animator _aniComp = new Animator();

    private Transform currentPos;
    private Transform nextPos;
    private float timeElapsed;

    
    void Start()
    {
        _rigComp = GetComponent<Rigidbody>();
        _aniComp = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //constant movement on the z-axis
        _rigComp.velocity = new UnityEngine.Vector3(_rigComp.velocity.x, _rigComp.velocity.y, 10);
        move();

    }

    public void move()
    {
        UnityEngine.Vector3 playerPos = transform.position;

        //allows the character to jump
        if (Input.GetKeyDown("space") || Input.GetKeyDown("w") || Input.GetKeyDown("up"))
        {
           
         
            _rigComp.velocity = new UnityEngine.Vector3(_rigComp.velocity.x, 5, _rigComp.velocity.z);
            Jumpstart();

        }
        float middle, left, right;
        middle = .81f;
        right = 6.58f;
        left = -5.17f;


        //will switch the character between the axis
        if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
        {
            rollleftStart();
            Debug.Log("left");
            if (playerPos.x == middle)
            {
                    transform.position = new UnityEngine.Vector3(-5.17f, transform.position.y, transform.position.z);
            }
            else if (playerPos.x == right)
            {
                    transform.position = new UnityEngine.Vector3(0.81f, transform.position.y, transform.position.z);
            }
        }

            if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {
            rollRightStart();
            Debug.Log("right");
            if (playerPos.x == left)
            {
                    transform.position = new UnityEngine.Vector3(0.81f, transform.position.y, transform.position.z);
            }
            else if (playerPos.x == middle)
            { 
                    transform.position = new UnityEngine.Vector3(6.58f, transform.position.y, transform.position.z);

            }

        }

    } 

    public void Jumpstart()
    {
        _aniComp.SetBool("isJumping", true);

    }
    public void JumpEnd()
    {
        _aniComp.SetBool("isJumping", false);

    }
    public void rollleftStart()
    {
        _aniComp.SetBool("rollLeft", true);

    }
    public void rollleftEnd()
    {
        _aniComp.SetBool("rollLeft", false);

    }
    public void rollRightStart()
    {
        _aniComp.SetBool("rollRight", true);

    }
    public void rollRightEnd()
    {
        _aniComp.SetBool("rollRight", false);

    }



}
