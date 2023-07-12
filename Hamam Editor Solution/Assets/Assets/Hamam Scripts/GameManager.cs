using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event Action DeselectAllCells;
    public static event Action<int> OnScoreChanged;

    [SerializeField] private UISummaryScreen _summaryScreen;

    private int _score;
    private int _selectedCellsValue;
    private int _splitValueLimit = 21;
    private int _valueToWin = 60;

    private void OnEnable()
    {
        CellController.OnCellSelected += CellClicked;
    }

    private void OnDisable()
    {
        CellController.OnCellSelected -= CellClicked;
    }

    private void CellClicked(bool isSelected, int cellValue)
    {
        if (isSelected)
        {
            _selectedCellsValue += cellValue;
            Debug.Log(_selectedCellsValue);
            if (_selectedCellsValue > _splitValueLimit)
            {
                var amountToTake = Mathf.FloorToInt(_selectedCellsValue / 2f);
                _score -= amountToTake;
                _score = _score < 0 ? 0 : _score;
                OnScoreChanged?.Invoke(_score);
                _selectedCellsValue = 0;
                DeselectAllCells?.Invoke();
            }
            else if (_selectedCellsValue == _splitValueLimit)
            {
                _score += _splitValueLimit;
                OnScoreChanged?.Invoke(_score);
                _selectedCellsValue = 0;
                DeselectAllCells?.Invoke();
            }
        }
        else
        {
            _selectedCellsValue -= cellValue;
        }

        WinCheck();
    }

    private void WinCheck()
    {
        if (_score > _valueToWin)
        {
            Debug.Log("ON WIN");
            var info = new UISummaryScreen.SummaryInfoDM();
            info.Score = _score;
            info.PlayerWon = true;
            _summaryScreen.ShowSummary(info);
        }
    }
}