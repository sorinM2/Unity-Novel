using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Dialogue
{
    public class ConversationManager 
    {
        private DialogueSystem dialogueSystem => DialogueSystem.instance;
        private Coroutine process = null;
        public bool isRunning => process != null;

        private TextArchitect architect = null;

        private bool userPromt = false;
        public ConversationManager(TextArchitect architect)
        {
            this.architect = architect;
            dialogueSystem.onUserPromtNext += OnUserPromt_Next ;
        }

        private void OnUserPromt_Next()
        {
            UnityEngine.Debug.Log("Action Happened");
            userPromt = true;
        }
        public void StartConversation(List<string> conversation)
        {
            StopConversation();

            process = dialogueSystem.StartCoroutine(RunningConversation(conversation));
        }

        public void StopConversation()
        {
            if (!isRunning)
                return;

            dialogueSystem.StopCoroutine(process);
            process = null;
            
        }

        IEnumerator RunningConversation(List<string> conversation)
        {
            for ( int i = 0; i < conversation.Count; ++i )
            {
                if (string.IsNullOrWhiteSpace(conversation[i])) 
                    continue;
                DIALOGUE_LINE line = DialogueParser.Parse(conversation[i]);

                //show dialogue
                if ( line.hasDialogue )
                   yield return Line_RunDialogue(line);

                //run commands
                if ( line.hasCommands )
                    yield return Line_RunCommands(line);

            }
        }

        IEnumerator Line_RunDialogue(DIALOGUE_LINE line)
        {
            if (line.hasSpeaker)
                dialogueSystem.ShowSpeakerName(line.speaker);
            else dialogueSystem.HideSpeakerName();

            yield return BuildDialogue(line.dialogue);

            yield return WaitForUserInput();

        }

        IEnumerator Line_RunCommands(DIALOGUE_LINE line) 
        {
            UnityEngine.Debug.Log(line);
            yield return null;
        }

        IEnumerator BuildDialogue(string dialogue)
        {
            architect.Build(dialogue);

            while (architect.isBuilding)
            {
                if (userPromt)
                {
                    if (!architect.hurryUp)
                        architect.hurryUp = true;
                    else architect.ForceComplete();

                    userPromt = false;
                }
                yield return null;
            }
        }

        IEnumerator WaitForUserInput()
        {
            while ( !userPromt)
                yield return null;
            userPromt = false;
        }

    }
}
