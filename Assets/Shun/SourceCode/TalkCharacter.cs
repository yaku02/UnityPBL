
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

// このスクリプトを貼ったら、自動で SimpleBillboard も強制的に追加する設定
[RequireComponent(typeof(SimpleBillboard))]
public class TalkCharacter : UdonSharpBehaviour
{
    [SerializeField] private TalkingManager talkingManager;

    private SimpleBillboard billboard;

    // このキャラクターが持っている2つのキャンバス
    public GameObject choiceCanvas;
    public GameObject textCanvas;

    [HideInInspector] public bool isTalking = false;

    void Start()
    {
        // ビルボードコンポーネントを取得
        billboard = GetComponent<SimpleBillboard>();

        // 初期状態（会話してないとき）はビルボードをオフにしておく
        if (billboard != null) billboard.enabled = false;
    }

    void Update()
    {
        if (billboard != null)
        {
            // isTalking が true なら enabled も true、false なら false になる
            billboard.enabled = isTalking;
        }
    }

    public override void Interact()
    {
        if (talkingManager != null)
        {
            // マネージャーに「私がクリックされました」と通知する
            talkingManager.OnCharacterClicked(this);
        }
    }
}