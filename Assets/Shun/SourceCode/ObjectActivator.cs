
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ObjectActivator : UdonSharpBehaviour
{
    [Header("アクティブにしたいオブジェクト")]
    public GameObject[] targetObjects;

    public void ActivateTarget()
    {
        if (targetObjects != null)
        {
            // foreach文を使って、配列に登録されたすべてのオブジェクトをループ処理で有効化する
            foreach (GameObject target in targetObjects)
            {
                if (target != null)
                {
                    target.SetActive(true);
                }
            }
        }
    }
}
