using UnityEngine;
using TMPro;
using DG.Tweening;
using Lofelt.NiceVibrations;

public class Cub : MonoBehaviour
{
    [SerializeField] private TMP_Text mP_Text;
    [SerializeField] private Material[] _material;
    [SerializeField] private Renderer _cubeMaterial;
    [SerializeField] private bool _isPinned;
    [SerializeField] private Transform _cub;
    [SerializeField] private GameObject _cubeObj;
    [SerializeField] private int _number;
    [SerializeField] private GameObject[] _dieColor;
    [SerializeField] private GameObject[] _superHeroDie;
    [SerializeField] private GameObject _cubeDeath;
    [SerializeField] private Rigidbody _cubRB;
    [SerializeField] private GameObject[] _effectsPaint;
    [SerializeField] private GameObject[] _SuperEffectsPaint;
    [SerializeField] private GameObject[] _blobPrefab;
    [SerializeField] private TargetMover _targetMover;
    [SerializeField] private RopeSweepCut[] _rope;
    [SerializeField] private bool _needTwoCubsForPinned;
    [SerializeField] private AudioSource _mergeSound;
    private GameObject _effect;
    private int _cubeNumber;
    [SerializeField] private GameObject _eyes;
    [SerializeField] private GameObject[] _face;
    [SerializeField] private GameObject _convasNumber;
    private int _faceNumber;
    private int i;
    private bool _creative;
    [SerializeField] private GameObject[] _superHeroPref;
    [SerializeField] private GameObject _cubeMesh;
    private float _lastRotation;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("Creatives") == 0)
        {
            if (PlayerPrefs.GetInt("FirstRound") % 2 != 0)
            {
                if (PlayerPrefs.GetInt("CurrentLevel") != 6 && PlayerPrefs.GetInt("CurrentLevel") != 7 && PlayerPrefs.GetInt("CurrentLevel") != 8)
                {
                    _convasNumber.SetActive(false);
                    _eyes.SetActive(true);
                    SetFace();
                }
            }
            else if (PlayerPrefs.GetInt("FirstRound") % 2 == 0)
            {
                if (PlayerPrefs.GetInt("CurrentLevel") >= 6 && PlayerPrefs.GetInt("CurrentLevel") <= 8)
                {
                    _convasNumber.SetActive(false);
                    _eyes.SetActive(true);
                    SetFace();
                }
            }
        }
        else
        {
            _cubeMesh.SetActive(false);
            _convasNumber.SetActive(false);
            _creative = true;
        }
        i = Random.Range(0, 4);
        CheckNumber();
    }

    private void SetFace()
    {
        _face[i].SetActive(false);
        i = Random.Range(0, 4);
        while (_faceNumber == i)
        {
            i = Random.Range(0, 4);
        }
        _faceNumber = i;
        _face[_faceNumber].SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent (out Cub cub))
        {
            if(cub.Pinned() == false && _number == cub.Number())
            {
                _number += cub.Number();
                cub.DestroyCube();
                if (PlayerPrefs.GetInt("Creatives") == 0)
                {
                    if (PlayerPrefs.GetInt("FirstRound") % 2 != 0)
                    {
                        if (PlayerPrefs.GetInt("CurrentLevel") != 6 && PlayerPrefs.GetInt("CurrentLevel") != 7 && PlayerPrefs.GetInt("CurrentLevel") != 8) SetFace();
                    }
                    else if (PlayerPrefs.GetInt("FirstRound") % 2 == 0)
                    {
                        if ((PlayerPrefs.GetInt("CurrentLevel") + 1) == 7 || (PlayerPrefs.GetInt("CurrentLevel") + 1) == 8 || (PlayerPrefs.GetInt("CurrentLevel") + 1) == 9)
                        {
                            SetFace();
                        }
                    }
                }
                        _mergeSound.Play();
                _targetMover.MoveCameraTarget();
                CheckNumber();
                InstantiateEffect();
                if (PlayerPrefs.GetInt("Vibration") == 1) HapticPatterns.PlayConstant(0.25f, 0.4f, 0.2f);
                _cubRB.isKinematic = false;
                _cub.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 0.5f,3,1);
                if (_needTwoCubsForPinned == false) Invoke(nameof(PinnedFalse), 0.2f);
                else _needTwoCubsForPinned = false;
            }
        }
    }

    public void DestroyCube()
    {
        for (int i = 0; i < _rope.Length; i++)
        {
            if(_rope[i] != null)
            _rope[i].Disappearance();
        }
        _lastRotation = _cubeObj.transform.rotation.z;
        Destroy(_cubeObj);
    }

    private void PinnedFalse()
    {
        _isPinned = false;
    }

    public bool Pinned()
    {
        return _isPinned;
    }

    public int Number()
    {
        return _number;
    }

    public void InstantiateBlob()
    {
        int i = Random.Range(0, 3);
        GameObject blob = Instantiate(_blobPrefab[i], new Vector3(_cub.position.x, _cub.position.y, 1f), Quaternion.identity);
        blob.GetComponent<Blob>().Number(_cubeNumber);
    }

    public void CheckNumber()
    {
        mP_Text.text = _number.ToString();
        if (_number == 2)
        {
            if (!_creative) SetMaterial(0);
            else SetSuperHero(0);
            _cubeNumber = 0;
        }
        else if (_number == 4)
        {
            if (!_creative) SetMaterial(1);
            else SetSuperHero(1);
            _cubeNumber = 1;
        }
        else if (_number == 8)
        {
            if (!_creative) SetMaterial(2);
            else SetSuperHero(2);
            _cubeNumber = 2;
        }
        else if (_number == 16)
        {
            if (!_creative) SetMaterial(3);
            else SetSuperHero(3);
            _cubeNumber = 3;
        }
        else if (_number == 32)
        {
            if (!_creative) SetMaterial(4);
            else SetSuperHero(4);
            _cubeNumber = 4;
        }
        else if (_number == 64)
        {
            if (!_creative) SetMaterial(5);
            else SetSuperHero(5);
            _cubeNumber = 5;
        }
        else if (_number == 128)
        {
            if (!_creative)
            {
                mP_Text.fontSize = 4;
                SetMaterial(6);
            }
            else SetSuperHero(6);
            _cubeNumber = 6;
        }
    }

    private void SetSuperHero(int g)
    {
        for (int i = 0; i < _superHeroPref.Length; i++)
        {
            _superHeroPref[i].SetActive(false);
        }
        _superHeroPref[g].SetActive(true);
        _cubeDeath = _superHeroDie[g];
        _effect = _SuperEffectsPaint[g];
    }

    private void SetMaterial(int i)
    {
        _cubeMaterial.material = _material[i];
        _cubeDeath = _dieColor[i];
        _effect = _effectsPaint[i];
    }

    public void InstantiateEffect()
    {
        Instantiate(_effect, _cub.position, Quaternion.identity);
        InstantiateBlob();
    }

    public void InstantiateDeathCube()
    {
        Instantiate(_cubeDeath, _cub.position, Quaternion.Euler(0,0,transform.eulerAngles.z + _lastRotation));
    }

    public void InstantiateVictoryhCube(float i)
    {
        GameObject GO = Instantiate(_cubeDeath, _cub.position, Quaternion.identity);
        GO.transform.localScale = new Vector3(i, i, i);
    }

    public void Death()
    {
        _cub.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.2f);
        Invoke(nameof(DestroyCube), 0.2f);
        Invoke(nameof(InstantiateDeathCube), 0.2f);
        Invoke(nameof(InstantiateEffect), 0.2f);
    }
}
