
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SpawnManager : UdonSharpBehaviour
{
    [SerializeField] private VRCStation targetStation;
    private VRCPlayerApi localPlayer;

    void Start()
    {
        // ワールドに入場したローカルプレイヤー（自分）を取得
        localPlayer = Networking.LocalPlayer;

        if (localPlayer != null && targetStation != null)
        {
            // プレイヤーを特定のStationに座らせる
            targetStation.UseStation(localPlayer);
            localPlayer.Immobilize(true);

        }
    }
    // ボタンから呼び出す
    public void ReleasePlayer()
    {
        if (localPlayer == null) return;

        localPlayer.Immobilize(false);

        if (targetStation != null)
        {
            targetStation.ExitStation(localPlayer);
        }
    }

}
