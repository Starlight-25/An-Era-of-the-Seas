using UnityEngine;
using Items;

public class Tests : MonoBehaviour
{
    void Start()
    {
        // Créer une instance du StigmaLoader
        StigmaLoader loader = new StigmaLoader();

        // Charger les stigmates
        StigmaList stigmaList = loader.LoadStigma();

        if (stigmaList != null)
        {
            // Vérifiez combien de stigmates ont été chargés
            Debug.Log($"Nombre de stigmates chargés : {stigmaList.Stigmata.Count}");

            // Affichez chaque stigma dans la liste
            foreach (var stigma in stigmaList.Stigmata)
            {
                Debug.Log(
                    $"Stigma: {stigma.Name}, Rarity: {stigma.Rarity}, MaxLevel: {stigma.MaxLevel}, Stats: {string.Join(", ", stigma.Stats)}");
            }
        }
        else
        {
            Debug.LogError("La liste de stigmates est vide ou une erreur est survenue.");
        }
    }
}
