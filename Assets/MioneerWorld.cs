using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MioneerWorld : MonoBehaviour
{
    public const int MapWidth = 64;

    [SerializeField]
    private Tilemap _tileMap;

    public void Start()
    {
        Tile tileSolid = new Tile();

        tileSolid.sprite = Resources.Load<Sprite>("Atlases/tile");
        tileSolid.colliderType = Tile.ColliderType.Grid;

        for (int i = 0; i < 4096; i++)
        {
            int coordinateX = i % MapWidth;
            int coordinateY = -i / MapWidth;

            if (Mathf.PerlinNoise(coordinateX * 0.2f, coordinateY * 0.2f) > 0.5f)
                continue;
            
            _tileMap.SetTile(new Vector3Int(coordinateX, coordinateY, 0), tileSolid);
        }
    }
}
