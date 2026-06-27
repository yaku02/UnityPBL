
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SearchManager : UdonSharpBehaviour
{
    public string[] checkedObject; // インスペクターであらかじめ最大数分の要素数（Size）を確保しておく必要があります
    public int checkedCount = 0;

    void Start()
    {
        
    }
}
