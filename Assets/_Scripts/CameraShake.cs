using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;
	
	// How long the object should shake for.
	public float shakeDuration = 6f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.1f;
	public float decreaseFactor = 1.0f;

	//public GameObject quake;
	
	Vector3 originalPos;
	
	// On awake, turns off script and sets Transform
	void Awake()
	{
		gameObject.GetComponent<CameraShake>().enabled = false;
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}
	
	// On start, gets Transform position and enables the shake
	void Start()
	{
		originalPos = camTransform.localPosition;
	}

	// Every frame, causes "camera shake" by quickly moving GameObject
	void Update()
	{
		// Camera shake
		if (shakeDuration > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			
			shakeDuration -= Time.deltaTime * decreaseFactor;
			shakeAmount += 0.002f;
		}
		// No camera shake
		else
		{
			shakeDuration = 0f;
			camTransform.localPosition = originalPos;
			gameObject.GetComponent<CameraShake>().enabled = false;
			//quake.GetComponent<Quake>().enabled = false;
		}
	}
}