using UnityEngine;
using UnityEngine.Tilemaps;


public abstract class BasicTile : LayerTile
{
	public bool AtmosPassable;
	public bool IsSealed;
	public bool Passable;

	private Vector3Int localPos;
	public Vector3Int LocalPos()
	{
		return localPos;
	}
	public Tilemap tileMap;
	public ITilemap iTilemap;
	

	public Vector3 WorldPos { get { return tileMap.CellToWorld(localPos); } }

	public override void RefreshTile(Vector3Int position, ITilemap tilemap)
	{
		foreach (Vector3Int p in new BoundsInt(-1, -1, 0, 3, 3, 1).allPositionsWithin)
		{
			tilemap.RefreshTile(position + p);
		}

		localPos = position;
	}

	public override bool StartUp(Vector3Int position, ITilemap _tilemap, GameObject go)
	{
		tileMap = _tilemap.GetComponent<Tilemap>();
		iTilemap = _tilemap;
		localPos = position;
		
		return base.StartUp(position, _tilemap, go);
	}

	public bool IsPassable()
	{
		return Passable;
	}

	public bool IsAtmosPassable()
	{
		return AtmosPassable;
	}

	public bool IsSpace()
	{
		return IsAtmosPassable() && !IsSealed;
	}

	
}
