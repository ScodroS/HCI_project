using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	public class SteeringWheelInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
	{
		public enum AxisOption
		{
			OnlyHorizontal, // Only horizontal
		}

		public int MovementRange = 100;
		public string horizontalAxisName = "Horizontal"; // The name given to the horizontal axis for the cross platform input

		Vector3 m_StartPos;
		CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis; // Reference to the joystick in the cross platform input

		void OnEnable()
		{
			CreateVirtualAxes();
		}

        void Start()
        {
            m_StartPos = transform.position;
        }

		void UpdateVirtualAxes(Vector3 value)
		{
			var delta = m_StartPos - value;
			delta.y = -delta.y;
			delta /= MovementRange;
			m_HorizontalVirtualAxis.Update(-delta.x);
		}

		void CreateVirtualAxes()
		{
            m_HorizontalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(horizontalAxisName);
            CrossPlatformInputManager.RegisterVirtualAxis(m_HorizontalVirtualAxis);
		}


		public void OnDrag(PointerEventData data)
		{
			Vector3 newPos = Vector3.zero;

            int delta = (int)(data.position.x - m_StartPos.x);
            delta = Mathf.Clamp(delta, - MovementRange, MovementRange);
            newPos.x = delta;

			UpdateVirtualAxes(new Vector3(m_StartPos.x + newPos.x, m_StartPos.y + newPos.y, m_StartPos.z + newPos.z));
		}


		public void OnPointerUp(PointerEventData data)
		{
			transform.position = m_StartPos;
			UpdateVirtualAxes(m_StartPos);
		}


		public void OnPointerDown(PointerEventData data) { }

		void OnDisable()
		{
			// remove the joysticks from the cross platform input
			m_HorizontalVirtualAxis.Remove();
		}
	}
}