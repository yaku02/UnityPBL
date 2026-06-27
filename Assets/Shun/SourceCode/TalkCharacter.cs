using UdonSharp;
using UnityEngine;
using VRC.Udon;

[RequireComponent(typeof(SimpleBillboard))]
public class TalkCharacter : UdonSharpBehaviour
{
    [SerializeField] private TalkingManager talkingManager;
    private SimpleBillboard billboard;

    public GameObject choiceCanvas;
    public GameObject[] textCanvases;

    // ★外部からセットするためのパブリック変数を用意
    [HideInInspector] public int resultIndex = 0;

    void Start()
    {
        billboard = GetComponent<SimpleBillboard>();
        if (billboard != null) billboard.enabled = false;
    }

    void Update()
    {
        if (billboard != null) billboard.enabled = IsTalking();
    }

    public override void Interact()
    {
        talkingManager.OnCharacterClicked(this);
    }

    public void OpenChoice()
    {
        if (choiceCanvas != null) choiceCanvas.SetActive(true);
    }

    // ★引数なしのShowResult内で、resultIndexを使って処理する
    public void ShowResult()
    {
        if (choiceCanvas != null)
            choiceCanvas.SetActive(false);

        // 配列の範囲内か安全確認をしてから表示
        if (textCanvases != null && resultIndex >= 0 && resultIndex < textCanvases.Length)
        {
            if (textCanvases[resultIndex] != null)
                textCanvases[resultIndex].SetActive(true);
        }

        Debug.Log($"Showed Result Index: {resultIndex}");
    }

    public void Close()
    {
        if (choiceCanvas != null) choiceCanvas.SetActive(false);

        if (textCanvases != null)
        {
            foreach (GameObject canvas in textCanvases)
            {
                if (canvas != null) canvas.SetActive(false);
            }
        }

        talkingManager.EndConversation();
    }

    public bool IsTalking()
    {
        if (choiceCanvas != null && choiceCanvas.activeSelf) return true;
        if (textCanvases != null)
        {
            foreach (GameObject canvas in textCanvases)
            {
                if (canvas != null && canvas.activeSelf) return true;
            }
        }
        return false;
    }
}