using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] private GameObject _defeat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Cub cub))
        {
            cub.Death();
            Invoke(nameof(Defeat), 1f);
        }
    }

    private void Defeat()
    {
        _defeat.SetActive(true);
    }
}
