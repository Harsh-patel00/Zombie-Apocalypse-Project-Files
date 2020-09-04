using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int health;
	public int damage;
	public Vector3 randomPosition;

	private void Start()
	{
		randomPosition = new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), 0f);
	}
	public void TakeDamage(int Damage)
	{
		health -= Damage;

		if (health <= 0)
		{
			Die();
		}
	}

	public void GiveDamage()
	{
		FindObjectOfType<PlayerHealth>().health -= damage;
	}

	private void Die()
	{
		Destroy(gameObject);
		//Instantiate(FindObjectOfType<Enemy>(), randomPosition, Quaternion.identity);
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			GiveDamage();
		}
	}

}
