using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform pt;
    public GameObject Player;
    public Vector3 Offset;

    void Start()
    {
        pt = pt.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = Player.transform.position + Offset;
    }
}
