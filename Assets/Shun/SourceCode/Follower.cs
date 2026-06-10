using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

public class Follower : UdonSharpBehaviour
{
    private Rigidbody rb;

    public float radius = 1.0f;
    public float moveSpeed = 2.0f;
    public float targetChangeInterval = 2.0f;
    public float offsetY = 2.0f;

    private VRCPlayerApi player;

    // プレイヤーからの相対位置
    private Vector3 localOffset;

    private float timer;

    public bool isPaused = false;

    public void Pause()
    {
        isPaused = true;
    }

    public void Resume()
    {
        isPaused = false;
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = Networking.LocalPlayer;
        PickNewOffset();
    }

    void FixedUpdate()
    {
        if (isPaused) return;
        if (player == null) return;

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

    }

    void Update()
    {
        if (isPaused) return;

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
        Vector2 circle = Random.insideUnitCircle * radius;

        localOffset = new Vector3(
            circle.x,
            Random.Range(-0.3f, 0.3f),
            circle.y
        );
    }
}