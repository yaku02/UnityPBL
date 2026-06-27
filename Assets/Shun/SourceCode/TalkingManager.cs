using UdonSharp;
using UnityEngine;
using VRC.Udon;

public class TalkingManager : UdonSharpBehaviour
{
    [SerializeField]
    private TalkCharacter initialSpeaker;

    private TalkCharacter currentSpeaker;

    void Start()
    {
        if (initialSpeaker != null)
        {
            currentSpeaker = initialSpeaker;
            currentSpeaker.OpenChoice();
        }
    }

    public void OnCharacterClicked(TalkCharacter speaker)
    {
        if (currentSpeaker == speaker)
        {
            currentSpeaker.Close();
            currentSpeaker = null;
            return;
        }

        if (currentSpeaker != null)
            return;

        currentSpeaker = speaker;
        currentSpeaker.OpenChoice();
    }

    public void EndConversation()
    {
        currentSpeaker = null;
    }
}