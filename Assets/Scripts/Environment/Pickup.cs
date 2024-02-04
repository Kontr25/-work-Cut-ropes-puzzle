using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject[] _firstConfetti;
    [SerializeField] private GameObject[] _secondConfetti;
    [SerializeField] private AudioSource _carEngine;

    public void Victory()
    {
        _carEngine.Play();
        _animator.SetTrigger("Victory");
        for (int i = 0; i < _firstConfetti.Length; i++)
        {
            _firstConfetti[i].SetActive(true);
        }
        Invoke(nameof(SecondConfetti), 1f);
    }

    private void SecondConfetti()
    {
        for (int i = 0; i < _secondConfetti.Length; i++)
        {
            _secondConfetti[i].SetActive(true);
        }
    }
}
