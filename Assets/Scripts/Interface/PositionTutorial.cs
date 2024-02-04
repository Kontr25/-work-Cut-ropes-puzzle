using UnityEngine;

public class PositionTutorial : MonoBehaviour
{
    [SerializeField] private Tutorial _tutorial;
    [SerializeField] private int _numberForCut;

    private void Awake()
    {
        _tutorial.AddList(GetComponent<PositionTutorial>());
    }

    public void RemoveFromList()
    {
        _tutorial.RemoveList(GetComponent<PositionTutorial>());
        _tutorial.RopeNumber();
    }

    public int NumberForCut()
    {
        return _numberForCut;
    }
}
