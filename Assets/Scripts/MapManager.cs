using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public Tilemap groundTilemap;

    public Tile grassTile;
    public Tile soilTile;

    public int width = 50;
    public int height = 50;

    public TileData[,] mapData;

    // Start is called before the first frame update
    void Start()    
    {
        mapData = new TileData[width, height];
        ReadTilemapIntoData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReadTilemapIntoData() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {

                TileBase tile = groundTilemap.GetTile(new Vector3Int(x, y, 0));

                mapData[x, y] = new TileData();

                if (tile == grassTile)
                    mapData[x, y].type = TileType.Grass;
                else if (tile == soilTile)
                    mapData[x, y].type = TileType.Soil;
                // else if (tile == tilledTile)
                //     mapData[x, y].type = TileType.Tilled;
                else
                    mapData[x, y].type = TileType.Grass; // default
            }
        }
    }

    public void SetTile(int x, int y, TileType type) {

        mapData[x, y].type = type;

        switch (type) {
            case TileType.Grass:
                groundTilemap.SetTile(new Vector3Int(x, y, 0), grassTile);
                break;
            case TileType.Soil:
                groundTilemap.SetTile(new Vector3Int(x, y, 0), soilTile);
                break;
            // case TileType.Tilled:
            //     groundTilemap.SetTile(new Vector3Int(x, y, 0), tilledTile);
            //     break;
        }
    }
}
