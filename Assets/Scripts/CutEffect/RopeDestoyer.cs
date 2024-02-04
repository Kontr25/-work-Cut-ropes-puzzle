using UnityEngine;

public class RopeDestoyer : MonoBehaviour
{
    [SerializeField] private Renderer _rope;
    [SerializeField] private GameObject _ropeObj;
    private bool _isCut;
    private float _step = 0;

    private void FixedUpdate()
    {
        if (_isCut)
        {
            _rope.material.SetFloat("_DissolveAmount", _step);
            _step += Time.deltaTime;
            Debug.Log(_step);
        }
    }

    public void StartDestroy()
    {
        Destroy(_ropeObj,1.5f);
    }
    public void IsCut(bool i)
    {
        _isCut = i;
        _rope.shadowCastingMode = 0;
    }
}
