using UnityEngine;

public class SpiritBall : MonoBehaviour
{
    private AudioSource _audioSource;
    private MeshRenderer _meshRenderer;
    private Collider _collider;
    private Light _light;
    public string idd;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
        _light = GetComponentInChildren<Light>();
    }

    private void Start()
    {
        idd = GetSpiritID();
        #region SpiritManager

        // Early return
        if (!SpiritManager.instance)
        {
            Debug.LogWarning($"{gameObject.name}: No instance of SpiritManager found in the scene.");
            return;
        }
        
        // Attempt to add spirit's ID to the SpiritManager's hash map
        // SpiritManager.instance.AddSpirit(GetSpiritID());
        
        // Set a spirit's state as the same state present in the hash map. By default, this state will be true, but if the spirit was previously added to the hash map and then collected, its value will be false
        SetState(SpiritManager.instance.IsSpiritActive(GetSpiritID()));

        #endregion
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!GameEventManager.instance) return;
        GameEventManager.instance.miscellaneousEvents.OnSpiritCollected();
        CollectSpirit();
    }

    private void SetState(bool state)
    {
        _meshRenderer.enabled = state;
        _collider.enabled = state;
        _light.enabled = state;
    }

    private void CollectSpirit()
    {
        // Don't do anything if there's no SpiritManager
        if (!SpiritManager.instance)
        {
            Debug.LogWarning($"{gameObject.name}: No instance of SpiritManager found in the scene.");
            return;
        }
        
        SpiritManager.instance.UpdateSpirit(GetSpiritID(), false); // Set a spirit's state to false in the SpiritManager's hash map
        _audioSource.Play();    // Play audio
        SetState(false);    // Set components to disabled
    }
    
    private string GetSpiritID()
    {
        return $"{transform.position.x}{transform.position.y}{transform.position.z}-{gameObject.name[^2]}";
    }
}
