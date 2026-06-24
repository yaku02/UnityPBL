
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SimpleBillboard : UdonSharpBehaviour
{

    private VRCPlayerApi player;

    [SerializeField] private float rotationSpeed = 3.0f;

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
            Quaternion lookAtPlayerRotation = Quaternion.LookRotation(direction);
            Quaternion targetRotation = lookAtPlayerRotation * Quaternion.Euler(0, 180f, 0);

            // 現在の回転から目標の回転へ滑らかに近づける
            transform.rotation = Quaternion.Slerp(
                            transform.rotation,
                            targetRotation,
                            rotationSpeed * Time.deltaTime
            );
        }
    }
}

