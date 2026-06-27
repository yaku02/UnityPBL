using UdonSharp;
using UnityEngine;
using VRC.Udon;

public class CheckObject : UdonSharpBehaviour
{
    [SerializeField] private SearchManager searchManager;

    [SerializeField]
    public GameObject canvas;
    private bool isNeverActive = false;

    public override void Interact()
    {
        if (isNeverActive) return;

        if (searchManager != null)
        {
            // 1. カウントをインクリメント (checkedCount++)
            searchManager.checkedCount++;

            // 2. 配列（checkedObject）にこのオブジェクトの名前を詰める
            // Udonの配列はC#標準の List<T> のように Add が使えないため、
            // 現在のカウント位置（あるいは末尾）のインデックスに直接代入します。
            int index = searchManager.checkedCount - 1; // 0スタートのインデックス

            // 配列のサイズを超えてエラーにならないように安全策を入れる
            if (searchManager.checkedObject != null && index < searchManager.checkedObject.Length)
            {
                searchManager.checkedObject[index] = gameObject.name;
            }
            Debug.Log($"[CheckObject] {gameObject.name} をチェックしました。現在のカウント: {searchManager.checkedCount}");
        }

        gameObject.SetActive(false);
        isNeverActive = true;
        if(canvas != null) canvas.SetActive(true);
    }

    public void CloseCanvas()
    {
        // キャンバスを非表示にする
        if (canvas != null)
        {
            canvas.SetActive(false);
        }
    }
}