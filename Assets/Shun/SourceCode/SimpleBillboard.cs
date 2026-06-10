
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SimpleBillboard : UdonSharpBehaviour
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

        // 自分 → プレイヤー方向
        Vector3 direction = transform.position - targetPos; 

        // Y軸だけ回転（上下は無視）
        direction.y = 0;

        if (direction.sqrMagnitude > 0.001f)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}

