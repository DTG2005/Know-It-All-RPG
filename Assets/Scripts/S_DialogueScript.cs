using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;

public class S_DialogueScript : MonoBehaviour
{
    public List<List<string>> dialogue = new List<List<string>>{};
    public S_MovementScript mvmscrpt;
    // Start is called before the first frame update
    void Start()
    {
        List<string> Lis1 = new List<string>{"Agent", "Hello"};
        List<string> Lis2 = new List<string>{"Agent", "How are you doing today?"};
        dialogue.Add(Lis1);
        dialogue.Add(Lis2);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
            Debug.Log("Collided!");
            mvmscrpt.Dialogue = true;
            mvmscrpt.CurrentDialogueChar = this;
        }
    }
    void OnTriggerExit(Collider collider){
        if(collider.gameObject.tag == "Player"){
            Debug.Log("Collided!");
            mvmscrpt.Dialogue = false;
            mvmscrpt.CurrentDialogueChar = null;
        }
    }
    
}
