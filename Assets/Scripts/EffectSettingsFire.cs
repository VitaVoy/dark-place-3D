using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EffectSettingsFire : MonoBehaviour
{
    [SerializeField]
    private PostProcessProfile _firstPostProcessProfile;

    [SerializeField]
    private PostProcessProfile _secondPostProcessProfile;

    [SerializeField]
    private PostProcessVolume _postProcessVolume;

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeSettings(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeSettings(true);
        }
    }

    private void ChangeSettings(bool isFirstPostProcess)
    {
        _postProcessVolume.profile = isFirstPostProcess ? _firstPostProcessProfile : _secondPostProcessProfile;
    }

}
