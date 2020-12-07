using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
public class Moveblock : MonoBehaviour
{
    private Sequence seq;

    // Start is called before the first frame update
    void Start()
    {
        seq = DOTween.Sequence();

        if (gameObject.name == "moveblock")
        {
            seq.Append(transform.DOLocalMoveY(-40f, 1f).SetEase(Ease.OutSine)).SetRelative();
            seq.Append(transform.DOLocalMoveY(40f, 1f).SetEase(Ease.InOutSine)).SetRelative();
            seq.Append(transform.DOLocalMoveY(-40f, 1f).SetEase(Ease.InSine)).SetRelative();
            seq.SetLoops(-1000);
            Debug.Log("wawawa");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
