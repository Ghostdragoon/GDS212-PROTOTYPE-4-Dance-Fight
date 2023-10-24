using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SwitchPlayers : Subject, IObserver
{
    [SerializeField] Subject subject;
    [SerializeField] GameObject[] playerState= new GameObject[2];
    [SerializeField] GameObject[] notesSpawner;
    static public bool switchTurn;
    int increaseDiffuclty= 0;

    // Start is called before the first frame update
    public void OnNotify(StartEvent action)
    {
        if (action == StartEvent.SwitchPlayers)
        {
            switch (switchTurn)
            {
                case false:
                    {
                        for (int i = 0; playerState.Length > i; i++)
                        {
                            if (playerState[i].activeSelf == false)
                            {
                                playerState[i].SetActive(true);
                            }
                            else playerState[i].SetActive(false);
                        }
                        switchTurn = true;
                        break;
                    }

                case true:
                    switchTurn = false;
                    for (int i = 0; playerState.Length > i; i++)
                    {
                        if (playerState[i].activeSelf == false)
                        {
                            playerState[i].SetActive(true);
                        }
                        else playerState[i].SetActive(false);
                    }
                    break;
            }

            increaseDiffuclty++;
            Debug.Log("SwitchPlayer " + "  increaseDiffuclty:" + increaseDiffuclty);

            for (int i=0; notesSpawner.Length > i; i++)
            { 
                    var spawner = notesSpawner[i].GetComponent<NoteSpawner>();
                if (spawner.enabled == true)
                {
                    spawner.enabled = false;
                }
                else spawner.enabled = true;

            }




        }
        if (increaseDiffuclty > 1)
        {
            increaseDiffuclty = 0;
            Note.noteSpeed += 50;
        }

    }
    private void OnEnable()
    {
        subject.AddObserver(this);
    }
    private void OnDisable()
    {
        subject.RemoveObserver(this);
    }



}
