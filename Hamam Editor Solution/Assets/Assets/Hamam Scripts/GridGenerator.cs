using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private GridLayoutGroup _gridLayoutGroup;
    [SerializeField] private int _gridWidth;
    private void Awake()
    {
        _gridLayoutGroup.constraintCount = _gridWidth;
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int i = 0; i < _gridWidth * _gridWidth; i++)
        {
            Instantiate(_cellPrefab, _gridLayoutGroup.transform);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
