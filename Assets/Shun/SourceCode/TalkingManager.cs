
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TalkingManager : UdonSharpBehaviour
{
    private TalkCharacter currentSpeaker;
    private bool isManagerTalking = false;
    private bool isShowingResult = false;

    // キャラクターがクリックされたときに実行される
    public void OnCharacterClicked(TalkCharacter speaker)
    {
        // 会話中ならクリックで閉じる
        if (speaker.isTalking)
        {
            CloseAll();
            return;
        }

        if (isManagerTalking) return;

        currentSpeaker = speaker;
        isManagerTalking = true;

        currentSpeaker.isTalking = true;

        // 選択肢キャンバスを表示する
        if (currentSpeaker.choiceCanvas != null) currentSpeaker.choiceCanvas.SetActive(true);
    }

    // UIの選択肢ボタンからOnClickで呼ばれる関数（結果キャンバスへ切り替え）
    public void OnChoiceSelected()
    {
        if (currentSpeaker == null) return;

        if (currentSpeaker.choiceCanvas != null) currentSpeaker.choiceCanvas.SetActive(false);
        if (currentSpeaker.textCanvas != null) currentSpeaker.textCanvas.SetActive(true);

        isShowingResult = true;
    }

    // 全てを非表示にして動きを再開する
    private void CloseAll()
    {
        if (currentSpeaker.choiceCanvas != null) currentSpeaker.choiceCanvas.SetActive(false);
        if (currentSpeaker.textCanvas != null) currentSpeaker.textCanvas.SetActive(false);

        currentSpeaker.isTalking = false;

        currentSpeaker = null;
        isManagerTalking = false;
        isShowingResult = false;
    }
}