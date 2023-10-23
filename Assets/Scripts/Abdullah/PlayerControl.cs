using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : Subject
{

    float yPosition;
    float noteCurrentLine;
    [SerializeField] Transform noteSpawnPosition;

    private void Start()
    {
    }
    void Update()
    {
        yPosition = Input.GetAxisRaw("Vertical");
        noteSpawnPosition.position = new Vector3(noteSpawnPosition.position.x, noteCurrentLine, noteSpawnPosition.position.z);

        Movement();
        Attack();
        SwitchTurn();

    }

    private void SwitchTurn()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            NotifyObservers(StartEvent.SwitchPlayers);
            transform.localScale = new Vector3(transform.localScale.x * -1,
                                             transform.localScale.y,
                                             transform.localScale.z);
        }
    }

    private void Attack()
    {
        if (Input.GetButtonDown("Jump"))
        {

            NotifyObservers(StartEvent.SpawnNote);

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
