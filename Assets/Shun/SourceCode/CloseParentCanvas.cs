
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class CloseParentCanvas : UdonSharpBehaviour
{
    public void CloseCanvas()
    {
        // ボタン自身の親（Transform）を上に遡って Canvas コンポーネントを探す
        Canvas parentCanvas = GetComponentInParent<Canvas>();

        if (parentCanvas != null)
        {
            // 見つかった Canvas のゲームオブジェクトを非表示にする
            parentCanvas.gameObject.SetActive(false);
        }
    }
}
