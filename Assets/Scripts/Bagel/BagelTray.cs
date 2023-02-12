using UnityEngine;

public class BagelTray : MonoBehaviour
{
    private void OnEnable() => GameEventsSystem.OnDie += Destroy;

    private void Destroy()
    {
        Destroy(gameObject);
    }    
}
