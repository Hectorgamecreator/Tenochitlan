using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HectorRodriguez
{
    public class CameraController : MonoBehaviour
    {

		public Transform target;
		public float smoothing = 5f;
		Vector3 offset;

		// Use this for initialization
		void Start()
		{
			offset = transform.position - target.position;
		}

		// Update is called once per frame
		void LateUpdate()
		{
			Vector3 targetCamPos = target.position + offset;
			transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
		}
	}

}