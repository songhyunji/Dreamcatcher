using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlytrapTrigger : MonoBehaviour
{
    public Flytrap flytrapScript;
    private List<Collider2D> objectList = new List<Collider2D>();

    private void Update()
    {
        if (objectList.Count > 0)
        {
            flytrapScript.canEat = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("In");
        objectList.Add(collision);
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Out");
        objectList.Remove(collision);
        StartCoroutine("CannotEat");
    }

    IEnumerator CannotEat()
    {
        if(objectList.Count==0)
        {
            yield return new WaitForSeconds(0.5f);
            flytrapScript.canEat = true;
        }
    }
}
