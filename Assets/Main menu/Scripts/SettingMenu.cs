using UnityEngine.Audio;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer  mainMixer;

    public void SetVolume(float volume)
    {
        mainMixer.SetFloat("volume", volume);
    }
   public void FullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    
}
