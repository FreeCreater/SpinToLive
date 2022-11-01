using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    [SerializeField] private GameObject settingsPanel;
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    [SerializeField] private Toggle soundEffectsToggle;
    [SerializeField] private Toggle musicToggle;
    public void SubmitSettings()
    {
        settingsPanel.SetActive(false);
        AudioManager.AudioManager.Instance.SetActiveSoundEffects(soundEffectsToggle.isOn);
        AudioManager.AudioManager.Instance.SetActiveMainTheme(musicToggle.isOn);
    }
    
    public void About()
    {
        Application.OpenURL("https://github.com/FreeCreater");
    }
}
