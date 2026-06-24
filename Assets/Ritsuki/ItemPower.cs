using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

public class ItemPower : UdonSharpBehaviour
{
    public LineRenderer laser;
    public float distance = 50f;

    public override void OnPickupUseDown()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position,
                            transform.forward,
                            out hit,
                            distance))
        {
            laser.enabled = true;
            laser.SetPosition(0, transform.position);
            laser.SetPosition(1, hit.point);

            Debug.Log(hit.collider.gameObject.name);
        }
    }

    public override void OnPickupUseUp()
    {
        laser.enabled = false;
    }
}