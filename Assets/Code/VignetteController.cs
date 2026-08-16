using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VignetteController : MonoBehaviour
{
    public static VignetteController instance;
    private Volume _volume;
    private readonly VolumeParameter<float> _intensityParameter = new();  // This parameter is used to set the intensity of the vignette at runtime
    private readonly VolumeParameter<Color> _colorFilterIntensityParameter = new();  // This parameter is used to set the intensity of the vignette at runtime
    private VolumeComponent _filmGrain;
    private VolumeComponent _vignette;
    private VolumeComponent _colorAdjustment;

    private void Awake()
    {
        Init();
        
        _volume = GetComponent<Volume>();

        _filmGrain = _volume.profile.components[0];
        _vignette = _volume.profile.components[1];
        _colorAdjustment = _volume.profile.components[2];
    }

    private void Init()
    {
        if (instance && instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }

        instance = this;
    }
    
    private void UpdateProfile()
    {
        _filmGrain.parameters[1].SetValue(_intensityParameter); // Volume component -> profile -> film grain component of profile -> intensity parameter -> set value to IntensityParameter's value
        _vignette.parameters[2].SetValue(_intensityParameter);  // Volume component -> profile -> vignette component of profile -> intensity parameter -> set value to IntensityParameter's value
        _colorAdjustment.parameters[2].SetValue(_colorFilterIntensityParameter);  // Volume component -> profile -> vignette component of profile -> intensity parameter -> set value to IntensityParameter's value
    }

    public void UpdatePostProcessingEffects(HealthState state)
    {
        _intensityParameter.value = state switch    // Set the intensity
        {
            HealthState.High => 0,
            HealthState.Medium => .4f,
            HealthState.Low => .6f,
            HealthState.Critical => .9f,
            _ => _intensityParameter.value
        };

        _colorFilterIntensityParameter.value = state switch // Set the colors
        {
            HealthState.High => Color.white,
            HealthState.Medium => Color.white,
            HealthState.Low => new Color(1, .8f, .8f),
            HealthState.Critical => Color.red,
            _ => _colorFilterIntensityParameter.value
        };

        UpdateProfile();
    }

    public void SetVignetteState(bool state)
    {
        _volume.enabled = state;
    }
}
