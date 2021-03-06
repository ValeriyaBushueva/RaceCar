using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton :Button
{
   public static string ChangeButtonType => nameof(_animationButtonType);
   public static string CurveEase => nameof(_curveEase);
   public static string Duration => nameof(_duration);
  
   [SerializeField]
   private AnimationButtonType _animationButtonType = AnimationButtonType.ChangePosition;
  
   [SerializeField]
   private Ease _curveEase = Ease.Linear;
  
   [SerializeField]
   private float _duration = 0.6f;
  
   private float _strength = 30.0f;
   private RectTransform _rectTransform;

   protected override void Awake()
   {
      base.Awake();

      _rectTransform = GetComponent<RectTransform>();
   }

   public override void OnPointerClick(PointerEventData eventData)
   {
      base.OnPointerClick(eventData);

      ActivateAnimation();
   }

   private void ActivateAnimation()
   {
      switch (_animationButtonType)
      {
         case AnimationButtonType.ChangeRotation:
            _rectTransform.DOShakeRotation(_duration, Vector3.forward * _strength).SetEase(_curveEase);
            break;
         case AnimationButtonType.ChangePosition:
            _rectTransform.DOShakeAnchorPos(_duration, Vector2.one * _strength).SetEase(_curveEase);
            break;
      }
   }


   // public static string ChangeButtonType = nameof(_buttonType);
   // public static string Duration = nameof(_duration);
   //
   // [SerializeField] private AnimationButtonType _buttonType;
   //
   // [SerializeField] private float _duration;
   // private RectTransform _rectTransform;
   //
   // protected override void Awake()
   // {
   //    base.Awake();
   //    _rectTransform = GetComponent<RectTransform>();
   // }
   //
   // public override void OnPointerClick(PointerEventData eventData)
   // {
   //    base.OnPointerClick(eventData);
   //    ActivateAnimation();
   // }
   //
   // private void ActivateAnimation()
   // {
   //    switch (_buttonType)
   //    {
   //       case AnimationButtonType.ChangePosition:
   //          _rectTransform.DOShakePosition(_duration, 3, 5);
   //          break;
   //       case AnimationButtonType.ChangeRotation:
   //          _rectTransform.DOShakePosition(_duration, 3, 5);
   //          break;
   //       
   //    }
   // }
}
