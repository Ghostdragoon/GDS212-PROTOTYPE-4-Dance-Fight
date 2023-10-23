using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCounter : MonoBehaviour
{
    public GameObject P01;
    public Animator animator;

    public GameObject P02;
    public Animator animator2;

    public PlayerControl playerControl;
    public GameObject player;

    public AudioSource blockSound;
    


    // Start is called before the first frame update
    void Start()
    {
        blockSound = GetComponent<AudioSource>();
        animator = P01.GetComponent<Animator>();
        animator2 = P02.GetComponent<Animator>();
        playerControl = player.GetComponent<PlayerControl>();
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Note" && playerControl.P01isAttacking == true)
        {
            blockSound.Play();
            animator2.SetTrigger("IsBlocking");
            Destroy(other.gameObject);
            playerControl.KillCount += 1;
            Debug.Log("P02 is blocking");
        }
        else if (other.gameObject.tag == "Note" && playerControl.P01isAttacking == false)
        {
            blockSound.Play();
            animator.SetTrigger("IsBlocking");
            Destroy(other.gameObject);
            playerControl.KillCount += 1;
            Debug.Log("P01 is blocking");
        }
        if (playerControl.KillCount >= 10)
        {
            playerControl.defenseFinished = true;
            Debug.Log("player Switched");
            playerControl.SwitchTurn();
            playerControl.KillCount = 0;
        }
    }
}


