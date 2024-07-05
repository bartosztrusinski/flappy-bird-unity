using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
  public AudioMixer audioMixer;

  public void SetGameVolume(float volume)
  {
    audioMixer.SetFloat("GameVolume", volume);
  }

  public void SetMusicVolume(float volume)
  {
    audioMixer.SetFloat("MusicVolume", volume);
  }

}
