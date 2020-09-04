using UnityEngine;

public class FindCloset : MonoBehaviour
{
 	float distanceToClosetEnemy = Mathf.Infinity;
	GameObject closetEnemy;
	GameObject[] allEnemies;
	public Vector3 offset;

	private void Start()
	{
		closetEnemy = null;
		allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
		offset = new Vector3();
	}

	private void FindClosetZombie()
	{
		foreach(GameObject currentEnemy in allEnemies)
		{
			float distanceToEnemy = (currentEnemy.transform.position - transform.position).sqrMagnitude;
			if(distanceToEnemy < distanceToClosetEnemy)
			{
				distanceToClosetEnemy = distanceToEnemy;
				closetEnemy = currentEnemy;	
			}
		}
		Debug.DrawLine(transform.position, closetEnemy.transform.position);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		FindClosetZombie();
		closetEnemy.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position - offset;
	}
}
