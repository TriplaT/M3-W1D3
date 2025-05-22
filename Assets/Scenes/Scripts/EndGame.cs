using UnityEngine;

public class EndGame : MonoBehaviour
{
    private bool isPlayer1Inside = false;
    private bool isPlayer2Inside = false;

    // Quando un player entra nel trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Riconosciamo i due player in base al nome del GameObject
            if (other.gameObject.name == "Player1")
                isPlayer1Inside = true;

            if (other.gameObject.name == "Player2")
                isPlayer2Inside = true;

            // Controlla se sono entrambi nel trigger
            CheckIfLevelCompleted();
        }
    }

    // Quando un player esce dal trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.gameObject.name == "Player1")
                isPlayer1Inside = false;

            if (other.gameObject.name == "Player2")
                isPlayer2Inside = false;
        }
    }

    // Verifica se entrambi i player sono dentro
    private void CheckIfLevelCompleted()
    {
        if (isPlayer1Inside && isPlayer2Inside)
        {
            Debug.Log("Livello completato!");
        }
    }
}
