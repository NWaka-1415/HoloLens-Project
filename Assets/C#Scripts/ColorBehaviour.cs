using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.UI;

public class ColorBehaviour : MonoBehaviour, IInputClickHandler
{
    /*
    private MeshRenderer _cubeMeshRenderer;
    //private bool _isFocus;
    private float _red;*/

    [SerializeField] private GameObject _capsule;

    // Use this for initialization

    public void OnInputClicked(InputClickedEventData eventData)
    {
        //if (!_isFocus) return;
        /*
        _red -= 50f;
        if (_red < 0f) _red = 255f;

        _cubeMeshRenderer.material.color = new Color(_red, 255f, 255f);*/
        ProduceCapsule();
        ProduceCapsule();
        Debug.Log("Destroy");
        Destroy(this.gameObject);
    }

    private void ProduceCapsule()
    {
        float r = Random.Range(0, 0.5f);
        Instantiate(_capsule, transform.position + new Vector3(r, 0, 0), new Quaternion(0, 0, 0, 0));
    }
}