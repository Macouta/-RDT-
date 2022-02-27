using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class WhirlpoolController : MonoBehaviour
{

    public Material material;

    void Update()
    {
        if (material != null)
        {
            material.SetVector("_Position", new Vector2(transform.position.x,
               transform.position.z));
            material.SetVector("_Scale", new Vector2(transform.localScale.x,
               transform.localScale.y));
        }
    }

    public void animScale(float duration) {
        DOTween.Sequence()
            .Append(transform.DOScaleX(2f, duration / 2.0f).SetEase(Ease.InOutBounce))
            .Append(transform.DOScaleX(1f, duration / 2.0f).SetEase(Ease.InOutBounce));
        DOTween.Sequence()
            .Append(transform.DOScaleY(2f, duration / 2.0f).SetEase(Ease.InOutBounce))
            .Append(transform.DOScaleY(1f, duration / 2.0f).SetEase(Ease.InOutBounce));
    }
}