using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CellController : MonoBehaviour
{
    public static event Action<bool, int> OnCellSelected;
    
    [SerializeField] private TMP_Text _cellValueText;
    [SerializeField] private Color _selectedColor;
    
    private Color _defaultColor;
    private bool _isSelected;
    private int _cellValue;
    private Image _buttonImage;

    private void Awake()
    {
        _cellValue = Random.Range(1, 12);
        _buttonImage = GetComponent<Image>();
        _defaultColor = _buttonImage.color;
        _cellValueText.SetText($"{_cellValue}");
        _cellValueText.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        GameManager.DeselectAllCells += Deselect;
    }

    private void OnDisable()
    {
        GameManager.DeselectAllCells -= Deselect;
    }

    private void Deselect()
    {
        _isSelected = false;
        _buttonImage.color = _defaultColor;
        _cellValueText.gameObject.SetActive(false);
    }

    public void OnClick()
    {
        _isSelected = !_isSelected;
        _cellValueText.gameObject.SetActive(_isSelected);
        _buttonImage.color = _isSelected ? _selectedColor : _defaultColor;
        OnCellSelected?.Invoke(_isSelected, _cellValue);
    }
}