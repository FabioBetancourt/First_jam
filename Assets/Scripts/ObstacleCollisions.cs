using UnityEngine;

public class ObstacleCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject thePlayer;
    public GameObject charModel;


    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<PlayerController>().enabled = false;
        charModel.GetComponent<Animator>().Play($"Stumble Backwards");
    }
}
