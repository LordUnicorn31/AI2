using System;
using UnityEngine;
using UnityEngine.UI;

namespace Complete
{
    public class Shooting : MonoBehaviour
    {
        public int m_PlayerNumber = 1;              // Used to identify the different players.
        public Rigidbody m_Shell;                   // Prefab of the shell.
        public Transform m_FireTransform;           // A child of the tank where the shells are spawned.
        public AudioSource m_ShootingAudio;         // Reference to the audio source used to play the shooting audio. NB: different to the movement audio source.
        public AudioClip m_FireClip;                // Audio that plays when each shot is fired.


        public GameObject target;
        public Transform tankTransform;
        public float launchForce = 20.0f;
        public float maxAngle = 60.0f;
        public float minAngle = 0.0f;
        public float m_Shooting_Cooldown = 5.0f;
        public float m_Shooting_Cooldown_Current = 0.0f;
        public float shootAngle = 0.0f;
        public float shootRadius = 0.0f;


        public bool shoot = false;


        private string m_fireButton;
        private bool m_fired;

        private void OnEnable()
        {
            shootRadius = GetMaxRange();
        }


        private void Start()
        {
            // The fire axis is based on the player number.
            m_fireButton = "Fire" + m_PlayerNumber;

        }

        // Student added
        private void Update()
        {

            if (m_fired)
            {
                m_Shooting_Cooldown_Current += Time.deltaTime;

                if (m_Shooting_Cooldown_Current >= m_Shooting_Cooldown)
                {
                    m_fired = false;
                    m_Shooting_Cooldown_Current = 0.0f;
                    m_Shooting_Cooldown = 3.0f;

                }
            }


            if (!m_fired)
            {
                GetAngle();

                if (shoot)
                {
                    Fire();
                }
            }

        }

        // Get maximum radius range
        private float GetMaxRange()
        {
            float g = Physics.gravity.y;
            float p = launchForce;
            float m = 45.0f;

            float Max_Shooting_Range = ((p * p) * Mathf.Sin(2 * m)) / g;

            Max_Shooting_Range = Mathf.Abs(Max_Shooting_Range);

            Debug.Log(Max_Shooting_Range);

            return Max_Shooting_Range;
        }


        private void GetAngle()
        {
            float Distance = Vector3.Distance(m_FireTransform.position, tankTransform.position);

            if (Distance < shootRadius)
            {

                float g = Physics.gravity.y;
                float v = launchForce;
                float x = Distance;



                float x2 = x * x;
                float v2 = v * v;
                float v4 = v2 * v2;

                float tan = (v2 - Mathf.Sqrt(v4 - g * (g * x2))) / (g * x);
                float rad_angle = Mathf.Atan(tan);


                float ret;

                float posibleAngle = Math.Abs((float)rad_angle * Mathf.Rad2Deg);

                if ((posibleAngle > minAngle && posibleAngle < maxAngle))
                {
                    ret = posibleAngle;
                }

                shootAngle = posibleAngle;

                if (shootAngle > 0.0f)
                {
                    shoot = true;
                }
            }

        }


        private void Fire()
        {

            shoot = false;
            m_fired = true;

            m_FireTransform.Rotate(-shootAngle, 0.0f, 0.0f);

            Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
            shellInstance.velocity = launchForce * m_FireTransform.forward;

            m_ShootingAudio.clip = m_FireClip;
            m_ShootingAudio.Play();

        }
    }
}