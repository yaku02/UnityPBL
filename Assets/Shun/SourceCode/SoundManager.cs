
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SoundManager : UdonSharpBehaviour
{
    [Header("ボタンを押したときのAudioSource")]
    [SerializeField] private AudioSource buttonAudioSource;

    [Header("アイテムを拾ったときのAudioSource")]
    [SerializeField] private AudioSource itemAudioSource;

    public void PlayButtonSound()
    {
        if (buttonAudioSource != null)
        {
            // 音を最初から重ねて再生する（連打されても途切れない）
            buttonAudioSource.PlayOneShot(buttonAudioSource.clip);
        }
    }

    // ★アイテムを拾ったときに他のスクリプトから呼び出す関数
    public void PlayItemSound()
    {
        if (itemAudioSource != null)
        {
            itemAudioSource.PlayOneShot(itemAudioSource.clip);
        }
    }
}
