using UnityEngine;

public class CheckDefeat : MonoBehaviour
{
    [SerializeField] private GameObject _defeat;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent (out Cub cub))
        {
            if(cub.Pinned() == false)
            {
                _defeat.SetActive(true);
            }
        }
    }
}
