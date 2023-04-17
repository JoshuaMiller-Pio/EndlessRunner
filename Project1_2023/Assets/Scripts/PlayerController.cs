using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject player;
    private Rigidbody _rigComp = new Rigidbody();
    private Animator _aniComp = new Animator();
    private CapsuleCollider _colliderComp = new CapsuleCollider();
    private float timeElapsed;
   
    
    void Start()
    {
          player = new GameObject();
        _rigComp = GetComponent<Rigidbody>();
        _aniComp = GetComponent<Animator>();
        _colliderComp = GetComponent<CapsuleCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        //constant movement on the z-axis
        _rigComp.velocity = new UnityEngine.Vector3(_rigComp.velocity.x, _rigComp.velocity.y, 10);

        lerpmove();
  

    }



    public void lerpmove()
    {
        UnityEngine.Vector3 playerPos = transform.position;
        float middle, right, left;  
        middle = .81f;
        right = 6.58f;
        left = -5.17f;

        if ((Input.GetKeyDown("space") || Input.GetKeyDown("w") || Input.GetKeyDown("up")) && isgrounded())
        {
            _rigComp.velocity = new UnityEngine.Vector3(_rigComp.velocity.x, 5, _rigComp.velocity.z);
            Jump();
        }

            //will switch the character between the axis
        if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
        {
            rollleft();
            UnityEngine.Vector3 MiddleTarget = new UnityEngine.Vector3(middle, transform.position.y, transform.position.z + 10);
            UnityEngine.Vector3 LeftTarget = new UnityEngine.Vector3(left, transform.position.y, transform.position.z + 10);

            if (playerPos.x == middle)
            {
                StartCoroutine(MoveLerp(LeftTarget));

            }
            else if (playerPos.x == right)
            {
                StartCoroutine(MoveLerp(MiddleTarget));
            }
   
        }

        if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {
            rollRight();
            UnityEngine.Vector3 MiddleTarget = new UnityEngine.Vector3(middle, transform.position.y, transform.position.z +10);
            UnityEngine.Vector3 RightTarget = new UnityEngine.Vector3(right, transform.position.y, transform.position.z+10);

            if (playerPos.x == middle)
            {
                StartCoroutine(MoveLerp(RightTarget));

            }
            else if (playerPos.x == left)
            {
                StartCoroutine(MoveLerp(MiddleTarget));
            }


        }


    }

    private  bool isgrounded()
    {
        return Physics.Raycast(transform.position, -UnityEngine.Vector3.up, (_colliderComp.bounds.extents.y  + 0.1f)); 
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            ObjectSpawner.spawnedObjects.Clear();
            OnPlayerDeath();
        }
    }

    private void OnPlayerDeath()
    {

       
    
        GameManager.Instance.GameOver();


    }

    IEnumerator MoveLerp( UnityEngine.Vector3 TargetPos)
    {
        float time = 0;
        UnityEngine.Vector3 CurrentPos = transform.position;

        while(time < 1)
        {
            transform.position = UnityEngine.Vector3.Lerp(CurrentPos, TargetPos, time / 1);
            time += Time.deltaTime;
            yield return null;
        }
      
         transform.position = TargetPos;
        
    }
    public void Jump()
    {
       if(_aniComp.GetBool("isJumping") == false)
       {
        _aniComp.SetBool("isJumping", true);

       }
       else
       {
            _aniComp.SetBool("isJumping", false);
       }


    }
    public void rollleft()
    {
        if (_aniComp.GetBool("rollLeft") == false)
        {
            _aniComp.SetBool("rollLeft", true);

        }
        else
        {
            _aniComp.SetBool("rollLeft", false);
        }
        

    }
    public void rollRight()
    {
        
        if (_aniComp.GetBool("rollRight") == false)
        {
            _aniComp.SetBool("rollRight", true);
        }
        else
        {
            _aniComp.SetBool("rollRight", false);
        }
    }




}
