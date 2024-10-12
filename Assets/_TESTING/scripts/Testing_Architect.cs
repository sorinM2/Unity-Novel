using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dialogue;

namespace TESTING
{
    public class Testing_Architect : MonoBehaviour
    {
        DialogueSystem ds;
        TextArchitect architect;

        public  TextArchitect.BuildMethod bm = TextArchitect.BuildMethod.instant;
        string[] lines = new string[5]
        {
            "This is a random line of dialogue.",
            "I want to say something, come over here.",
            "The world is a crazy place sometimes.",
            "Don't lose hope, this will get better.",
            "It's a bird? It's a plane? No, it's super Sorin!"
        };

        string longline = "This is a very long line of text that actually doesnt say anything important but i need to write stuff because i like stuff and everyone likes stuff";
        void Start()
        {
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            architect.buildMethod = TextArchitect.BuildMethod.fade;
            architect.speed = 1f;
        }

        void Update()
        {
            if ( architect.buildMethod != bm)
            {
                architect.ForceComplete();
                architect.Stop();
                architect.buildMethod = bm;
            }
            if (Input.GetKeyDown(KeyCode.X))
                architect.Stop();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if ( architect.isBuilding ) 
                {
                    if (!architect.hurryUp)
                        architect.hurryUp = true;
                    else architect.ForceComplete();
                }
                else architect.Build(longline);
            }
            else if (Input.GetKeyDown(KeyCode.A))
                architect.Append(lines[Random.Range(0, lines.Length)]);

        }
    }

}
