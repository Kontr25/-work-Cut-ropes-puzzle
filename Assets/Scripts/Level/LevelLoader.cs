using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private LevelSaver _levelSaver;

    private void Start()
    {
        //GAInstance.Instance.LevelStartedEvent(PlayerPrefs.GetInt("CurrentLevel", 0), PlayerPrefs.GetInt("TotalLevel", 0));
        Debug.Log(PlayerPrefs.GetInt("TotalLevel") + " = TotalLevel");
        Debug.Log(PlayerPrefs.GetInt("CurrentLevel") + " = CurrentLevel");
    }
    public void LoadLevel()
    {
        PlayerPrefs.SetInt("attempts", 0);
        if (PlayerPrefs.GetInt("CurrentLevel") < 14)
        {
            _levelSaver.SaveLevel(PlayerPrefs.GetInt("CurrentLevel") + 1);
        }
        else
        {
            _levelSaver.SaveLevel(4);
            PlayerPrefs.SetInt("FirstRound", PlayerPrefs.GetInt("FirstRound")+1);
        }
        PlayerPrefs.SetInt("TotalLevel", PlayerPrefs.GetInt("TotalLevel") + 1);
    }

    public void Restart()
    {
        PlayerPrefs.SetInt("attempts", (PlayerPrefs.GetInt("attempts")+1));
        SceneManager.LoadScene(0);
    }
}
