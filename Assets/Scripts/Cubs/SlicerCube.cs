using UnityEngine;

public class SlicerCube : MonoBehaviour
{
    [SerializeField] private int _needNumber;
    [SerializeField] private GameObject _victory;
    [SerializeField] private GameObject _defeat;
    [SerializeField] private Pickup _pickup;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Cub cub))
        {
            cub.DestroyCube();
            cub.InstantiateVictoryhCube(1f);
            cub.InstantiateEffect();
            if (cub.Number() == _needNumber)
            {
                _pickup.Victory();
                Invoke(nameof(Victory), 2f);
            }
            else Invoke(nameof(Defeat), 2f);
        }
    }

    public void Victory()
    {
        _victory.SetActive(true);
    }

    public void Defeat()
    {
        _defeat.SetActive(true);
    }
}
