using UnityEngine;

namespace Junky
{
    public class Destroyer : MonoBehaviour
    {
        public void DestroyObject(GameObject gameObjectToDestroy)
        {
            Destroy(gameObjectToDestroy);
        }
    }
}