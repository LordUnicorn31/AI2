using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject m_Tank;
    public GameObject m_Turret;

    // Update is called once per frame
    void Update()
    {
        if (m_Tank == null)
        {

        }

        else
        {
            if (m_Tank.tag == "Wander")
            {
                m_Turret.transform.LookAt(GameObject.FindGameObjectWithTag("Patrol").transform);
            }
            else if (m_Tank.tag == "Patrol")
            {
                m_Turret.transform.LookAt(GameObject.FindGameObjectWithTag("Wander").transform);
            }
        }


    }
}
