using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;

    private float _delta;

    // Use this for initialization
    void Start()
    {
        _delta = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_delta >= 1.5f)
        {
            _delta = 0f;
            Instantiate(_enemy, new Vector3(Random.Range(0.2f, 1f), Random.Range(0.2f, 1f), Random.Range(0.2f, 1f)),
                new Quaternion(0f, 0f, 0f, 0f));
        }

        _delta += Time.deltaTime;
    }
}