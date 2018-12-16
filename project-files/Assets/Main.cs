using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

using System.Collections;

public class Main : MonoBehaviour {

	private float[] speeds = new float[88];

	private GameObject[] objects = new GameObject[88];

	GameObject cube;

	private Camera cam;
	private Vector3 camOffset = new Vector3(0,132.0f,0);

	private float camSpeedX = 0.0f;
	private float camSpeedY = 0.0f;
	private float speedSin = 0.0f;
	private float changeSin = 0.01f;

	private float shaderAmp = 0.03f;
	private float shaderLambda = 1.5f;

	private float timer = 0;

	public Canvas canvas;

	Shader wavy;

	private float[,] coords = new float [,] { {142.2f,-1.14f}, {182.8f,-3.2f}, {187.4f,-3.2f}, {197.3f,-3.9f}, {197.2f,-6.7f}, {71.1f,-1.4f}, {82.2f,-2.5f}, {82.1f,-0.8f}, {85.0f,-1.84f}, {90.0f,-3.9f}, {101.2f,-1.14f}, {113.6f,-1.5f}, {113.3f,-0.4f}, {115.8f,-2.8f}, {120.4f,-1.1f}, {121.2f,-4.6f}, {128.6f,-4.9f}, {150.0f,-2.0f}, {154.8f,-3.9f}, {157.3f,-4.9f}, {185.5f,-1.49f}, {94.0f,-6.0f}, {112.2f,-6.3f} };
	//-4 ... -35

	public AudioMixer output1;

	private Vector3 lastMouse = new Vector2(0,0);


	void Start ()
	{
		
		Application.targetFrameRate = 30;
		
		for (int i = 0; i < 88; i++)
		{
			//Debug.Log(i);

			GameObject currentModel = GameObject.Find("Model (" + i + ")");

			currentModel.transform.position = new Vector3(0,i*1.5f,0);
			currentModel.transform.Rotate(0, 0, 180);

			objects[i] = currentModel;

			wavy = Shader.Find("Custom/Wavy");
			objects[i].transform.GetChild(0).GetComponent<Renderer>().material.shader = wavy;

			GameObject cloneObj = Instantiate(objects[i], new Vector3(0, 132.0f + (i*1.5f), 0), currentModel.transform.rotation);
			cloneObj.transform.parent = objects[i].transform;

			speeds[i] = Random.Range(0.03f, 0.2f);

		}

		cam = GameObject.Find("Camera").GetComponent<Camera>();

		cube = GameObject.Find("Cube");

		cam.clearFlags = CameraClearFlags.SolidColor;

		GameObject.Find("Camera").GetComponent<SoundPlayer>().PlayRnd();


		int rndOutput = Random.Range(0,33);
		if(rndOutput < 23)
		{
			cam.transform.position = new Vector3(0,coords[rndOutput,0],coords[rndOutput,1]);
		}
		else
		{
			cam.transform.position = new Vector3(0, Random.value * 132.0f, (Random.value * -31.0f) - 4.0f);
		}

		Cursor.visible = false;

	}

