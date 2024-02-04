using UnityEngine;

public class SetParentTruck : MonoBehaviour
{
    [SerializeField] private Transform _truck;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(_truck);
    }
}
