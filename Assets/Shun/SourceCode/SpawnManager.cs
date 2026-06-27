
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SpawnManager : UdonSharpBehaviour
{
    [SerializeField] private VRCStation targetStation;

    void Start()
    {
        // ワールドに入場したローカルプレイヤー（自分）を取得
        VRCPlayerApi localPlayer = Networking.LocalPlayer;

        if (localPlayer != null && targetStation != null)
        {
            // プレイヤーを特定のStationに座らせる
            targetStation.UseStation(localPlayer);
        }
    }
}
