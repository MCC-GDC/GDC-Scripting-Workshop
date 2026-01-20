using UnityEngine;
using UnityEngine.U2D;

public abstract class TileParent : MonoBehaviour
{
    public Sprite sprite;
    private Collider2D collider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<Sprite>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        
    }
}
