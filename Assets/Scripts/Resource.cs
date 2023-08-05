using UnityEngine;


public class Resource : MonoBehaviour
{
    [SerializeField]
    private int level;
    [SerializeField]
    private string name;
    private string description;

    // Start is called before the first frame update
    void Start()
    {
        this.level = 0;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetProperties()
    {

    }
}
