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

    public bool P01isAttacking = true;
    public int KillCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        animator = P01.GetComponent<Animator>();
        animator2 = P02.GetComponent<Animator>();
        playerControl = player.GetComponent<PlayerControl>();
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Note" && playerControl.P01isAttacking == true)
        {
            animator2.SetTrigger("IsBlocking");
            Destroy(other.gameObject);
            KillCount += 1;
            Debug.Log("P02 is blocking");
        }
        else if (other.gameObject.tag == "Note" && playerControl.P01isAttacking == false)
        {
            animator.SetTrigger("IsBlocking");
            Destroy(other.gameObject);
            KillCount += 1;
            Debug.Log("P01 is blocking");
        }
        if (KillCount >= 10)
        {
            playerControl.SwitchTurn();
            KillCount = 0;
        }
    }
}


