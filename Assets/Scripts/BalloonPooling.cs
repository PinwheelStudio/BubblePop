using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class BalloonPooling : MonoBehaviour {
    // Prefab reference
    public static BalloonObject GameObject { get; set; }
    // Developer's Room
    public static Vector2 HIDDEN_POSITION = new Vector2(-1000, -1000);
    // Pool
    static private List<BalloonPooling> _pool;
    // 
    private bool _isActive;
   
    static BalloonPooling FindAvailableObject()
    {
        foreach(var tmp in _pool)
        {
            if (tmp._isActive)
                return tmp;
        }
        return null;
    }
    static public void Spawn(Vector2 position, Quaternion rotation)
    {
        // Find an available object (with isActive = false)
        BalloonPooling newObject = FindAvailableObject();

        if (newObject)
        {
            // Activate it
            newObject.SelfSpawn(position, rotation);
        }
        else
        {
            // Cannot find instantiate a new one
            newObject = (Instantiate(GameObject)).GetComponent<BalloonPooling>();
            newObject.SelfSpawn(position, rotation);                        
            Debug.Log("Total Object Count: " + _pool.Count);
        }
    }
    private void SelfSpawn(Vector2 position, Quaternion rotation)
    {
        _isActive = true;
        transform.position = position;
        transform.rotation = rotation;

        // Better activate other stuff. i.e: Physic, Renderer, etc.
    }

    // This method is called when the script is loaded
    protected void Awake()
    {
        // If the pool does not exist, create one
        if (_pool == null)
        {
            _pool = new List<BalloonPooling>();
        }

        // Add myself into the pool and set my activation to false
        _pool.Add(this);
        _isActive = false;
    }

    // This method is called before the script is destroyed
    protected void OnDestroy()
    {
        // Remove me out of the pool
        _pool.Remove(this);

        // If I was the last one in the pool, better destroy the pool too
        if (_pool.Count == 0)
        {
            _pool = null;
        }
    }
     public static void Remove (BalloonPooling obj) {
        obj.SelfRemove ();
    }
    private void SelfRemove()
    {
        _isActive = false;
        transform.position = HIDDEN_POSITION;

        // Better de-activate other stuff. i.e: Physic, Renderer, etc.
    }

}
