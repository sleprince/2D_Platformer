using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl_2UP : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character2;
        private bool m_Jump;


        private void Awake()
        {
            m_Character2 = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("P2 Fire1");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = (Input.GetKey(KeyCode.O) || Input.GetKey(KeyCode.Joystick2Button1));
            bool superjump = (CrossPlatformInputManager.GetButtonDown("P2 Fire1") && (Input.GetKey(KeyCode.O) || Input.GetKey(KeyCode.Joystick2Button1)));
            float h = CrossPlatformInputManager.GetAxis("P2 Horizontal");
            // Pass all parameters to the character control script.
            m_Character2.Move(h, crouch, m_Jump, superjump);
            m_Jump = false;
        }
    }
}
