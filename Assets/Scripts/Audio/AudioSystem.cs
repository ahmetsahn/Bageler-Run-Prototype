using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

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

    public void PlayBagelSound() => audioSource.PlayOneShot(bagelSound);

    public void PlayPositiveGateSound() => audioSource.PlayOneShot(positiveGateSound);

    public void PlayNegativeGateSound() => audioSource.PlayOneShot(negativeGateSound);

    public void PlayGameOverSound() => audioSource.PlayOneShot(gameOverSound);

    public void AddListeners()
    {
        GameEventsSystem.OnInteractionBagelSound += PlayBagelSound;
        GameEventsSystem.OnInteractionPositiveGateSound += PlayPositiveGateSound;
        GameEventsSystem.OnInteractionNegativeGateSound += PlayNegativeGateSound;
        GameEventsSystem.OnGameOverSound += PlayGameOverSound;
    }

    public void RemoveListeners()
    {
        GameEventsSystem.OnInteractionBagelSound -= PlayBagelSound;
        GameEventsSystem.OnInteractionPositiveGateSound -= PlayPositiveGateSound;
        GameEventsSystem.OnInteractionNegativeGateSound -= PlayNegativeGateSound;
        GameEventsSystem.OnGameOverSound -= PlayGameOverSound;
    }



}
