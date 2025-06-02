using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController    : MonoBehaviour{

    [SerializeField]
    private GameObject tile;

    /* 위치 설정 및 이동 변수 */
    public Vector2 minpos; // 최소 x, y 좌표
    public Vector2 maxpos; // 최대 x, y 좌표
    private Vector3 playerPos; // 플레이어의 위치
    private Vector3 firPos; // 처음 시작할 위치

    GameObject firTile; // 처음 시작할 위치의 타일 오브젝트

    Vector3 move = new Vector3(0, 0, 0); // 이동 방향 설정 변수


    /* 시간 변수 */
    float span = 0.5f; //0.5초에 한 번씩 이동
    float delta = 0; // delta time 저장 변수

    float sumX; // 맵의 한 변 길이


    /* 플레이어 스테이터스 변수 */
    bool ate = false; // 토핑을 먹었는가?
    bool isDied = false; // 게임 오버인가? -> 벽에 부딪힘, 꼬리와 부딪힘





    public float TileSize // 타일 한 변의 길이
    {
        get { return tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x*tile.transform.localScale.x; }
    }



    void Start()
    {
        firTile = GameObject.Find("LevelMaker");

        firPos = firTile.transform.position;

        this.gameObject.transform.position = firPos; // 게임 오브젝트를 시작 위치롤
        sumX = TileSize * 15;

        minpos = new Vector3(firPos.x, firPos.y - sumX, 0);
        maxpos = new Vector3(firPos.x + sumX, firPos.y, 0);
    }

    void Update()
    {
        playerPos = this.gameObject.transform.position; // 플레이어 위치 갱신

        Move();

        if (playerPos.x < minpos.x || playerPos.x > maxpos.x || playerPos.y < minpos.y || playerPos.y > maxpos.y)
        { move = new Vector3(0, 0, 0); }

        delta += Time.deltaTime;
        
        if(delta>span)
        {
            transform.Translate(move);
            delta = 0;
        }

    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            move = new Vector3(0, TileSize, 0);
            //위쪽으로 1만큼 이동한다.
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            move = new Vector3(0, -TileSize, 0);
            //아래쪽으로 1만큼 이동한다.
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            move = new Vector3(-TileSize, 0, 0);
            //왼쪽으로 1만큼 이동한다.
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            move = new Vector3(+TileSize, 0, 0);
            //오른쪽으로 1만큼 이동한다.
        }

    }


}