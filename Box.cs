using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject player;
    public PlayerController playerController;
    public GameObject self;
    void Update()
    {
        if (player.transform.position.x >= self.transform.position.x - 3 &&
            player.transform.position.x <= self.transform.position.x + 3 &&
            player.transform.position.y >= self.transform.position.y - 3 &&
            player.transform.position.y <= self.transform.position.y + 3)
        {
            if(Input.GetButtonDown("Interact"))
            {
                playerController.collectBox();
                Destroy(self);
            }
        }
    }
}
