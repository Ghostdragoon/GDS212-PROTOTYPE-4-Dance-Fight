using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : Subject
{
    public GameObject P01;
    public Animator animator;

    public GameObject P02;
    public Animator animator2;

    public bool P01isAttacking = true;
    public bool defenseFinished = false;


    float yPosition;
    float noteCurrentLine;
    [SerializeField] Transform noteSpawnPosition;

    public int ammo = 10;

    private void Start()
    {
        animator = P01.GetComponent<Animator>();
        animator2 = P02.GetComponent<Animator>();
    }
    void Update()
    {
        yPosition = Input.GetAxisRaw("Vertical");
        noteSpawnPosition.position = new Vector3(noteSpawnPosition.position.x, noteCurrentLine, noteSpawnPosition.position.z);

        Movement();
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
        }
        else if (Input.GetButtonDown("Jump") && P01isAttacking == false)
        {  
            ammo -= 1;
            animator2.SetTrigger("IsAttacking");
            NotifyObservers(StartEvent.SpawnNote);
            Debug.Log("P02 is attacking");
        }
    }

    private void Movement()
    {
        if (yPosition > 0.01)
        {
            noteCurrentLine = 3.5f;
        }
        else if (yPosition < -0.01)
        {

            noteCurrentLine = 2.5f;
        }
        else
        {
            noteCurrentLine = 3f;
        }
    }
}
