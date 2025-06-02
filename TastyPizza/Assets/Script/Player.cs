using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //위치 설정 변수
    public Vector2 MinPos;
    public Vector2 MaxPos;

    private Transform _playerTransform;
    private Vector3 _playerPosition => _playerTransform.position;
    private Vector2 _moveValue; //이동값 +1 -1 두 방향

    private GameObject _tile;
    public float TileSize
    {
        get { return _tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }

    private void Start()
    {
        _playerTransform = transform;
        _moveValue = Vector2.one;
    }

    // Update is called once per frame
    private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(0, TileSize, 0);
            //위쪽으로 1만큼 이동한다.
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(0, -TileSize, 0);
            //아래쪽으로 1만큼 이동한다.
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-TileSize, 0, 0);
            //왼쪽으로 1만큼 이동한다.
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(TileSize, 0, 0);
            //오른쪽으로 1만큼 이동한다.
        }
    }
}
