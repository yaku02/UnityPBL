using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI; // UIを制御するために追加

public class DialogueTrigger : UdonSharpBehaviour
{
    // 連動させる会話用Canvasのオブジェクト
    public GameObject dialogueCanvas;

    private bool isPlayerInside = false;
    private VRCPlayerApi localPlayer;

    void Start()
    {
        localPlayer = Networking.LocalPlayer;
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (player.isLocal) isPlayerInside = true;
    }

    public override void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        if (player.isLocal) isPlayerInside = false;
    }

    void Update()
    {
        // エリア内でFキーが押されたら
        if (isPlayerInside && Input.GetKeyDown(KeyCode.F))
        {
            ToggleDialogue();
        }
    }

    void ToggleDialogue()
    {
        if (dialogueCanvas != null)
        {
            bool isActive = !dialogueCanvas.activeSelf;
            dialogueCanvas.SetActive(isActive);

            // 会話中は動けないように固定、終わったら解除
            localPlayer.Immobilize(isActive);
        }
    }
}