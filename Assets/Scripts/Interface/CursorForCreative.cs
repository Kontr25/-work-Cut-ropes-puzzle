using UnityEngine;

public class CursorForCreative : MonoBehaviour
{
    [SerializeField] private Transform _cursor;
    [SerializeField] private GameObject _cursorUp;
    [SerializeField] private GameObject _cursorDown;
    [SerializeField] private GameObject[] _install;

    private void Update()
    {
        _cursor.position = Input.mousePosition;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < _install.Length; i++)
            {
                _install[i].SetActive(true);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            _cursorUp.SetActive(false);
            _cursorDown.SetActive(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            _cursorUp.SetActive(true);
            _cursorDown.SetActive(false);
        }
    }
}
