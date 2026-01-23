using UnityEngine;
using UnityEngine.U2D;

public abstract class Tile : MonoBehaviour
{
    private SpriteRenderer Sprite;
    private Collider2D Collider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start()
    {
        if(GetComponent<Collider2D>() != null) //Check to see if there's already a collider component
        {
            Collider = GetComponent<Collider2D>(); //If there is, use that one
        }
        else
        {
            Collider = gameObject.AddComponent<BoxCollider2D>(); //Otherwise, use BoxCollider as default
        }   //If you don't want a collider, the Start function can be overridden in an inherited class
        
        Sprite = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected abstract void OnCollisionEnter2D(Collision2D collision);
}
