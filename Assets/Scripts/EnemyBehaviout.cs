using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public Transform player;        // arrasta o Player aqui no Inspector
    public float moveSpeed = 3f;    // velocidade de movimento
    public float chaseRange = 15f;  // distância máxima pra começar a perseguir
    public float attackRange = 2f;  // distância mínima para "pegar"

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= chaseRange)
        {
            // Rotaciona para olhar pro player
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

            // Move na direção do player
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.deltaTime
            );

            // Se encostar, game over
            if (distance <= attackRange)
            {
                Debug.Log("Você foi pego!");
                Time.timeScale = 0f; // pausa o jogo
            }
        }
    }
}
