using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetLeader : MonoBehaviour
{
    [Header("LeaderVariabes")]
    public float Speed;

    [Space(10)]

    [Header("Lists")]
    public List<GameObject> ships = new List<GameObject>();
    public List<Vector3> shipPositions = new List<Vector3>();

    [Space(10)]

    [Header("Debug Variables")]
    public bool debug;
    public float debugPosRadius;
    public Color debugPosColor;
    // Use this for initialization
    void Start()
    {
	}
    
    void Move()
    {
        transform.Translate(Vector3.forward * Speed * Time.fixedDeltaTime, Space.World);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Move();
	}
    void OnDrawGizmos()
    {
        if (debug)
        {
            foreach (Vector3 pos in shipPositions)
            {
                Gizmos.color = new Color(debugPosColor.r, debugPosColor.g, debugPosColor.b, debugPosColor.a);
                Gizmos.DrawSphere(pos, debugPosRadius);
            }
        }
    }

}
