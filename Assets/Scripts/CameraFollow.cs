using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private GameObject player;
    private Vector3 offset;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    void LateUpdate() {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + offset.z);
    }
}
