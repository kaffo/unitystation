using UnityEngine;
using UnityEngine.Tilemaps;


public class SimpleTile : BasicTile
{

	private Sprite spriteCache;

	public Sprite sprite;

	public override Sprite PreviewSprite => sprite;



	public override bool StartUp(Vector3Int position, ITilemap _tilemap, GameObject go)
	{
		CullManager.basicTiles.Add(this);
		return base.StartUp(position, _tilemap, go);
	}

	public void CullTile(bool isOn)
	{
		TileData tData = new TileData();
		GetTileData(LocalPos(), iTilemap, ref tData);

		if (tData.sprite != null)
		{
			spriteCache = tData.sprite;
		}
		if (!isOn)
		{
			sprite = null;
			Debug.Log("ADD NO TILE");
		}
		else
		{
			Debug.Log("ADD DEFAULT TILE");
			sprite = spriteCache;
		}
	}
}
