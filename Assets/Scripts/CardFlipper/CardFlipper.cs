using DG.Tweening;
using HCC.Interfaces;
using Unity.Mathematics;
using UnityEngine;

public class CardFlipper : MonoBehaviour, IFlipper
{

    #region Fields

    [SerializeField] private GameObject _cardBack;
    [SerializeField] private GameObject _cardFront;


    #endregion

    #region Properties

    private bool ActiveCardFront { set { _cardFront.SetActive(value); _cardBack.SetActive(!value); } }

    #endregion

    #region Functions

    // Start is called before the first frame update
    void Start()
    {
        
    }

    #endregion

    #region Methods

    public void Flip()
    {
        Sequence seq = DOTween.Sequence();

        seq.Prepend(RotateCard(new float3(0f, 90f, 0), _cardBack.transform).OnComplete(() => { ActiveCardFront = true; RotateCard(float3.zero, _cardFront.transform); }));
    }

    private Tween RotateCard(float3 endValue, Transform rotateObject) 
    {
        return rotateObject.DORotate(endValue,2f);
    }

    #endregion 
}