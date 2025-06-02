using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject _tile;

    /* 위치 설정 및 이동 변수 */
    public Vector2 MinPos; // 최소 x, y 좌표
    public Vector2 MaxPos; // 최대 x, y 좌표
    private Vector3 _playerPos; // 플레이어의 위치
    private Vector3 _firPos; // 처음 시작할 위치
    private Vector2 _playerPosRem; // 플레이어의 이전 위치를 기억

    /* 꼬리 리스트 */
    [SerializeField]
    private GameObject ToppingPrefab;

    public GameObject FirTile; // 처음 시작할 위치의 타일 오브젝트

    Vector3 _moveDir = new Vector3(0, 0, 0); // 이동 방향 설정 변수


    /* 시간 변수 */
    float _spawn = 0.1f; // (_spawn) 초에 한 번씩 이동
    float _delta = 0; // _delta time 저장 변수

    float _sumX; // 맵의 한 변 길이


    /* 플레이어 스테이터스 변수 */
    bool _ate = false; // 토핑을 먹었는가?
    bool _isDied = false; // 게임 오버인가? -> 벽에 부딪힘, 꼬리와 부딪힘

    List<Transform> _tails = new List<Transform>();


    public float TileSize // 타일 한 변의 길이
    {
        get { return _tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x*_tile.transform.localScale.x; }
    }


    private void Start()
    {
        _firPos = FirTile.transform.position;

        this.gameObject.transform.position = _firPos; // 게임 오브젝트를 시작 위치로

        _sumX = TileSize * 15; // 맵 변의 길이 계산

        MinPos = new Vector3(_firPos.x, _firPos.y - _sumX, 0);
        MaxPos = new Vector3(_firPos.x + _sumX-TileSize, _firPos.y, 0);
    }


    private void Update()
    {
        Move();

        _delta += Time.deltaTime;
        
        if(_delta>_spawn) // 시간 찰 때마다 움직이기
        {
            _playerPosRem = transform.position; // 움직이기 전 위치 기억하고
            transform.Translate(_moveDir); // 움직이기
            _delta = 0; // 시간 초기화
        }


        if(_isDied) // 게임오버 조건 충족 시
        {
            Destroy(this.gameObject);
        }

    }


    private void Move()
    {
        Vector2 playerPos = transform.position;

        if (Input.GetKeyDown(KeyCode.UpArrow)) // 위
        {
            _moveDir = new Vector3(0, TileSize, 0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) // 아래
        {
            _moveDir = new Vector3(0, -TileSize, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) // 왼 
        {
            _moveDir = new Vector3(-TileSize, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) // 오
        {
            _moveDir = new Vector3(+TileSize, 0, 0);
        }


        // 맵 밖으로 나가면 죽는 거 계산
        if (playerPos.x + _moveDir.x + 0.01f < MinPos.x
            || playerPos.x + _moveDir.x - 0.01f > MaxPos.x
            || playerPos.y + _moveDir.y < MinPos.y
            || playerPos.y + _moveDir.y > MaxPos.y)
        {
            _moveDir = new Vector3(0, 0, 0);
            _isDied = true;
        }
    }
}

