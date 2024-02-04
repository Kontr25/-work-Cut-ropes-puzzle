using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSaver : MonoBehaviour
{
    [SerializeField] private GameObject[] _level;
    [SerializeField] private TMP_Text mP_Text;
    private int _levelNumber;
    private int _textNumber;
    [SerializeField] private int _creative;

    private void Awake()
    {
        PlayerPrefs.SetInt("Creatives", _creative);
        Debug.Log("Level: " + PlayerPrefs.GetInt("CurrentLevel"));
        if (PlayerPrefs.HasKey("CurrentLevel") == false)
        {
            PlayerPrefs.SetInt("CurrentLevel", 0);
            PlayerPrefs.SetInt("TotalLevel", 0);
            PlayerPrefs.SetInt("FirstRound", 0);
            PlayerPrefs.SetInt("attempts", 0);
        }
        _levelNumber = PlayerPrefs.GetInt("CurrentLevel");
        for (int i = 0; i < _level.Length; i++)
        {
            _level[i].SetActive(false);
        }
        _level[_levelNumber].SetActive(true);
        _textNumber = PlayerPrefs.GetInt("TotalLevel") + 1;
        mP_Text.text = "LEVEL " + _textNumber.ToString();
    }

    public void SaveLevel(int level)
    {
        PlayerPrefs.SetInt("CurrentLevel", level);
        if (level == 0) _level[1].SetActive(false);
        else _level[level - 1].SetActive(false);
        SceneManager.LoadScene(0);
    }

    public int LevelNuber()
    {
        return _levelNumber;
    }
}