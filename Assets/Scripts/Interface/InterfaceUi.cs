using UnityEngine;

public class InterfaceUi : MonoBehaviour
{
    [SerializeField] private GameObject[] _uIObj;
    private void Start()
    {
        for (int i = 0; i < _uIObj.Length; i++)
        {
            _uIObj[i].SetActive(false);
        }
    }
}
