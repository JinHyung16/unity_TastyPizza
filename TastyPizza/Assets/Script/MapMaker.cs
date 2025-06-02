using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaker : MonoBehaviour 
{
    // 타일 프리팹 가져오기
    [SerializeField]
    private GameObject Tile1;
    [SerializeField]
    private GameObject Tile2;
    public Vector3 InitSpawnPos;

    Vector3 _firePos; // 처음 배치 시작할 위치 (-2.187, 4.125, 0)
    public GameObject MapObj;

    private int _maxX = 15, _maxY = 15; // 15X15 맵 메이킹


    public float TileSize // 타일 한 칸 크기 지정
    {
        get { return Tile1.GetComponent<SpriteRenderer>().sprite.bounds.size.x*Tile1.transform.localScale.x ; }
    }


    private void Start ()
    {
        CreateLevel();
    }


    public void TileMaking(GameObject tile, int x, int y) // 타일 만들고 -> 위치 지정
    {
        GameObject newtile = Instantiate(tile) ;
        newtile.transform.position = new Vector3(_firePos.x + TileSize * x, _firePos.y - TileSize * y, 0);

        newtile.transform.parent = MapObj.transform; // Map 오브젝트에 타일 정리
    }


    private void CreateLevel() // 노랑 주황 번갈아 가며 배치
    {
        _firePos = InitSpawnPos;

        for (int y = 0; y < _maxY; y++)
        {
            for (int x = 0; x < _maxX; x++)
            {
                if (y % 2 == 0)
                    if (x % 2 == 0)
                    {
                        TileMaking(Tile1, x, y);
                    }
                    else
                    {
                        TileMaking(Tile2, x, y);

                    }
                else
                    if (x % 2 == 0)
                    {
                        TileMaking(Tile2, x, y);
                     }
                    else
                    {
                        TileMaking(Tile1, x, y);

                    }


            }
        }
    }
}
