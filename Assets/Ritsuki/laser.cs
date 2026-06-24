using UdonSharp;
using UnityEngine;

public class laser : UdonSharpBehaviour
{
    public LineRenderer laserLine;

    public override void OnPickupUseDown()
    {
        laserLine.enabled = true;

        laserLine.SetPosition(0, transform.position);
        laserLine.SetPosition(
            1,
            transform.position + transform.forward * 20f
        );

        SendCustomEventDelayedSeconds(
            nameof(HideLaser),
            0.2f
        );
    }

    public void HideLaser()
    {
        laserLine.enabled = false;
    }
}