using UnityEngine;

public class CharacterMenu : MonoBehaviour
{
    public GameObject PlayerUICanvas;
    public GameObject CharacterCanvas;

    public void ReturnInGameButton()
    {
        CharacterCanvas.SetActive(false);
        PlayerUICanvas.SetActive(true);
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) ReturnInGameButton();
    }
    
    
    
    
    
    
    
    
    
    
    public GameObject LevelUPElements;
    public GameObject StigmataElements;
    public GameObject BoatElements;
    public GameObject CrewMembersElements;

    public void LevelUpButton()
    {
        StigmataElements.SetActive(false);
        BoatElements.SetActive(false);
        CrewMembersElements.SetActive(false);
        LevelUPElements.SetActive(true);
    }

    public void StigmataButton()
    {
        LevelUPElements.SetActive(false);
        BoatElements.SetActive(false);
        CrewMembersElements.SetActive(false);
        StigmataElements.SetActive(true);
    }
    
    public void BoatButton()
    {
        LevelUPElements.SetActive(false);
        StigmataElements.SetActive(false);
        CrewMembersElements.SetActive(false);
        BoatElements.SetActive(true);
    }
    
    public void CrewMembersButton()
    {
        LevelUPElements.SetActive(false);
        StigmataElements.SetActive(false);
        BoatElements.SetActive(false);
        CrewMembersElements.SetActive(true);
    }
}
