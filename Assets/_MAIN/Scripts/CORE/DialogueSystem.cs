using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueSystem : MonoBehaviour
{
    public DialogueContainer dialogueContainer = new DialogueContainer();
    public static DialogueSystem instance;

    public void Awake() 
    {
        if (instance == null)
            instance = this;
        else DestroyImmediate(gameObject); 
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
