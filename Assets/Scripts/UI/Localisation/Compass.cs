using UnityEngine;

public class Compass : MonoBehaviour
{
    [SerializeField] private GameObject Needles;
    private Transform Player;
    
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Player = player.transform;
        }
        else
        {
            Debug.LogError("Player not found");
        }
    }

    void Update()
    {
        if (Player == null || Needles == null) return;

        // Récupérer l'angle du Player sur l'axe Y (souvent utilisé pour la rotation)
        float playerYRotation = Player.eulerAngles.y;

        // Appliquer la rotation sur l'axe Z avec un décalage de 30 degrés
        Needles.transform.rotation = Quaternion.Euler(0, 0, -playerYRotation + 30);
    }
}
