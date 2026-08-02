using System;
using UnityEngine;

public class SpiritBall : MonoBehaviour
{
    private AudioSource _audioSource;
    private MeshRenderer _meshRenderer;
    private Collider _collider;
    private Light _light;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
        _light = GetComponentInChildren<Light>();
    }

    private void Start()
    {
        Debug.Log(_audioSource != null);
        
        #region SpiritManager

        // Early return
        if (!SpiritManager.instance)
        {
            Debug.LogWarning($"{gameObject.name}: No instance of SpiritBall found in the scene.");
            return;
        }
        
        // Attempt to add yourself to the SpiritManager's hash map
        SpiritManager.instance.AddSpirit(gameObject);
        
        // Set your state as the same state present in the hash map. By default, this state will be true, but if the spirit was previously added to the hash map and then collected, its value will be false
        SetState(SpiritManager.instance.IsSpiritActive(gameObject));

        #endregion
        
        #region GameEventManager

        if (!GameEventManager.instance)
        {
            Debug.LogWarning($"{gameObject.name}: No instance of GameEventManager found in the scene.");
            return;
        }
        
        GameEventManager.instance.miscellaneousEvents.SpiritCollected += CollectSpirit;

        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        GameEventManager.instance.miscellaneousEvents.OnSpiritCollected();
    }

    private void SetState(bool state)
    {
        _meshRenderer.enabled = state;
        _collider.enabled = state;
        _light.enabled = state;
    }

    private void CollectSpirit()
    {
        _audioSource.Play();    // Play audio
        SetState(false);    // Set components to disabled
        if (!SpiritManager.instance) return;
        SpiritManager.instance.UpdateSpirit(gameObject, false); // Set a spirit's state to false in the SpiritManager's hash map
    }
}
