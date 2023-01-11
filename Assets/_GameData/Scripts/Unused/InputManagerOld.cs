using System;
using System.Collections;
using System.Collections.Generic;
using _GameData.Scripts.Managers;
using UnityEngine;

public class InputManagerOld : MonoBehaviour
{
    public static InputManagerOld Instance { get; private set; }
    
    [HideInInspector] public Vector3 direction;
    [HideInInspector] public Vector3 lookForward;
    [HideInInspector] public float magnitude;
    
    private Camera _camera;
    private float _aspect;
    private Vector3 _startPosition;
    private Vector3 _currentPosition;
    private const float LerpSpeed = 10;
    private bool isGameEnd;

    private void OnEnable()
    {
        EventManager.OnGameFinished += OnGameFinishedHandler;
        EventManager.OnTimesUp += OnTimesUpHandler;
    }
    private void OnDisable()
    {
        EventManager.OnGameFinished -= OnGameFinishedHandler;
        EventManager.OnTimesUp -= OnTimesUpHandler;
    }
    private void Awake()
    {
        Instance = this;
        _camera = Camera.main;
        _aspect = _camera!.aspect;
    }
    
    private void Update()
    {
        if (isGameEnd) return;

        if (Input.GetMouseButtonDown(0))
        {
            _startPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            _currentPosition = Input.mousePosition;
            var positionDifference = _currentPosition - _startPosition;
            magnitude = positionDifference.magnitude / _camera.pixelWidth;
            positionDifference.y = _aspect * positionDifference.y;
            direction = positionDifference.normalized;
            lookForward = new Vector3(direction.x, 0, direction.y);
        }
        else
        {
            //magnitude = Mathf.Lerp(magnitude, 0, Time.deltaTime * LerpSpeed);
            lookForward = Vector3.zero;
            magnitude = 0;
        }
    }
    
    private void OnGameFinishedHandler() { isGameEnd = true; }
    private void OnTimesUpHandler() { isGameEnd = true; }
}
