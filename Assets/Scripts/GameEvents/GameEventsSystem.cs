using UnityEngine.Events;

public class GameEventsSystem
{
    public static UnityAction<int> OnUpdateScoreInteractionBagel;
    public static UnityAction<int> OnActiveBagelFromPool;
    public static UnityAction<int> OnDeactiveBagelFromPool;
    public static UnityAction<int> OnSetCameraOffSet;
    public static UnityAction<int> OnUpdateScoreInteractionGate;
    public static UnityAction OnInteractionBagelSound;
    public static UnityAction OnInteractionPositiveGateSound;
    public static UnityAction OnInteractionNegativeGateSound;
    public static UnityAction OnGameOverSound;
    public static UnityAction OnPrintScore;
    public static UnityAction OnDie;



    public static void LoadUpdateScoreInteractionBagel(int value)
    {
        OnUpdateScoreInteractionBagel?.Invoke(value);
    }

    public static void LoadActiveBagelFromPool(int value)
    {
        OnActiveBagelFromPool?.Invoke(value);
    }

    public static void LoadDeactiveBagelFromPool(int value)
    {
        OnDeactiveBagelFromPool?.Invoke(value);
    }

    public static void LoadSetCameraOffSet(int value)
    {
        OnSetCameraOffSet?.Invoke(value);
    }

    public static void LoadUpdateScoreInteractionGate(int value)
    {
        OnUpdateScoreInteractionGate?.Invoke(value);
    }
    public static void LoadInteractionBagelSound()
    {
        OnInteractionBagelSound?.Invoke();
    }

    public static void LoadInteractionPositiveGateSound()
    {
        OnInteractionPositiveGateSound?.Invoke();
    }

    public static void LoadInteractionNegativeGateSound()
    {
        OnInteractionNegativeGateSound?.Invoke();
    }

    public static void LoadGameOverSound()
    {
        OnGameOverSound?.Invoke();
    }

    public static void LoadPrintScore()
    {
        OnPrintScore?.Invoke();
    }

    public static void LoadDie()
    {
        OnDie?.Invoke();
    }

}
