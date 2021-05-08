using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
//side codes: 0-field 1-road 2-castle
//middle codes: 0-field or non-ending road 1-road end 2-castle interior 3-monastery

[CreateAssetMenu]
public class TileData : ScriptableObject
{
public TileBase[] tiles;
	public int top, bottom, right, left, middle;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
