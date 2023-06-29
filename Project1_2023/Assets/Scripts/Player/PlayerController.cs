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
    public AudioSource runAud_Comp, gruntAud_Comp,GunAud_Comp;
    private CapsuleCollider _colliderComp = new CapsuleCollider();
    private float timeElapsed;
    public GameObject bulletPrefab, bulletSpawn, Lugia, pauseMenuCanvas;
        bool winActive = false;
        bool kicktrigger =false;
    public bool paused;
   
    void Start()
    {    

        //creates new objects and adds components
          player = new GameObject();
        _rigComp = GetComponent<Rigidbody>();
        _aniComp = GetComponent<Animator>();
        _colliderComp = GetComponent<CapsuleCollider>();
        GameManager.Instance.lugia = Lugia;
        GameManager.Instance.player = gameObject;
        paused = false;
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
            GunAud_Comp.Play();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            PauseGame();
        }

        if (GameManager.Instance.win && !winActive)
        {
            VicAnim();
            winActive = true;
        }

        if (Kick.entered && !kicktrigger && !isgrounded())
        {
            KickTrue();
            kicktrigger = true;
            Kick.entered = false;
        }
        else if(Kick.entered && isgrounded())
        {
            Kick.entered = false;
        }


    }

    #region Pause Game

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuCanvas.SetActive(true);
        paused = true;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        paused = false;
    }

    #endregion
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
            UnityEngine.Vector3 MiddleTarget = new UnityEngine.Vector3(middle, -0.25f, transform.position.z + 10);
            UnityEngine.Vector3 LeftTarget = new UnityEngine.Vector3(left, -0.25f, transform.position.z + 10);

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
            UnityEngine.Vector3 MiddleTarget = new UnityEngine.Vector3(middle, -0.25f, transform.position.z +10);
            UnityEngine.Vector3 RightTarget = new UnityEngine.Vector3(right, -0.25f, transform.position.z+10);

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
        if (!GameManager.Instance.win)
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

    }

    //does a raycast that checks if the player is on the ground and returns a boolean value
    public  bool isgrounded()
    {
        return Physics.Raycast(transform.position, -transform.up, 0.1f);
        
    }

    #endregion


    #region Collision Evenets

    //if the player touches a object with the tag obstacle the object spawner list is cleared and the player OnplayerDeath method is called
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle" && !Shield.isShielded() )
        {
                OnPlayerDeath();

        } 

      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FireBall"  && (!isgrounded() || Shield.isShielded()) )
        {
            GameObject fireballReturn = other.gameObject;
            Rigidbody FireComp = fireballReturn.GetComponent<Rigidbody>();
            FireComp.AddForce(0, 13, 50, ForceMode.Impulse);


        }
         if (other.gameObject.tag == "FireBall" && (isgrounded() && !Shield.isShielded()))
        {
            OnPlayerDeath();

        }
    }



    #endregion
    #region GameOver
    // this method calls the gamemanager game over method which switches scenes
    private void OnPlayerDeath()
    {
        GameManager.Instance.GameOver();
    }
    #endregion


    //the rest are animatin calls
    #region ANIMATION CALLS
     void JumpTrue()
    {
       if(!_aniComp.GetBool("isJumping"))
       {
            JumpFalse();
            _aniComp.SetBool("isJumping", true);
            rollleftFalse();
            rollRightFalse();
            runAud_Comp.Pause();
            playGrunt();

        }



    }
     void JumpFalse()
    {
      
            _aniComp.SetBool("isJumping", false);
        playRun();
    }


     void rollleftTrue()
    {
        if (!_aniComp.GetBool("rollLeft"))
        {
            rollleftFalse();
            _aniComp.SetBool("rollLeft", true);
            JumpFalse();
            rollRightFalse();
            runAud_Comp.Pause();
            playGrunt();

        }

    }

     void rollleftFalse()
    {
          
            _aniComp.SetBool("rollLeft", false);
        playRun();


    }



    void rollrightTrue()
    {
        
        if (!_aniComp.GetBool("rollRight") )
        {
            rollRightFalse();
            _aniComp.SetBool("rollRight", true);
            rollleftFalse();
            JumpFalse();
            runAud_Comp.Pause();
            playGrunt();

        }

    }


     void rollRightFalse()
    {
        _aniComp.SetBool("rollRight", false);
        playRun();


    }
    void VicAnim()
    {
        _aniComp.SetBool("Win", true);
    }

    void KickTrue()
    {
        if (!_aniComp.GetBool("kick"))
        {
            runAud_Comp.Pause();
            KickFalse();
            _aniComp.SetBool("kick", true);
            JumpFalse();
        }
    } 
    void KickFalse()
    {
        _aniComp.SetBool("kick", false);
        playRun();
        kicktrigger = false;
        Kick.entered = false;
    }

    #endregion

    #region Audio
    void playRun()
    {
        runAud_Comp.Play();

    }
    void pauseRun()
    {
        runAud_Comp.Pause();

    }
    void playGrunt()
    {
        gruntAud_Comp.Play();

    }

    #endregion

}
