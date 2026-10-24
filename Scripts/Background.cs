using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed1;
    public float speed2;
    public float speed3;
    public GameObject background1;
    public GameObject background2;
    public GameObject background3;
    void Update()
    {
        background1.transform.Translate(Input.GetAxis("Horizontal") * speed1 * Time.deltaTime, 0, 0);
        background2.transform.Translate(Input.GetAxis("Horizontal") * speed2 * Time.deltaTime, 0, 0);
        background3.transform.Translate(Input.GetAxis("Horizontal") * speed3 * Time.deltaTime, 0, 0);
    }
}
