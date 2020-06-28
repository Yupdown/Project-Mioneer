using Merle.Mioneer;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Merle.Mioneer
{
    public class MioneerTileMap : MonoBehaviour
    {
        public Tilemap FloorTileMap
        {
            get
            { return floorTilemap; }
        }
        [SerializeField]
        private Tilemap floorTilemap;

        public Tilemap WallTileMap
        {
            get
            { return wallTilemap; }
        }
        [SerializeField]
        private Tilemap wallTilemap;

        [SerializeField]
        private Tile floorTile;
        [SerializeField]
        private MioneerTile wallTile;

        private const int TileWidth = 16;

        private Vector3Int[] nearTilesOffset = new Vector3Int[]
        {
        new Vector3Int(1, 0, 0),
        new Vector3Int(-1, 0, 0),
        new Vector3Int(0, 1, 0),
        new Vector3Int(0, -1, 0),
        new Vector3Int(1, -1, 0),
        new Vector3Int(-1, 1, 0),
        new Vector3Int(1, 1, 0),
        new Vector3Int(-1, -1, 0)
        };

        private float[] nearTilesLight = new float[]
        {
        1f,
        1f,
        1f,
        1f,
        0.5f,
        0.5f,
        0.5f,
        0.5f
        };

        [SerializeField]
        private TextAsset blockSheetData;

        private void Awake()
        {
            Block.Register(blockSheetData.text);
            wallTile.Validate();
            
            for (int x = -TileWidth; x < TileWidth; x++)
            {
                for (int y = -TileWidth; y < TileWidth; y++)
                {
                    if (x * x + y * y < 30f)
                        RemoveWall(new Vector3Int(x, y, 0));
                    else
                        AddWall(new Vector3Int(x, y, 0));
                }
            }

            for (int x = -TileWidth; x < TileWidth; x++)
                for (int y = -TileWidth; y < TileWidth; y++)
                    UpdateTileColor(new Vector3Int(x, y, 0));
        }

        //private void Update()
        //{
        //    Vector2Int randomFloorPosition = Vector2Int.FloorToInt(Random.insideUnitCircle * 10f);
        //    Vector3Int coordination = new Vector3Int(randomFloorPosition.x, randomFloorPosition.y, 0);

        //    if (floorTilemap.GetTile<Tile>(coordination) != null)
        //        AddWall(coordination);
        //    else
        //        RemoveWall(coordination);
        //}

        public void AddWall(Vector3Int coordination)
        {
            floorTilemap.SetTile(coordination, null);
            wallTilemap.SetTile(coordination, wallTile);
            wallTilemap.SetTileFlags(coordination, TileFlags.None);

            UpdateTileColor(coordination);
            foreach (var offset in nearTilesOffset)
                UpdateTileColor(coordination + offset);
        }

        public void RemoveWall(Vector3Int coordination)
        {
            floorTilemap.SetTile(coordination, floorTile);
            wallTilemap.SetTile(coordination, null);

            foreach (var offset in nearTilesOffset)
                UpdateTileColor(coordination + offset);
        }

        public void UpdateTileColor(Vector3Int coordination)
        {
            float lightValue = 0f;
            for (int index = 0; index < nearTilesOffset.Length; index++)
            {
                Vector3Int targetCoordination = coordination - nearTilesOffset[index];
                bool inside = targetCoordination.x >= -TileWidth && targetCoordination.x < TileWidth && targetCoordination.y >= -TileWidth && targetCoordination.y < TileWidth;

                if (!wallTilemap.GetTile(targetCoordination) && inside)
                    lightValue = nearTilesLight[index] > lightValue ? nearTilesLight[index] : lightValue;
            }

            wallTilemap.SetColor(coordination, Color.Lerp(Color.black, Color.white, lightValue));
        }

        public MioneerTile GetTile(Vector2Int position)
        {
            return wallTilemap.GetTile<MioneerTile>(new Vector3Int(position.x, 0, position.y));
        }
    }

    public class MioneerTile : Tile
    {
        public Block TileBlock
        {
            get
            { return tileBlock; }
        }
        private Block tileBlock;

        [SerializeField]
        private string tileKey;

        public void Validate()
        {
            tileBlock = Block.GetBlockByKey(tileKey);
        }

#if UNITY_EDITOR
        [MenuItem("Assets/Create/MioneerTile")]
        public static void CreateRoadTile()
        {
            string path = EditorUtility.SaveFilePanelInProject("Save Mioneer Tile", "New Mioneer Tile", "Asset", "Save Mioneer Tile", "Assets");
            if (path == "")
                return;
            AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<MioneerTile>(), path);
        }
#endif
    }
}