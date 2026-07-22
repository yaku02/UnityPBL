
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SearchObject : UdonSharpBehaviour
{
    [Header("インタラクトしたときに表示するキャンバス")]
    public GameObject targetCanvas;

    [Header("効果音再生クラス")]
    public SoundManager soundManager;

    void Start()
    {
        // ゲーム開始時にターゲットのキャンバスを自動で非表示（隠す）にする
        if (targetCanvas != null)
        {
            targetCanvas.SetActive(false);
        }
    }

    public override void Interact()
    {
        if(soundManager != null)
        {
            soundManager.PlayItemSound();
        }

        // 1. 指定されたキャンバスを表示（アクティブ）にする
        if (targetCanvas != null)
        {
            targetCanvas.SetActive(true);
        }

        // 2. 自分自身（インタラクトされたオブジェクト）を非表示（非アクティブ）にする
        gameObject.SetActive(false);
    }
}
