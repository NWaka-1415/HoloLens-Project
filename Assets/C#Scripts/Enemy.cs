using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class Enemy : MonoBehaviour, IInputClickHandler
{
    private GameObject _mainCamera;
    private Rigidbody _rigidbody;

    private UIManager _uiManager;

    // Use this for initialization
    void Start()
    {
        _mainCamera = GameObject.Find("HoloLensCamera");
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("Destroy");
        Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
        if (transform.position.z <= 0f)
        {
            Attack();
            return;
        }

        Vector3 direction = _mainCamera.transform.position - gameObject.transform.position;
        Debug.Log("Direction:" + direction);
        direction = CalcElement(direction);
        _rigidbody.velocity = direction;
    }

    void Attack()
    {
        //プレイヤーにダメージを与えてから
        _uiManager.Damaged(10);
        Destroy(gameObject);
    }

    Vector3 CalcElement(Vector3 vector3)
    {
        return new Vector3(vector3.x / Mathf.Abs(vector3.x), vector3.y / Mathf.Abs(vector3.y),
            vector3.z / Mathf.Abs(vector3.z));
    }
}