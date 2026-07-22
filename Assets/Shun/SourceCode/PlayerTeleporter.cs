
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PlayerTeleporter : UdonSharpBehaviour
{
    [Header("テレポート先のオブジェクト")]
    [SerializeField] private Transform teleportTarget;

    // コライダー（Trigger）に何かが入ったときに呼ばれるイベント
    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        // トリガーに入ったのが「ローカルプレイヤー（自分自身）」の場合のみ実行
        if (player != null && player.isLocal)
        {
            // プレイヤーを指定の位置と角度にテレポートさせる
            player.TeleportTo(teleportTarget.position, teleportTarget.rotation);
        }
    }
}