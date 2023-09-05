using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pointField;
    private int _points;
    
    public void ResetPoints() {
        _points = 0;
        _pointField.text = _points.ToString();
    }

    public void AddPoints(int number) {
        _points += number;
        _pointField.text = _points.ToString();
    }
}
