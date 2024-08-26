using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PenguinColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer penguinRenderer;


    private void Start()
    {
        penguinRenderer.color = Color.white;
    }

    private void Update()
    {
        if (penguinRenderer.color == Color.white)
        {
            ChangeColor();
        }
    }

    public void ChangeColor()
    {
        if (penguinRenderer.color == Color.white)
        {
            penguinRenderer.DOColor(Color.red, 1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                penguinRenderer.DOColor(Color.blue, 1f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    penguinRenderer.DOColor(Color.green, 1f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        penguinRenderer.DOColor(Color.white, 1f).SetEase(Ease.Linear).OnComplete(() =>
                        {
                            DOTween.Kill(penguinRenderer);
                        });
                    });
                });
            });
        }
    }
}
