using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private float _fromHp;
    private float _toHp;
    private float _reduceTimeFrame;
    private float _frameReduceHp;

    private float _playerMaxHp;
    private float _playerHp;

    private Image _hpGreenGage;
    private Image _hpRedGage;

    // Use this for initialization
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        _hpGreenGage.fillAmount = _playerHp / _playerMaxHp;

        ReduceHp();
    }

    void Initialize()
    {
        _hpGreenGage = GameObject.Find("HpGreen").GetComponent<Image>();
        _hpRedGage = GameObject.Find("HpRed").GetComponent<Image>();
        _hpGreenGage.fillAmount = 1;
        _hpRedGage.fillAmount = 1;
        _reduceTimeFrame = 120.0f;

        _playerMaxHp = 100f;
        _playerHp = _playerMaxHp;
    }

    void ReduceHp()
    {
        if (_fromHp > _toHp)
        {
            _hpRedGage.fillAmount = _fromHp / _playerHp;
            _fromHp -= _frameReduceHp;
        }
        else
        {
            _hpRedGage.fillAmount = _toHp / _playerHp;
        }
    }

    void SetReducing()
    {
        float diffHp = _fromHp - _toHp;
        _frameReduceHp = diffHp / _reduceTimeFrame;
    }

    public void Damaged(int damage)
    {
        _playerHp -= damage;
        if (_playerHp < 0f)
        {
            _playerHp = 0f;
        }
    }
}