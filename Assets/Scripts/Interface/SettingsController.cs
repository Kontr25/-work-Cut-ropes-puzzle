using UnityEngine;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private GameObject _settingsWindow;
    [SerializeField] private GameObject _volumeOn;
    [SerializeField] private GameObject _vibrationOn;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Volume") == false)
        {
            PlayerPrefs.SetInt("Volume", 1);
            PlayerPrefs.SetInt("Vibration", 1);
        }

        if (PlayerPrefs.GetInt("Volume") == 1)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }

    public void OpenSettings()
    {
        _settingsWindow.SetActive(true);

        if (PlayerPrefs.GetInt("Volume") == 1)
        {
            _volumeOn.SetActive(true);
        }
        else
        {
            _volumeOn.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            _vibrationOn.SetActive(true);
        }
        else
        {
            _vibrationOn.SetActive(false);
        }
    }

    public void CloseSettings()
    {
        _settingsWindow.SetActive(false);
    }

    public void OffVolume()
    {
        _volumeOn.SetActive(false);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Volume", 0);
    }

    public void OnVolume()
    {
        _volumeOn.SetActive(true);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Volume", 1);
    }

    public void OffVibration()
    {
        _vibrationOn.SetActive(false);
        PlayerPrefs.SetInt("Vibration", 0);
    }

    public void OnVibration()
    {
        _vibrationOn.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 1);
    }
}
