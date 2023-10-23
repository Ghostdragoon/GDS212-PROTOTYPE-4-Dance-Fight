using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour, IObserver
{
    [SerializeField] Subject subject;
    [SerializeField] GameObject buttonsSequance;
    public void OnNotify(StartEvent action)
    {
        if (action== StartEvent.SpawnNote) 
        { 
        Debug.Log("NoteSpawner");
        Instantiate(buttonsSequance,transform.position,Quaternion.identity);
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
