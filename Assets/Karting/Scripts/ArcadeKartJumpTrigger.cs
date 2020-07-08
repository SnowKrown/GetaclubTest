using KartGame.KartSystems;
using UnityEngine;
using UnityEngine.Events;

public class ArcadeKartJumpTrigger : MonoBehaviour {

    public ArcadeKart.Jump jump = new ArcadeKart.Jump
    {
        MaxTime = 0.5F
    };

    public UnityEvent onActivated;

    private void OnTriggerEnter(Collider other)
    {
        var rb = other.attachedRigidbody;

        if (rb)
        {
            var kart = rb.GetComponent<ArcadeKart>();

            if (kart)
            { 
                kart.AddPowerup(jump);
                onActivated.Invoke();
            }
        }
    }

}
