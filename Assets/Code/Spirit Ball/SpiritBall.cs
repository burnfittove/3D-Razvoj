using UnityEngine;

public class SpiritBall : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameEventManager.instance.miscellaneousEvents.OnSpiritCollected();
        _audioSource.Play();
        Hide();
    }

    private void Hide()
    {
        TryGetComponent(out MeshRenderer meshRenderer);
        TryGetComponent(out Collider collider);
        TryGetComponent(out Light light);
        meshRenderer.enabled = false;
        collider.enabled = false;
        light.enabled = false;
    }
}
