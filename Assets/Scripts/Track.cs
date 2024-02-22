using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour {

    public GameObject[] coins;
    public GameObject[] obstacles;
    public Vector2 coinsNumber;
    public Vector2 obstaclesNumber;

    private float trackEndPosition = 314f;

    void Start() {
        CreateTrackItems(coinsNumber, coins);
        CreateTrackItems(obstaclesNumber, obstacles);
    }

    void CreateTrackItems(Vector2 itemsNumber, GameObject[] items) {
        List<GameObject> itemsList = new List<GameObject>();
        int newItemsNumber = (int) Random.Range(itemsNumber.x, itemsNumber.y);

        for (int i = 0; i < newItemsNumber; i++) {
            GameObject item = items[Random.Range(0, items.Length)];
            float itemPosition = (trackEndPosition / newItemsNumber) + (trackEndPosition / newItemsNumber) * i;
            float randomPosition = Random.Range(itemPosition, itemPosition + 1);

            itemsList.Add(Instantiate(item, transform));
            itemsList[i].transform.localPosition = new Vector3(transform.position.x, transform.position.y, randomPosition);

            if (itemsList[i].GetComponent<ChangeLane>() != null) {
                itemsList[i].GetComponent<ChangeLane>().PositionLane();
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<Player>().IncreaseSpeed();
            transform.position = new Vector3(0, 0, transform.position.z + trackEndPosition * 2);
        }
    }
}
