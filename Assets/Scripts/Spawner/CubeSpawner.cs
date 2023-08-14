using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [Header("Cube spawn")]
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Transform _spawnPosition;

    [Header("User input")]
    [SerializeField] private TMP_InputField _timeBetwenSpawnsInput;
    [SerializeField] private TMP_InputField _cubeSpeedInput;
    [SerializeField] private TMP_InputField _cubeDistanceInput;

    private float _timeBetwenSpawns;

    private Coroutine _spawningCoroutine;

    private void Start() 
    {
        _timeBetwenSpawnsInput.text = 0.ToString();
        _cubeSpeedInput.text = 0.ToString();
        _cubeDistanceInput.text = 0.ToString();
    }

    private IEnumerator SpawnCubeAfterTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(_timeBetwenSpawns);

            Cube cube = Instantiate(_cubePrefab, _spawnPosition.position, Quaternion.identity);
            cube.Init(SetCubeSpeedInput(), SetDistanceInput());
        }
    }

    private void SetTimeBetwenSpawnsInput()
    {
        _timeBetwenSpawns = float.Parse(_timeBetwenSpawnsInput.text);

        if(_timeBetwenSpawns < 0)
        {
            _timeBetwenSpawns  = 0;
        }
    }

    private float SetCubeSpeedInput()
    {
        float cubeSpeed = float.Parse(_cubeSpeedInput.text);

        if(cubeSpeed < 0)
        {
            return cubeSpeed = 0;
        }
        else 
        {
            return cubeSpeed;
        }
    }

    private float SetDistanceInput()
    {
        float distance = float.Parse(_cubeDistanceInput.text);

        if(distance < 0)
        {
            return distance = 0;
        }
        else 
        {
            return distance;
        }
    }

    public void StartSpawning()
    {
        SetTimeBetwenSpawnsInput();

        if(_spawningCoroutine == null)
        {
            _spawningCoroutine = StartCoroutine(SpawnCubeAfterTime());
        }
        else
        {
            StopCoroutine(_spawningCoroutine);

            _spawningCoroutine = StartCoroutine(SpawnCubeAfterTime());
        }
    }
}
