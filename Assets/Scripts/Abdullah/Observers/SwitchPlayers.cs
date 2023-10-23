using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayers : MonoBehaviour, IObserver
{
    [SerializeField] Subject subject;
    static public bool switchTurn;

    // Start is called before the first frame update
    public void OnNotify(StartEvent action)
    {
        if (action == StartEvent.SwitchPlayers)
        {
            Debug.Log("SwitchPlayer");
            if (switchTurn == false)
            {

                switchTurn = true;
            }
            else if (switchTurn == true)
            {
                switchTurn = false;
            }

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
