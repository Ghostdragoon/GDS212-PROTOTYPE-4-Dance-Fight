using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : Subject
{

    float yPosition;
    float noteCurrentLine;
    [SerializeField] Transform noteSpawnPosition;


     void Start()
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
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.DownArrow))
        {

            NotifyObservers(StartEvent.SpawnNoteA);

        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.RightArrow))
        {

            NotifyObservers(StartEvent.SpawnNoteB);

        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.LeftArrow))
        {

            NotifyObservers(StartEvent.SpawnNoteX);

        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton3) || Input.GetKeyDown(KeyCode.UpArrow))
        {

            NotifyObservers(StartEvent.SpawnNoteY);

        }



    }

    public void Movement()
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
