using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookerAtCamera : MonoBehaviour
{
    [SerializeField] private bool _invertX;
    private Camera _mainCamera;
    private void Awake()
    {
        _mainCamera = Camera.main;
        if (_invertX) transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    private void Update()
    {
        transform.LookAt(_mainCamera.transform);
    }
}
