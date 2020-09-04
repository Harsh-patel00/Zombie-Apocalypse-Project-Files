using UnityEngine;
using Cinemachine;

public class CameraFollowInitializedPlayer : MonoBehaviour
{

    public GameObject player;

    private Transform _tPlayer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        var vcam = GetComponent<CinemachineVirtualCamera>();
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        _tPlayer = player.transform;
        vcam.Follow = _tPlayer;
    }
}
