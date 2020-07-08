using KartGame.KartSystems;
using UnityEngine;
using UnityEngine.Events;

public class ArcadeKartLoseControlTrigger : MonoBehaviour {

    public ArcadeKart.LoseControl loseControl = new ArcadeKart.LoseControl
    {
        MaxTime = 2
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
                kart.AddPowerup(loseControl);
                onActivated.Invoke();
            }
        }
    }

}
