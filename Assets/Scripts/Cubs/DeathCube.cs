using UnityEngine;
using Lofelt.NiceVibrations;

public class DeathCube : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _miniCube;

    void Start()
    {
        if (PlayerPrefs.GetInt("Vibration") == 1) HapticPatterns.PlayConstant(0.25f, 0.66f, 0.5f);
        for (int i = 0; i < _miniCube.Length; i++)
        {
            _miniCube[i].AddExplosionForce(5f, transform.position, 10, 3.0F);
        }
    }
}
