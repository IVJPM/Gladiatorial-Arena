using UnityEngine;

public class ConditionActivation : MonoBehaviour, IConditionObject
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RunCondition()
    {
        print(gameObject.transform.name);
    }
}
