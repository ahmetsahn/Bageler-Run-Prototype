using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField] 
    private AudioSource gameBackgroundSound;

    [SerializeField]
    private AudioClip bagelSound;

    [SerializeField]
    private AudioClip positiveGateSound;

    [SerializeField]
    private AudioClip negativeGateSound;

    [SerializeField]
    private AudioClip gameOverSound;

    private void OnEnable() => AddListeners();

    private void OnDisable() => RemoveListeners();
    
    private void StopBackgroundSound() => gameBackgroundSound.Stop();

    private void PlayBagelSound() => audioSource.PlayOneShot(bagelSound);

    private void PlayPositiveGateSound() => audioSource.PlayOneShot(positiveGateSound);

    private void PlayNegativeGateSound() => audioSource.PlayOneShot(negativeGateSound);

    private void PlayGameOverSound() => audioSource.PlayOneShot(gameOverSound);

    private void AddListeners()
    {
        GameEventsSystem.OnInteractionBagelSound += PlayBagelSound;
        GameEventsSystem.OnInteractionPositiveGateSound += PlayPositiveGateSound;
        GameEventsSystem.OnInteractionNegativeGateSound += PlayNegativeGateSound;
        GameEventsSystem.OnGameOverSound += PlayGameOverSound;
        GameEventsSystem.OnDie += StopBackgroundSound;
    }

    private void RemoveListeners()
    {
        GameEventsSystem.OnInteractionBagelSound -= PlayBagelSound;
        GameEventsSystem.OnInteractionPositiveGateSound -= PlayPositiveGateSound;
        GameEventsSystem.OnInteractionNegativeGateSound -= PlayNegativeGateSound;
        GameEventsSystem.OnGameOverSound -= PlayGameOverSound;
        GameEventsSystem.OnDie -= StopBackgroundSound;
    }



}
