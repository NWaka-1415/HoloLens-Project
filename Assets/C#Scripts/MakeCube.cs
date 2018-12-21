using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class MakeCube : MonoBehaviour, IInputClickHandler
{
    [SerializeField] private GameObject _cube;
    private int _count;

   public void OnInputClicked(InputClickedEventData eventData)
    {
        if (_count==0)
        {
            CreateObj();
        }
        Debug.Log("Clicked");
    }

    private void Start()
    {
        InputManager.Instance.PushFallbackInputHandler(gameObject);
        _count = 0;
    }

    void CreateObj()
    {
        GameObject cube;
        cube = Instantiate(_cube, new Vector3(0, 0, 2), _cube.transform.rotation);
    }
}