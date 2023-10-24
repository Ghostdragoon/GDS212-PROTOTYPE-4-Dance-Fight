using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Note : Subject
{
    Rigidbody rg;
    public static float noteSpeed= 50;



    void Start()
    {

        rg = GetComponent<Rigidbody>();
        NoteSpeed();

    }
    private void NoteSpeed()
    {
        if(SwitchPlayers.switchTurn == false)
        {
            rg.AddForce(Vector3.left * noteSpeed);
        }
        else
        {
            rg.AddForce(Vector3.right * noteSpeed);

        }
    }



}
