using UnityEngine;
public class click : MonoBehaviour
{
    private Renderer _rend;
    private Transform transform;
    int cpt;
    float x ;
    float y ;
    int shitty;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rend = GetComponent<Renderer>();
        transform = GetComponent<Transform>();
        x=transform.position[0];
        y = transform.position[1];
        cpt=0;

    }//

    // Update is called once per frame
    void Update()
    {
        
        transform.position=new Vector3((float)x,y,transform.position[2]);
        
        x+= (float)0.05;
        
        
        y+=(Mathf.Sin(x)/20) ;
        
        
        if(x>9){
            x=-9;
            y = Random.Range(-3.0f, 5.0f);
        }

        shitty += 1;

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
