using System;
using Cysharp.Threading.Tasks;
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

    private bool ActiveCardFront
    {
        set
        {
            _cardFront.SetActive(value);
            _cardBack.SetActive(!value);
        }
    }

    #endregion

    #region Methods

    public void Initialize(GameObject cardFront, GameObject cardBack)
    {
        _cardFront = cardFront;
        _cardBack = cardBack;

    }
    
    public void Flip(Action callback = null)
    {
        Sequence seq = DOTween.Sequence();

        seq.Prepend(RotateCard(new float3(0f, 90f, 0), _cardBack.transform).OnComplete(() =>
        {
            ActiveCardFront = true;
            RotateCard(float3.zero, _cardFront.transform);

        })).OnComplete(() => { _ = DelayFlippedCallback(callback);});

    }

    public void Restore()
    {
        RotateBackSequence();
    }

    private Sequence RotateBackSequence()
    {
        Sequence seq = DOTween.Sequence();

       return seq.Prepend(RotateCard(new float3(0f, 90f, 0), _cardFront.transform).OnComplete(() =>
        {
            ActiveCardFront = false;
            RotateCard(float3.zero, _cardBack.transform);
        }));

    }

    private Tween RotateCard(float3 endValue, Transform rotateObject)
    {
        return rotateObject.DORotate(endValue, 0.25f);
    }

    private async UniTask DelayFlippedCallback(Action callback)
    {
       await UniTask.WaitForSeconds(1);
       
       callback?.Invoke();
    }
}

#endregion 
