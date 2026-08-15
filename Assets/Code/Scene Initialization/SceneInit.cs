using UnityEngine;

public class SceneInit : MonoBehaviour
{
    private Canvas staminaCanvas;
    private GameObject playerRenderer;
    public bool componentsEnabled;
    
    private void OnEnable()
    {
        staminaCanvas = GameObject.FindGameObjectWithTag("StaminaUI").GetComponent<Canvas>();
        playerRenderer = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;

        if (staminaCanvas) staminaCanvas.enabled = componentsEnabled;
        if (playerRenderer) playerRenderer.SetActive(componentsEnabled);
        VignetteController.instance.UpdatePostProcessingEffects(HealthState.High);
    }
}
