using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.TryGetComponent(out Brick brick)) brick.Hit(1);
    }
}
