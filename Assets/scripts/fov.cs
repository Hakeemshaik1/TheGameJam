using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fov : MonoBehaviour
{
    public float radius = 5;
    [Range(1, 360)] public float angle = 45f;
    public LayerMask targetplayer;
    public LayerMask obstruction;

    public GameObject playerref;
    public bool canseeplayer { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        playerref = GameObject.FindGameObjectWithTag("player");
        StartCoroutine(FOVCheck());
    }

    private IEnumerator FOVCheck()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (true)
        {
            yield return wait;
            FOV();
        }
    }
    private void FOV()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetplayer);
        if (rangeCheck.Length > 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector2 directiontotarget = (transform.position - target.position).normalized;

            if (Vector2.Angle(transform.up, directiontotarget) < angle / 2)
            {
                float distancetotarget = Vector2.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, directiontotarget, distancetotarget, obstruction))

                    canseeplayer = true;
                else
                    canseeplayer = false;

            }
            else
                canseeplayer = false;
        }
        else if (canseeplayer)
            canseeplayer = false;

    }

    // Update is called once per frame
    void Update()
    {

    }


}



