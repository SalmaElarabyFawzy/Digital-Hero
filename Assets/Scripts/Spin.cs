using UnityEngine;

public class Spin : MonoBehaviour
{
    public int speed = 10;

    
    private void Update()
    {
       gameObject.transform.Rotate(Vector3.up * speed * Time.deltaTime); 
    }
}
