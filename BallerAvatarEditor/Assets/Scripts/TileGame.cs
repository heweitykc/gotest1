using UnityEngine;
using System.Collections.Generic;

class Tile
{
    public int x;
    public int y;
    public int id;

    public Tile(int id, int x, int y)
    {
        this.id = id;
        this.x = x;
        this.y = y;
    }
}

class TilePart
{
    public int width;
    public int height;

    public List<Tile> tiles = new List<Tile>();

    public TilePart(int width, int height)
    {
        this.width = width;
        this.height = height;
        for (int j = 0; j < height; j++)
            for (int i = 0; i < width; i++)            
            {
                tiles.Add(new Tile(0, i, j));
            }
    }

    public TilePart()
    {
        tiles = new List<Tile>();
    }

    public Tile GetTile(int x, int y)
    {
        return tiles[y * width + x];
    }
}

public class TileGame : MonoBehaviour
{
    TilePart tilemap;

	void Awake () {
        tilemap = new TilePart(20,20);
    }
		
	void Update () {
	
	}

    void OnGUI()
    {
        for (int j = 0; j < tilemap.height; j++)
            for (int i = 0; i < tilemap.width; i++)
            {
                Tile t = tilemap.GetTile(i,j);
                GUI.Label(new Rect(20*i, 20*j, 20, 20), "EE");
            }      
    }
}
