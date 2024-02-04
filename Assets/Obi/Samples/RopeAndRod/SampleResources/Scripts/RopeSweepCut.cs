using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
using Lofelt.NiceVibrations;

[RequireComponent(typeof(ObiRope))]
public class RopeSweepCut : MonoBehaviour
{

    public Camera cam;

    ObiRope rope;
    LineRenderer lineRenderer;
    private Vector3 cutStartPosition;
    private ObiParticleAttachment _end;
    [SerializeField] private Renderer _material;
    [SerializeField] private GameObject _cutEffect;
    [SerializeField] private Transform _slashEffect;
    private bool cut = false;
    private float _colorStep;
    private bool _canCut = true;
    private bool _canDisappearance = false;
    [SerializeField] private PositionTutorial _positionTutorial;

    private void Awake()
    {
        rope = GetComponent<ObiRope>();
        _end = GetComponent<ObiParticleAttachment>();
    }

    public void CanCut(bool i)
    {
        _canCut = i;
    }

    private void LateUpdate()
    {
        // do nothing if we don't have a camera to cut from.
        if (cam == null) return;

        // process user input and cut the rope if necessary.
        ProcessInput();
    }

    private void Update()
    {
        if (_canDisappearance)
        {
            _material.material.SetFloat("_DissolveAmount", _colorStep);
            _colorStep += Time.deltaTime;
        }
    }
    /**
     * Very simple mouse-based input. Not ideal for multitouch screens as it only supports one finger, though.
     */
    private void ProcessInput()
    {
        // When the user clicks the mouse, start a line cut:
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var mouse = Input.mousePosition;
            var globalPos = cam.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 0.5f));
            cutStartPosition = cam.transform.InverseTransformPoint(globalPos);
        }


        // When the user lifts the mouse, proceed to cut.
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(_canCut) ScreenSpaceCut(cam.WorldToScreenPoint(cam.transform.TransformPoint(cutStartPosition)), Input.mousePosition);
        }
    }


    /**
     * Cuts the rope using a line segment, expressed in screen-space.
     */
    private void ScreenSpaceCut(Vector2 lineStart, Vector2 lineEnd)
    {

        // iterate over all elements and test them for intersection with the line:
        for (int i = 0; i < rope.elements.Count; ++i)
        {
            // project the both ends of the element to screen space.
            Vector3 screenPos1 = cam.WorldToScreenPoint(rope.solver.positions[rope.elements[i].particle1]);
            Vector3 screenPos2 = cam.WorldToScreenPoint(rope.solver.positions[rope.elements[i].particle2]);

            // test if there's an intersection:
            if (SegmentSegmentIntersection(screenPos1, screenPos2, lineStart, lineEnd, out float r, out float s))
            {
                cut = true;
                rope.Tear(rope.elements[i]);
            }
        }

        // If the rope was cut at any point, rebuilt constraints:
        if (cut)
        {
            if(_positionTutorial != null) _positionTutorial.RemoveFromList();
            if (PlayerPrefs.GetInt("Vibration") == 1) HapticPatterns.PlayConstant(0.25f, 0.5f, 0.1f);
            Disappearance();
            rope.RebuildConstraintsFromElements();
            Instantiate(_cutEffect, _slashEffect.position, Quaternion.identity);
            _canCut = false;
        }
    }

    public void Disappearance()
    {
        _end.enabled = false;
        _canDisappearance = true;
        _material.shadowCastingMode = 0;
        Destroy(gameObject, 1f);
    }

    /**
     * line segment 1 is AB = A+r(B-A)
     * line segment 2 is CD = C+s(D-C)
     * if they intesect, then A+r(B-A) = C+s(D-C), solving for r and s gives the formula below.
     * If both r and s are in the 0,1 range, it meant the segments intersect.
     */
    private bool SegmentSegmentIntersection(Vector2 A, Vector2 B, Vector2 C, Vector2 D, out float r, out float s)
    {
        float denom = (B.x - A.x) * (D.y - C.y) - (B.y - A.y) * (D.x - C.x);
        float rNum = (A.y - C.y) * (D.x - C.x) - (A.x - C.x) * (D.y - C.y);
        float sNum = (A.y - C.y) * (B.x - A.x) - (A.x - C.x) * (B.y - A.y);

        if (Mathf.Approximately(rNum, 0) || Mathf.Approximately(denom, 0))
        {  r = -1; s = -1; return false; }

        r = rNum / denom;
        s = sNum / denom;

        return (r >= 0 && r <=1  && s >= 0 && s <= 1);
    }
}
