using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public void DestroyObject(GameObject gameObjectToDestroy)
    {
        Destroy(gameObjectToDestroy);
    }
}
