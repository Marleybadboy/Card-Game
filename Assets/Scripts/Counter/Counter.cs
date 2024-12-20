
using System.Text;
using HCC.Interfaces;
using TMPro;
using UnityEngine;


public class Counter : MonoBehaviour, ISave
{
    #region Fields

    [SerializeField] private TextMeshProUGUI _textAsset;
    [SerializeField, TextArea] private string _additionalText;

    #endregion


    #region Methods
    
    public int GetActualPoints() => int.Parse(_textAsset.text);
    public void ResetCounter() => _textAsset.text = 0.ToString();

    public void ChangeCounter(int value)
    {
        StringBuilder builder = new StringBuilder();
        
        if (_textAsset.text == string.Empty)
        {
            builder.Append(value);
            builder.Append(_additionalText);
            
            _textAsset.text = builder.ToString();
            
            return;
        }
        
        
        builder.Append(int.Parse( _textAsset.text) + value);
        builder.Append(_additionalText);
        
        _textAsset.text = builder.ToString();
        
    }
    #endregion

    public int GetSaveValue()
    {
        return GetActualPoints();
    }
}