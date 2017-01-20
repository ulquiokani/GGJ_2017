using UnityEngine;
using System.Collections;

//Version 1
public class MapObject : MonoBehaviour {

    public enum ObjectType
    {
        Terrain,
        
    }

    public Vector2 objectSize;
    public Vector2 centerPoint;
    public Vector2 movementVector = Vector2.zero;
    public ObjectType objectType = ObjectType.Terrain;

    private SpriteRenderer myRenderer;
    private Shader shaderObject;
	// Use this for initialization
	void Start () {
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        objectSize = gameObject.GetComponent<BoxCollider2D>().bounds.size;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetCenter(Vector2 newCenter)
    {
        movementVector = centerPoint - newCenter;
        centerPoint = newCenter;
        gameObject.transform.position = centerPoint;
    }

    public Vector2 GetMovementVector()
    {
        return movementVector;
    }

}
