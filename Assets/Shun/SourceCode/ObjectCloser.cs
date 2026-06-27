
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ObjectCloser : UdonSharpBehaviour
{
    [Header("無効化するオブジェクト")]
    [Tooltip("指定がない場合は一つ上の親オブジェクトを無効化します")]
    public GameObject[] targetObjects;

    public void CloseTarget()
    {
        if (targetObjects != null && targetObjects.Length > 0)
        {
            foreach (GameObject target in targetObjects)
            {
                if (target != null)
                {
                    target.SetActive(false);
                }
            }
        }
        else
        {
            // 指定がない場合は親を閉じる
            if (transform.parent != null)
            {
                transform.parent.gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

}
