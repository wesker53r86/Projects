using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityMain._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
	[RequireComponent(typeof(CustomControls))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
		private CustomControls something;
        private bool m_Jump;


        private void Awake()
        {
			/*m_Character*/something = GetComponent<CustomControls> ();//GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
			something.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
