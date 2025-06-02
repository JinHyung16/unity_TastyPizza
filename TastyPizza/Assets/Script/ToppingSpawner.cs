using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingSpawner : MonoBehaviour
{
    //Food Prefab
    public GameObject ToppingPrefab;

    //Borders
    public Transform BorderTop;
    public Transform BorderBottom;
    public Transform BorderRight;
    public Transform BorderLeft;

    // Use this for initialization
    private void Start ()
    {
        InvokeRepeating("Spwan", 3, 4);
	}

    //Spwan one piece of food
    private void Spwan()
    {
        //x position between left & right border
        int x = (int)Random.Range(BorderLeft.position.x, BorderRight.position.x);

        //y position between top & bottom border
        int y = (int)Random.Range(BorderBottom.position.y, BorderTop.position.y);

        //Instantiate the food at (x,y)
        Instantiate(ToppingPrefab, new Vector2(x, y), Quaternion.identity);
        // default rotation
    }

}
