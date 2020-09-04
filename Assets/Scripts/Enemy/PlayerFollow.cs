using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class PlayerFollow : MonoBehaviour
{

    public float speed;

    private Transform _targetToFollow;
    
    // Start is called before the first frame update
    void Start()
    {
        _targetToFollow = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

	// Update is called once per frame
	private void Update()
    {
        if (_targetToFollow != null)
        {
            if (Vector2.Distance(transform.position, _targetToFollow.position) > 1.5)
            {
                //Debug.DrawLine(transform.position, _targetToFollow.position, Color.yellow);

                transform.position =
                    Vector2.MoveTowards(transform.position, _targetToFollow.position, speed * Time.deltaTime);
            }
        }
        else
        {
            Debug.LogWarning("Player Not Found :(");
        }
    }
}
