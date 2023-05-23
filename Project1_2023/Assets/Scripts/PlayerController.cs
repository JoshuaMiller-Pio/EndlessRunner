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
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
   
    void Start()
    {    

        //creates new objects and adds components
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

        //calls the ButtonMovement() method
        ButtonMovement();

        if (Input.GetMouseButtonDown(0) && GunPickUp.isStrapped() == true)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            GunPickUp.Shoot();

        }

    }


    #region MOVEMENT
    public void ButtonMovement()
    {
        //gets the current position of the player
        UnityEngine.Vector3 playerPos = transform.position;

        float middle, right, left;  

        //the x values of the players lanes
        middle = .81f;
        right = 6.58f;
        left = -5.17f;

        //if space, w or the up arrow is pressed and the player is on the ground the player will jump with a velocity of 5
        if ((Input.GetKeyDown("space") || Input.GetKeyDown("w") || Input.GetKeyDown("up")) && isgrounded())
        {
            _rigComp.velocity = new UnityEngine.Vector3(_rigComp.velocity.x, 5, _rigComp.velocity.z);
            //the jump animation is called
            JumpTrue();
        }

            //will switch the character between the axis
        if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
        {
            //the roll left animation is called
            if (!_aniComp.GetBool("isJumping"))
            {
                rollleftTrue();
            }

            //the middle and left lane is given a vecoter3 variable and coordinates
            UnityEngine.Vector3 MiddleTarget = new UnityEngine.Vector3(middle, transform.position.y, transform.position.z + 10);
            UnityEngine.Vector3 LeftTarget = new UnityEngine.Vector3(left, transform.position.y, transform.position.z + 10);

            if (playerPos.x == middle )
            {
                //starts the lerp coroutine that moves the player from the middle lane to the left lane
                StartCoroutine(MoveLerp(LeftTarget));

            }
            else if (playerPos.x == right )
            //starts the lerp coroutine that moves the player from the right lane to the middle lane
            {
                StartCoroutine(MoveLerp(MiddleTarget));
            }
   
        }

        if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {
            if (!_aniComp.GetBool("isJumping"))
            {
                rollrightTrue();
            }
            UnityEngine.Vector3 MiddleTarget = new UnityEngine.Vector3(middle, transform.position.y, transform.position.z +10);
            UnityEngine.Vector3 RightTarget = new UnityEngine.Vector3(right, transform.position.y, transform.position.z+10);

            if (playerPos.x == middle )
            {
                //starts the lerp coroutine that moves the player from the middle lane to the right lane

                StartCoroutine(MoveLerp(RightTarget));

            }
            else if (playerPos.x == left )
            {
                //starts the lerp coroutine that moves the player from the left lane to the middle lane

                StartCoroutine(MoveLerp(MiddleTarget));
            }


        }


    }

    IEnumerator MoveLerp(UnityEngine.Vector3 TargetPos)
    {
        float time = 0;
        //this get the players current position on the track
        UnityEngine.Vector3 CurrentPos = transform.position;

        //while time is less than 1 second the loop will continue, the player will slowly slide across the gap to the next lane
        while (time < 1)
        {
            transform.position = UnityEngine.Vector3.Lerp(CurrentPos, TargetPos, time / 1);
            time += Time.deltaTime;
            //this stops the coroutine until the next frame
            yield return null;
        }
        //at the end of the while this will snap the player to the target position
        transform.position = TargetPos;

    }

    //does a raycast that checks if the player is on the ground and returns a boolean value
    public  bool isgrounded()
    {
        return Physics.Raycast(transform.position, -UnityEngine.Vector3.up, (_colliderComp.bounds.extents.y  + 0.001f));
    }

#endregion


    #region GAMEOVER

    //if the player touches a object with the tag obstacle the object spawner list is cleared and the player OnplayerDeath method is called
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            if (Shield.isShielded() == false)
            {
                ObjectSpawner.spawnedObjects.Clear();
                OnPlayerDeath();
            }
            
        }
    }

    // this method calls the gamemanager game over method which switches scenes
    private void OnPlayerDeath()
    {
        GameManager.Instance.GameOver();
    }

    #endregion


    //the rest are animatin calls
    #region ANIMATION CALLS
    public void JumpTrue()
    {
       if(!_aniComp.GetBool("isJumping"))
       {
            JumpFalse();
            _aniComp.SetBool("isJumping", true);
            rollleftFalse();
            rollRightFalse();

           
       }
      


    }
    public void JumpFalse()
    {
      
            _aniComp.SetBool("isJumping", false);
        
    }


    public void rollleftTrue()
    {
        if (!_aniComp.GetBool("rollLeft"))
        {
            rollleftFalse();
            _aniComp.SetBool("rollLeft", true);
            JumpFalse();
            rollRightFalse();

        }
        
    }

    public void rollleftFalse()
    {
          
            _aniComp.SetBool("rollLeft", false);
        
    }



    public void rollrightTrue()
    {
        
        if (!_aniComp.GetBool("rollRight") )
        {
            rollRightFalse();
            _aniComp.SetBool("rollRight", true);
            rollleftFalse();
            JumpFalse();
        }
       
    }


    public void rollRightFalse()
    {
        _aniComp.SetBool("rollRight", false);

    }

    #endregion

}
