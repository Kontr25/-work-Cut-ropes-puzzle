using UnityEngine;

public class BackGroundColor : MonoBehaviour
{
    [SerializeField] private Renderer _cubMat;
    [SerializeField] private Material _wallMat;
    [SerializeField] private LevelSaver _levelSaver;

    private void Start()
    {
        if (_levelSaver.LevelNuber() <= 6)
        {
            _cubMat.material.color = new Color(92 / 255.0f, 147 / 255.0f, 173 / 255.0f, 255f);
            _wallMat.color = new Color(57 / 255.0f, 77 / 255.0f, 82 / 255.0f, 255f);
        }
        else if (_levelSaver.LevelNuber() > 6 && _levelSaver.LevelNuber() <= 9)
        {
            _cubMat.material.color = new Color(54 / 255.0f, 149 / 255.0f, 112 / 255.0f, 255f);
            _wallMat.color = new Color(108 / 255.0f, 105 / 255.0f, 77 / 255.0f, 255f);
        }
        else if (_levelSaver.LevelNuber() > 9 && _levelSaver.LevelNuber() <= 11)
        {
            _cubMat.material.color = new Color(122 / 255.0f, 157 / 255.0f, 155 / 255.0f, 255f);
            _wallMat.color = new Color(69 / 255.0f, 152 / 255.0f, 137 / 255.0f, 255f);
        }
        else if (_levelSaver.LevelNuber() > 11 && _levelSaver.LevelNuber() <= 15)
        {
            _cubMat.material.color = new Color(133 / 255.0f, 134 / 255.0f, 164 / 255.0f, 255f);
            _wallMat.color = new Color(97 / 255.0f, 100 / 255.0f, 156 / 255.0f, 255f);
        }
    }
}
