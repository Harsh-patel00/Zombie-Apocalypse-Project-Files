using UnityEngine;

public class StartFromHere : MonoBehaviour
{
    public Transform spawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = gameObject.transform.position;
    }
}
