using Unity.VisualScripting;
using UnityEngine;

public class GroundTile : Tile
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    new void Start()
    {
        base.Start();
        gameObject.tag = "Terrain";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