	void Update ()
	{

		if(lastMouse != Input.mousePosition)
		{
			Cursor.visible = true;
		}
		else
		{
			Cursor.visible = false;
		}
		lastMouse = Input.mousePosition;


		if(Input.anyKey)
		{
			timer += 1;

			if(timer > 18000 && canvas.GetComponent<CanvasGroup>().alpha < 1.0f)
			{
				canvas.GetComponent<CanvasGroup>().alpha += 0.01f;
			}
		}
		else
		{
			timer = 0;

			if(canvas.GetComponent<CanvasGroup>().alpha > 0.0f)
			{
				canvas.GetComponent<CanvasGroup>().alpha = 0.0f;
			}
		}

		if (Input.GetKey("w"))
		{
			camSpeedY = Random.Range(0.0f,0.06f);
		}
		if (Input.GetKey("s"))
		{
			camSpeedY -= 0.02f;
		}

		if (Input.GetKey("a"))
		{
			if(cam.transform.position.z > -35.0f) camSpeedX -= 0.02f;
		}
		if (Input.GetKey("d"))
		{
			if(cam.transform.position.z < -2.0f) camSpeedX += 0.02f;
		}


		if (Input.GetMouseButton(1) || Input.GetMouseButton(0))
		{
			int rndOutput = Random.Range(0,33);
			if(rndOutput < 23)
			{
				cam.transform.position = new Vector3(0,coords[rndOutput,0],coords[rndOutput,1]);
			}
			else
			{
				cam.transform.position = new Vector3(0, Random.value * 132.0f, (Random.value * -31.0f) - 4.0f);
			}

			GameObject.Find("Camera").GetComponent<SoundPlayer>().PlayRnd();

			camSpeedY *= 0.8f;
			camSpeedX *= 0.8f;

			shaderAmp = Random.Range(0.0f,2.0f);
			if(shaderAmp > 0.5) shaderAmp = 0.0f;

			voidToggle();

		}

		if (Input.GetKey("f") || Input.GetKey("g"))
		{

      cube.transform.position = new Vector3(cam.transform.position.x + ((Random.value * 100.0f)-50.0f), cam.transform.position.y + ((Random.value * 100.0f)-50.0f), cam.transform.position.z + 50);
			cube.transform.localScale = new Vector3((Random.value * 15.0f)+15.0f, (Random.value * 15.0f)+15.0f, 1.0f);

			speedSin += changeSin;

			shaderAmp = Random.Range(0.0f,2.0f);
			if(shaderAmp > 0.5) shaderAmp = 0.0f;

			camSpeedY = Random.Range(-0.2f,0.06f);

		}
		if (Input.GetKeyUp("f") || Input.GetKeyUp("g"))
		{
			cube.transform.position = new Vector3(0, 0, cam.transform.position.z - 500);

			voidToggle();
		}

		camSpeedY = Mathf.Clamp(camSpeedY,-0.06f,0.06f);



		cam.transform.Translate(new Vector3(0,camSpeedY,camSpeedX));

		output1.SetFloat("paramPitch", (camSpeedY*20)+1);
		output1.SetFloat("paramReverb", (cam.transform.position.z * -270.0f)-10000.0f);
		output1.SetFloat("paramVol", (cam.transform.position.z * 150.0f)+4000);
		output1.SetFloat("paramMainVol", (cam.transform.position.z * 0.3f));

		shaderLambda = (camSpeedY*20)+1;


		camSpeedY *= 0.9999f;
		camSpeedX *= 0.8f;

		speedSin *= 0.99f;

		if(speedSin > 0.5f)
		{
			speedSin = 0.5f;
			changeSin = -changeSin;
		}
		else if(speedSin < 0.0f)
		{
			speedSin = 0.0f;
			changeSin = -changeSin;
		}

		//Debug.Log(cam.transform.position.y + "____" + cam.transform.position.z);


		for (int i = 0; i < 88; i++)
		{
			//GameObject currentModel = GameObject.Find("Model (" + i + ")");

			objects[i].transform.Rotate(0, objects[i].transform.rotation.y + speeds[i], 0);

			objects[i].transform.position = new Vector3(0,(i*1.5f) + (Mathf.Sin(objects[1].transform.eulerAngles.y/2.0f)*speedSin),0);


			objects[i].transform.GetChild(0).GetComponent<Renderer>().material.SetFloat("_Amplitude", shaderAmp);
			objects[i].transform.GetChild(0).GetComponent<Renderer>().material.SetFloat("_Frequency", shaderLambda);

			if (cam.transform.position.y < 66.5f)
			{
				cam.transform.position += camOffset;
			}
			else if (cam.transform.position.y > 198.5f)
			{
				cam.transform.position -= camOffset;
			}

		}


	}

	private void voidToggle()
	{
		if(cam.clearFlags == CameraClearFlags.Depth)
		{
			cam.clearFlags = CameraClearFlags.SolidColor;
		}
		else
		{
			cam.clearFlags = CameraClearFlags.Depth;
		}
	}
}
