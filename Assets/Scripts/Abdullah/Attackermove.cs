using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackermove : MonoBehaviour
{
    float noteCurrentLine;
    [SerializeField] Transform noteSpawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        noteSpawnPosition.position = new Vector3(noteSpawnPosition.position.x, noteCurrentLine, noteSpawnPosition.position.z);
        Movement();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            noteCurrentLine = 3.5f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            noteCurrentLine = 2.5f;
        }
        else
        {
            noteCurrentLine = 3f;
        }
    }
}
