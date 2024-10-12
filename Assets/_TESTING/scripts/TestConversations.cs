using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConversations : MonoBehaviour
{
    void Start()
    {
        StartConversation();
    }

    void StartConversation()
    {

        List<string> lines = FileManager.ReadTextAsset("testFile", false);

        DialogueSystem.instance.Say(lines);
    }
}
