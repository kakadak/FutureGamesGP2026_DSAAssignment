using UnityEngine;

public class Background : MonoBehaviour
{
    public Transform playerTransform; 
    public Transform[] tiles;         
    public float tileSizex = 20f;     
    public float tileSizey = 20f;
    

    private void Update()
    {
        if (!GameStateManager.Instance.IsPlaying()) return;
        foreach (Transform tile in tiles)
        {
            float diffX = playerTransform.position.x - tile.position.x;
            float diffY = playerTransform.position.y - tile.position.y;
            if (Mathf.Abs(diffX) > tileSizex * 1.5f)
            {
                float newX = tile.position.x + Mathf.Sign(diffX) * tileSizex * 3f;
                tile.position = new Vector3(newX, tile.position.y, tile.position.z);
            }
            if (Mathf.Abs(diffY) > tileSizey * 1.5f)
            {
                float newY = tile.position.y + Mathf.Sign(diffY) * tileSizey * 3f;
                tile.position = new Vector3(tile.position.x, newY, tile.position.z);
            }
        }
    }
}