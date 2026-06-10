using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ButtonManager : UdonSharpBehaviour
{
    // インスペクターから紐づける、消したり出したりしたいオブジェクト
    [SerializeField] private GameObject targetObject;

    // ボタンが押されたときに実行される関数（自分で自由に名前を決めてOK）
    public void OnButtonClick()
    {
        if (targetObject != null)
        {
            // 現在の状態を反転させる（!Activeにする）
            bool isActive = targetObject.activeSelf;
            targetObject.SetActive(!isActive);
        }
    }
}