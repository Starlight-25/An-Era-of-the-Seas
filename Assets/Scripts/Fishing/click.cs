using UnityEngine;

public class click : MonoBehaviour
{
    private Renderer _rend;
    private Transform transform;
    int cpt;
    float i ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rend = GetComponent<Renderer>();
        transform = GetComponent<Transform>();
        i=transform.position[0];
        cpt=0;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position=new Vector3((float)i,transform.position[1],transform.position[2]);
        i=i + (float)0.005;
        if(i>9){
            i=-9;
        }
    
    }
    void OnMouseDown(){
        Debug.Log("Click!!!");
        if (cpt == 0)
        {_rend.material.color = Color.red ;
        cpt++;}
        else{
            _rend.material.color = Color.blue;
            cpt=0;
        }

    }
}
