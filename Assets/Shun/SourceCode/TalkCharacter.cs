using UdonSharp;
using UnityEngine;
using VRC.Udon;

public class TalkCharacter : UdonSharpBehaviour
{
    public GameObject choiceCanvas;
    public GameObject[] textCanvases; // インスペクターで TextCanvas, (1), (2) を登録

    [HideInInspector] public int resultIndex = 0;

    public override void Interact()
    {
        if (IsTalking())
        {
            CloseAllCanvases();
        }
        else
        {
            OpenChoice();
        }
    }

    // 選択肢を開く処理
    public void OpenChoice()
    {
        CloseAllCanvases();
        if (choiceCanvas != null)
            choiceCanvas.SetActive(true);
    }

    // 各選択肢ボタンから結果画面へ切り替える処理
    public void ShowResult()
    {
        if (choiceCanvas != null)
            choiceCanvas.SetActive(false);

        // 指定された番号のテキストキャンバスだけを表示
        if (textCanvases != null && resultIndex >= 0 && resultIndex < textCanvases.Length)
        {
            if (textCanvases[resultIndex] != null)
                textCanvases[resultIndex].SetActive(true);
        }
    }

    public void ShowResult0() { resultIndex = 0; ShowResult(); }
    public void ShowResult1() { resultIndex = 1; ShowResult(); }
    public void ShowResult2() { resultIndex = 2; ShowResult(); }
    public void ShowResult3() { resultIndex = 3; ShowResult(); }

    private void CloseAllCanvases()
    {
        if (choiceCanvas != null)
            choiceCanvas.SetActive(false);

        if (textCanvases != null)
        {
            foreach (GameObject canvas in textCanvases)
            {
                if (canvas != null)
                    canvas.SetActive(false);
            }
        }
    }

    // 現在、会話UIが開いているかどうかを判定する関数
    public bool IsTalking()
    {
        if (choiceCanvas != null && choiceCanvas.activeSelf)
            return true;

        if (textCanvases != null)
        {
            foreach (GameObject canvas in textCanvases)
            {
                if (canvas != null && canvas.activeSelf)
                    return true;
            }
        }

        return false;
    }

}