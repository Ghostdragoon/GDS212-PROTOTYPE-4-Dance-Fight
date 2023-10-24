using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteCounter : Subject
{
    [SerializeField] bool isDefender;

    [SerializeField] TextMeshProUGUI ScoreTeam1, ScoreTeam2;
    int scoreLeft, scoreRight=0;
    [SerializeField] int winningScore;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Note")
        {
            if (SwitchPlayers.switchTurn==true && isDefender== false)
            {
                scoreLeft++;
                ScoreTeam2.text = scoreLeft.ToString();
                Destroy(other.gameObject);

            }
            else if (SwitchPlayers.switchTurn==false && isDefender == false)
            {
                scoreRight++;
                ScoreTeam1.text = scoreRight.ToString();
                Destroy(other.gameObject);

            }
            Destroy(other.gameObject);
        }

        if (scoreRight == winningScore)
        {
            NotifyObservers(StartEvent.RightTeamWin);
        }
        else if (scoreLeft == winningScore)
        {
            NotifyObservers(StartEvent.LeftTeamWin);
        }



    }






}
