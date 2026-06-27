
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ExecuteOnSignal : UdonSharpBehaviour
{
    // 最初から表示しておくか、隠しておくかをインスペクターで選べるようにします
    [Header("初期設定")]
    [SerializeField] private bool startActive = false;

    void Start()
    {
        // ゲーム開始時に、設定に合わせて表示・非表示を切り替える
        // (Unity上で最初から非アクティブにするとイベントが届かないための対策です)
        gameObject.SetActive(startActive);
    }

    // 外部から SendCustomEvent("Appear") で呼ばれる関数
    public void Appear()
    {
        // 自分自身をアクティブ（表示）にする
        gameObject.SetActive(true);

        Debug.Log($"[ExecuteOnSignal] {gameObject.name} が外部からの合図によって出現しました！");
    }
}