using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    [Header("Door Settings")]
    public bool isLocked = false; 
    public GameObject nextRoom;

    
    public void Interact()
    {
        

        if (isLocked)
        {
           
            if (Random.Range(0f, 1f) > 0.7f) 
            {
                Debug.Log("Porta trancada! Tente novamente.");
                return;
            }
            isLocked = false;
        }

        
        transform.Rotate(0, 90, 0);
        
        
        if (nextRoom != null)
        {
            nextRoom.SetActive(true);
            
            FindObjectOfType<PlayerHandler>().transform.position = nextRoom.transform.position + Vector3.forward * 2;
        }

        Debug.Log("Porta aberta! Avance para o próximo quarto.");
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Aproxime-se e pressione E.");
        }
    }
}
