using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public float range = 2f;
    public Camera Camera;
    public Transform PlayerTransform;
    public GameObject Player;
    public Transform PlayerChildTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            Shoot();
        }
    }

    void Shoot ()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                StartCoroutine(StartTeleport());
            }
        }
    }

    IEnumerator StartTeleport()
    {
        PlayerChildTransform.DetachChildren();
        Player.transform.SetParent(PlayerTransform);
        PlayerTransform.transform.position = new Vector3(2.221544f, 1f, -4.6f);
        PlayerTransform.DetachChildren();
        yield return new WaitForSeconds(0f);
        PlayerTransform.transform.SetParent(PlayerChildTransform);

    }

}
