using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topping : MonoBehaviour
{
    public SpriteRenderer SpriteRedner;
    // ���� �̹��� ���
    public Sprite[] Toppings;

    private void Awake()
    {
        SetRandomTopping();
    }

    private void SetRandomTopping()
    {
        int index = Random.Range(0, Toppings.Length);
        SpriteRedner.sprite = Toppings[index];
    }
}
