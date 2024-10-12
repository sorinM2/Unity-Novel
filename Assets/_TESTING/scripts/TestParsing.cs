using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TESTING
{
    public class TestParsing : MonoBehaviour
    {
        void Start()
        {
            SendFileToParse();
        }

       void SendFileToParse()
       {

            List<string> lines = FileManager.ReadTextAsset("testFile", false);
            foreach (string line in lines)
            {
                DIALOGUE_LINE dl = DialogueParser.Parse(line);
            }
       }
    }
}
