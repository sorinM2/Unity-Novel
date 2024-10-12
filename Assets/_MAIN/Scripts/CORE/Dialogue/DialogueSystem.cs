using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Dialogue
{
    public class DialogueSystem : MonoBehaviour
    {
        public DialogueContainer dialogueContainer = new DialogueContainer();
        private ConversationManager conversationManager;

        private TextArchitect architect;
        public static DialogueSystem instance { get; private set; }

        public delegate void DialogueSystemEvent();
        public event DialogueSystemEvent onUserPromtNext;
        public bool isRunningConversation => conversationManager.isRunning;
        public void Awake()
        {
            if (instance == null) { 
                instance = this;
                Initialize();
        }
            else DestroyImmediate(gameObject);

        }

        bool _initialized = false;
        private void Initialize()
        {
            if (_initialized) return;

            architect = new TextArchitect(dialogueContainer.dialogueText);
            conversationManager = new ConversationManager(architect);
        }

        public void OnUserPrompt_Next()
        {
            onUserPromtNext?.Invoke();
        }
        public void ShowSpeakerName(string name = "")
        {
            if (name.ToLower() != "narrator")
                dialogueContainer.nameContainer.Show(name);
            else HideSpeakerName();
        }
        public void HideSpeakerName() => dialogueContainer.nameContainer.Hide();

        public void Say(string speaker, string dialogue)
        {
            List<string> Conversation = new List<string>() { $"{speaker} \"{dialogue}\"" };
            Say(Conversation);
        }

        public void Say(List<string> conversation)
        {
            conversationManager.StartConversation(conversation);
        }
    }
}
