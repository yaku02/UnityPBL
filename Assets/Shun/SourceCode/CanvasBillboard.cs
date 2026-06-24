using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class CanvasBillboard : UdonSharpBehaviour
{
    private VRCPlayerApi player;

    void Start()
    {
        player = Networking.LocalPlayer;
    }

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 targetPos = player.GetPosition();

        // ★スフィアとは「逆向き」のベクトルを計算する（プレイヤー → 自分の方向）
        Vector3 direction = transform.position - targetPos;

        // Y軸だけ回転（上下は無視）
        direction.y = 0;

        if (direction.sqrMagnitude > 0.001f)
        {
            // この方向を向かせることで、キャンバスの表面がプレイヤーに正しく向きます
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}