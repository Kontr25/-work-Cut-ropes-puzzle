using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private Transform target;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _tutorialHand;
    [SerializeField] private GameObject _imageObj;
    [SerializeField] private List<PositionTutorial> _list = new List<PositionTutorial>();
    [SerializeField] private LevelSaver _levelSaver;
    [SerializeField] private int _currentNumber = 1;

    private void Start()
    {

        if (PlayerPrefs.GetInt("attempts") > 1 || PlayerPrefs.GetInt("CurrentLevel") == 0)
        {
            _imageObj.SetActive(true);
            RopeNumber();
        }
    }

    public void AddList(PositionTutorial point)
    {
        _list.Add(point);
    }

    public void RemoveList(PositionTutorial point)
    {
        _list.Remove(point);
        target = null;
    }

    void Update()
    {
        if (_imageObj.activeInHierarchy && target != null)
        {
            Vector3 screenPos = _camera.WorldToScreenPoint(target.position);
            _tutorialHand.transform.position = screenPos;
        }
    }

    public void RopeNumber()
    {
        for (int i = 0; i < _list.Count; i++)
        {
            if (_list[i].NumberForCut() == _currentNumber) target = _list[i].transform;
        }
        _currentNumber++;
        if (target == null) DisableTutorial();
    }

    public int CurrentNumber()
    {
        return _currentNumber;
    }

    public void DisableTutorial()
    {
        _imageObj.SetActive(false);
    }
}

