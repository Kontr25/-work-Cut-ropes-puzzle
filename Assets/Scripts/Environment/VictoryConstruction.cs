using UnityEngine;
using Cinemachine;

public class VictoryConstruction : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _victoryCamera;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent (out Cub cub))
        {
            if(cub.Pinned() == false)
            {
                _victoryCamera.Priority = 100;
            }
        }
    }
}
