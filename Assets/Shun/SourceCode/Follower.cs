using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

public class Follower : UdonSharpBehaviour
{
    private Rigidbody rb;
    private TalkCharacter talkChar;

    public float radius = 1.0f;
    public float moveSpeed = 2.0f;
    public float targetChangeInterval = 2.0f;
    public float offsetY = 2.0f;
    public float cannotInsideRadius = 1.0f;

    private VRCPlayerApi player;

    // プレイヤーからの相対位置
    private Vector3 localOffset;

    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = Networking.LocalPlayer;

        talkChar = GetComponent<TalkCharacter>();

        PickNewOffset();
    }

    void FixedUpdate()
    {
        if (player == null) return;

        if (talkChar != null && talkChar.IsTalking())
        {
            return;
        }

        Vector3 center = player.GetPosition() + Vector3.up * offsetY;

        // 現在の目標地点
        Vector3 targetPos = center + localOffset;

        // 移動（離れていれば離れているほど早く移動）
        float distance = Vector3.Distance(rb.position, center);

        Vector3 nextPos = Vector3.MoveTowards(
            rb.position,
            targetPos,
            moveSpeed * Time.fixedDeltaTime * distance
        );

        rb.MovePosition(nextPos);

        Vector3 direction = targetPos - rb.position;

        direction.y = 0;

        if (direction.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // 現在の回転から、目標の回転へスムーズに補間
            float rotationSpeed = 5.0f;
            Quaternion nextRotation = Quaternion.Slerp(
                rb.rotation,
                targetRotation,
                rotationSpeed * Time.fixedDeltaTime
            );

            // Rigidbodyを使って回転を適用
            rb.MoveRotation(nextRotation);
        }

    }

    void Update()
    {
        if (talkChar != null && talkChar.IsTalking()) return;

            timer += Time.deltaTime;


        float distance = Vector3.Distance(
            rb.position,
            player.GetPosition() + Vector3.up * offsetY
        );

        float t = Mathf.Clamp01(distance / 3.0f);

        float dynamicInterval = Mathf.Lerp(
            targetChangeInterval * 2.0f,  // 近いとき（遅い）
            targetChangeInterval * 0.5f,  // 遠いとき（速い）
            t
        );

        if (timer >= dynamicInterval)
        {
            timer = 0.0f;
            PickNewOffset();
        }
    }

    private void PickNewOffset()
    {
        Vector2 circle = Vector2.zero;

        // 選ばれた位置の長さ（距離）が、入れない半径（cannotInsideRadius）より小さい間はループする
        int safetyNet = 0; // 万が一の無限増殖（フリーズ）対策
        do
        {
            circle = Random.insideUnitCircle * radius;
            safetyNet++;
        }
        while (circle.magnitude < cannotInsideRadius && safetyNet < 100);

        localOffset = new Vector3(
            circle.x,
            Random.Range(-0.3f, 0.3f),
            circle.y
        );
    }
}