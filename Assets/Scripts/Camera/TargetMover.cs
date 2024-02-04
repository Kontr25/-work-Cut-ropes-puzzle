using UnityEngine;
using DG.Tweening;

public class TargetMover : MonoBehaviour
{
    [SerializeField] private Transform _cameraTarget;
    [SerializeField] private Vector3 _height;
    [SerializeField] private Transform[] _cubParent;
    [SerializeField] private LevelSaver _levelSaver;
    private float _cubHighest = -1000f;

    public void UpdateHeight()
    {
        _cubHighest = -1000f;
        foreach (Transform child in _cubParent[_levelSaver.LevelNuber()])
        {
            if (child.transform.position.y > _cubHighest) _cubHighest = child.transform.position.y;
        }
    }

    public void MoveCameraTarget()
    {
        UpdateHeight();
        _cameraTarget.DOMove(new Vector3(0, _cubHighest-6f, 0),1f,false);
    }
}
