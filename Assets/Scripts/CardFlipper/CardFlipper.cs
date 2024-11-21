using DG.Tweening;
using HCC.Interfaces;
using Unity.Mathematics;
using UnityEngine;

public class CardFlipper : IFlipper
{

    #region Fields

    private GameObject _cardBack;
    private GameObject _cardFront;
    
    #endregion

    #region Properties

    private bool ActiveCardFront { set { _cardFront.SetActive(value); _cardBack.SetActive(!value); } }

    #endregion

    #region Methods

    public void Initialize(GameObject cardFront, GameObject cardBack)
    {
        _cardFront = cardFront;
        _cardBack = cardBack;
        
    }
    
    public void Flip()
    {
        Sequence seq = DOTween.Sequence();

        seq.Prepend(RotateCard(new float3(0f, 90f, 0), _cardBack.transform).OnComplete(() => { ActiveCardFront = true; RotateCard(float3.zero, _cardFront.transform); }));
    }

    public void Restore()
    {
        Sequence seq = DOTween.Sequence();
        
        seq.Prepend(RotateCard(new float3(0f, 90f, 0), _cardFront.transform).OnComplete(() => { ActiveCardFront = false; RotateCard(float3.zero, _cardBack.transform); }));
    }

    private Tween RotateCard(float3 endValue, Transform rotateObject) 
    {
        return rotateObject.DORotate(endValue,1f);
    }

    #endregion 
}