using UnityEngine;

public class CutEffect : MonoBehaviour
{
    [SerializeField] private Transform _cutParticlePos;
    [SerializeField] private GameObject _cutEffectObj;



    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.TryGetComponent (out CutCollider cutCollider))
            {
                _cutParticlePos.position = hit.point;
            }
        }
    }

    public void EnableCutEffect()
    {
        _cutEffectObj.SetActive(true);
    }

    public void DisableCutEffect()
    {
        _cutEffectObj.SetActive(false);
    }
    public Vector3 CutParticlePos()
    {
        return _cutParticlePos.position;
    }
}
