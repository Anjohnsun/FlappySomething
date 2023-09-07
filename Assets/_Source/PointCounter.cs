using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointCounter
{
    private TextMeshProUGUI _pointField;
    private int _points = 0;

    public PointCounter(TextMeshProUGUI pointField) {
        _pointField = pointField;
    }
    
    public void ResetPoints() {
        _points = 0;
        _pointField.text = _points.ToString();
    }

    public void AddPoints(int number) {
        _points += number;
        _pointField.text = _points.ToString();
    }
}
