using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ClickManager : UdonSharpBehaviour
{
    [SerializeField] private GameObject targetCanvas;

    [SerializeField] private UdonBehaviour targetBehaviour;


    [SerializeField] private string onOpenEvent = "Pause";
    [SerializeField] private string onCloseEvent = "Resume";

    public override void Interact()
    {
        TalkCharacter();
    }

    // ★ TalkCharacter関数（外からも呼べる）
    public void TalkCharacter()
    {
        ToggleWithEvent(targetCanvas, targetBehaviour);
    }

    private void ToggleWithEvent(GameObject obj, UdonBehaviour behaviour)
    {
        if (obj == null) return;

        bool isActive = obj.activeSelf;

        // ON / OFF 切り替え
        obj.SetActive(!isActive);

        // イベント送信
        if (behaviour != null)
        {
            if (!isActive)
            {
                behaviour.SendCustomEvent(onOpenEvent);
            }
            else
            {
                behaviour.SendCustomEvent(onCloseEvent);
            }
        }
    }
}