
using System.Text;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    #region Fields

    [SerializeField] private TextMeshProUGUI _textAsset;
    [SerializeField, TextArea] private string _additionalText;

    #endregion

    #region Properties

    #endregion

    #region Functions

    private void Start()
    {
        ResetCounter();
    }

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
}