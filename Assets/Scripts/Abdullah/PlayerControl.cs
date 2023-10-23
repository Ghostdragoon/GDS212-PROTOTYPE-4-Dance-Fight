using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerControl : Subject
{
    public GameObject P01;
    public Animator animator;

    public GameObject P02;
    public Animator animator2;

    public bool P01isAttacking = true;
    public bool defenseFinished = false;

    public int KillCount = 0;

    public AudioSource attackSound;
    public GameObject pauseMenu;
    public bool gamePaused = false;

  


    

    public int ammo = 10;

    private void Start()
    {
        pauseMenu.SetActive(false);
        attackSound = GetComponent<AudioSource>();   
        animator = P01.GetComponent<Animator>();
        animator2 = P02.GetComponent<Animator>();
    }
    void Update()
    {
        if (ammo > 0)
        {
        Attack();
        }
        if (ammo <= 0 && P01isAttacking == true && defenseFinished == true)
        {
            P01isAttacking = false;
            defenseFinished = false;
            ammo = 10;
        }
        else if (ammo <= 0 && P01isAttacking == false && defenseFinished == true)
        {
            P01isAttacking = true;
            defenseFinished = false;
            ammo = 10;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && gamePaused == false)
        {
            gamePaused = true;
            Debug.Log("Game Paused");
            PauseGame();
        }
        else if (gamePaused == true && Input.GetKeyDown(KeyCode.Escape))
        {
            gamePaused = false;
            Debug.Log("Game Resumed");
            ResumeGame();
        }
    }

    public void SwitchTurn()
    {
    NotifyObservers(StartEvent.SwitchPlayers);
    transform.localScale = new Vector3(transform.localScale.x * -1,
                                             transform.localScale.y,
                                             transform.localScale.z);
    }

    private void Attack()
    {
        if (Input.GetButtonDown("Jump") && P01isAttacking == true)
        {
            ammo -= 1;
            animator.SetTrigger("IsAttacking");
            NotifyObservers(StartEvent.SpawnNote);
            Debug.Log("P01 is attacking");
            attackSound.Play();
        }
        else if (Input.GetButtonDown("Jump") && P01isAttacking == false)
        {  
            ammo -= 1;
            animator2.SetTrigger("IsAttacking");
            NotifyObservers(StartEvent.SpawnNote);
            Debug.Log("P02 is attacking");
            attackSound.Play();
        }
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }


    
}
