//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.Rendering.PostProcessing;

//public class EffectSettings : MonoBehaviour
//{
//    [SerializeField]
//    private Button _firstPostProcessButton;

//    [SerializeField]
//    private Button _secondPostProcessButton;

//    [SerializeField]
//    private PostProcessProfile _firstPostProcessProfile;

//    [SerializeField]
//    private PostProcessProfile _secondPostProcessProfile;

//    [SerializeField]
//    private PostProcessVolume _postProcessVolume;
//    void Start()
//    {
//        _firstPostProcessButton.onClick.AddListener(() => ChangeSettings(true));
//        _secondPostProcessButton.onClick.AddListener(() => ChangeSettings(false));
//    }
//    private void OnDestroy()
//    {
//        _firstPostProcessButton.onClick.RemoveAllListeners();
//        _secondPostProcessButton.onClick.RemoveAllListeners();
//    }
//    private void ChangeSettings(bool isFirstPostProcess)
//    {
//        _postProcessVolume.profile = isFirstPostProcess ? _firstPostProcessProfile : _secondPostProcessProfile;
//    }
//}
