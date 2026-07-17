
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SoundManager : UdonSharpBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buttonClip;
    [SerializeField] private AudioClip getClip;
    //[SerializeField] private AudioClip canvasClip;

    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonClip);
    }

    public void PlayGetSound()
    {
        audioSource.PlayOneShot(getClip);
    }

    /*public void PlayCanvasSound()
    {
        audioSource.PlayOneShot(canvasClip);
    }
    */
}
