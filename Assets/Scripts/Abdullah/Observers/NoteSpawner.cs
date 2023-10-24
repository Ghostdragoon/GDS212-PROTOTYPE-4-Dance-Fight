using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour, IObserver
{
    [SerializeField] Subject subject;
    [SerializeField] GameObject[] buttonsNotes= new GameObject[4];
    
    public void OnNotify(StartEvent action)
    {
        switch (action)
        {
            case StartEvent.SpawnNoteA:

                SpawnNote(0, "A");

                break;
            case StartEvent.SpawnNoteB:

                SpawnNote(1, "B");

                break;
            case StartEvent.SpawnNoteX:

                SpawnNote(2, "X");

                break;
            case StartEvent.SpawnNoteY:

                SpawnNote(3, "Y");

                break;

        }

    }

    private void SpawnNote(int index,string button)
    {
        Debug.Log("NoteSpawner"+ button);
        Instantiate(buttonsNotes[index], transform.position, Quaternion.identity);



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
