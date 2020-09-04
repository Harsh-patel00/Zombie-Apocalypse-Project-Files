using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    private float _randY;
    private float _randX;
    private Vector2 _whereToSpawn;
    public float spawnRate = 2f;
    private float _nextSpawn = 0.0f;
    private int _enemyCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (_enemyCount >= 5) return;
        
        if (!(Time.time > _nextSpawn)) return;
        
        _nextSpawn = Time.time + spawnRate;
        _randX = Random.Range(-20.0f, 20.0f);
        _randY = Random.Range(-20.0f, 20.0f);
        _whereToSpawn = new Vector2(_randX, _randY);
        Instantiate(enemy, _whereToSpawn, Quaternion.identity);
        _enemyCount += 1;
    }
}
