using UnityEngine;

public class Bagel : MonoBehaviour, IInteractable
{
    
    public void Interact()
    {
        GameEventsSystem.LoadUpdateScoreInteractionBagel(1);
        GameEventsSystem.LoadInteractionBagelSound();
        GameEventsSystem.LoadActiveBagelFromPool(1);
        GameEventsSystem.LoadSetCameraOffSet(1);
        GameEventsSystem.LoadPrintScore();
        Destroy(gameObject);
    }

    

}
