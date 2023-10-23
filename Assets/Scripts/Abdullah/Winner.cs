using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
    public GameObject P01;
    public Animator animator;

    public GameObject P02;
    public Animator animator2;

    public PlayerControl playerControl;
    public GameObject player;

   

    public int MissCountP01 = 0;
    public int MissCountP02 = 0;

    public AudioSource hitSound;
    public AudioSource victorySound;
    public AudioSource BGmusic;

    public GameObject Winner1;
    public GameObject Winner2;

    public GameObject Canvas;


    // Start is called before the first frame update
    void Start()
    {
        Winner1.SetActive(false);
        Winner2.SetActive(false);
        Canvas.SetActive(true);
        hitSound = GetComponent<AudioSource>();
        victorySound = GetComponent<AudioSource>();
        BGmusic = GetComponent<AudioSource>();
        BGmusic.Play();
        animator = P01.GetComponent<Animator>();
        animator2 = P02.GetComponent<Animator>();
        playerControl = player.GetComponent<PlayerControl>();
    }
    void Update()
    {
        WinnerDinner();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Note" && playerControl.P01isAttacking == true)
        {
            hitSound.Play();
            animator2.SetTrigger("IsHit");
            Destroy(other.gameObject);
            playerControl.KillCount += 1;
            MissCountP02 += 1;
            Debug.Log("P02 is Hit");
        }
        else if (other.gameObject.tag == "Note" && playerControl.P01isAttacking == false)
        {
            hitSound.Play();
            animator.SetTrigger("IsHit");
            Destroy(other.gameObject);
            playerControl.KillCount += 1;
            MissCountP01 += 1;
            Debug.Log("P01 is Hit");
        }
        if (playerControl.KillCount >= 10)
        {
            playerControl.defenseFinished = true;
            Debug.Log("player Switched");
            playerControl.SwitchTurn();
            playerControl.KillCount = 0;
        }
    }
    void WinnerDinner()
    {
     if (MissCountP02 >= 3)
        {
            victorySound.Play();
            animator.SetBool("HasWon",true);
            animator2.SetBool("HasLost",true);
            Debug.Log("P01 is the winner");
            Winner1.SetActive(true);
        }
        else if (MissCountP01 >= 3)
        {
            victorySound.Play();
            animator.SetBool("HasLost",true);
            animator2.SetBool("HasWon",true);
            Debug.Log("P02 is the winner");
            Winner2.SetActive(true);
        }
    }
}