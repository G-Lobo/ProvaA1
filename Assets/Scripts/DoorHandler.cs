using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    [Header("Door Settings")]
    public GameObject[] rooms; // prefabs de corredores
    private GameObject currentRoom; // referência ao corredor atual

    [Header("Spawn Settings")]
    public Transform spawnPoint; // onde o novo corredor nasce

    public void Interact()
    {
        // sorteia um corredor da lista
        int roomNumber = Random.Range(0, rooms.Length);
        GameObject nextRoomPrefab = rooms[roomNumber];

        if (nextRoomPrefab)
        {
            // pega o corredor atual (pai da porta, por exemplo)
            currentRoom = transform.root.gameObject;

            // instancia o novo corredor
            GameObject nextRoomInstance = Instantiate(nextRoomPrefab, spawnPoint.position, spawnPoint.rotation);

            // move o player para a entrada do novo corredor
            PlayerHandler player = FindObjectOfType<PlayerHandler>();
            if (player)
            {
                player.transform.position = nextRoomInstance.transform.position + Vector3.forward * 2;
                player.transform.rotation = nextRoomInstance.transform.rotation;
            }

            SimpleEnemy enemy = FindObjectOfType<SimpleEnemy>();
            if (enemy)
            {
                enemy.transform.position = nextRoomInstance.transform.position + Vector3.forward * -4;
            }
            
            // destrói o corredor antigo
            Destroy(currentRoom);

            Debug.Log("Porta aberta! Novo corredor: " + nextRoomInstance.name);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Aproxime-se e pressione E.");
        }
    }
}