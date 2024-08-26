using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class platform : MonoBehaviour
{
    private void Start()
    {
      
    }

    private void Update()
    {
        if (gameObject.transform.position.x == 0)
        {
            MovingPlatform();
        }
    }

    public void MovingPlatform()
    {
        if (gameObject.transform.position.x == 0)
        {
            gameObject.transform.DOMoveX(3, 4f).SetEase(Ease.Linear).OnComplete(() =>
            {
                gameObject.transform.DOMoveX(0, 4f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    DOTween.Kill(gameObject);
                });
            });
        }
    }
}
