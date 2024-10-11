using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TESTING
{
    public class Testing_Architect : MonoBehaviour
    {
        DialogueSystem ds;
        TextArchitect architect;

        string[] lines = new string[5]
        {
            "This is a random line of dialogue.",
            "I want to say something, come over here.",
            "The world is a crazy place sometimes.",
            "Don't lose hope, this will get better.",
            "It's a bird? It's a plane? No, it's super Sorin!"
        };
        void Start()
        {
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            architect.buildMethod = TextArchitect.BuildMethod.typewriter;
            architect.speed = 0.5f;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if ( architect.isBuilding ) 
                {
                    if (!architect.hurryUp)
                        architect.hurryUp = true;
                    else architect.ForceComplete();
                }
                else architect.Build(lines[Random.Range(0, lines.Length)]);
            }
            else if (Input.GetKeyDown(KeyCode.A))
                architect.Append(lines[Random.Range(0, lines.Length)]);

        }
    }

}
