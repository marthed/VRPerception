using UnityEngine;
using System.Collections;

public class MedaiPlayerSampleSphereGUI : MonoBehaviour {
	
	public MediaPlayerCtrl scrMedia;
	private PlayButton playButton;


	// Use this for initialization
	void Start () {

		scrMedia.Load ("Vienna.mp4");
		Vector3 vector = new Vector3 (0.05f, 0, 2);
		playButton = gameObject.AddComponent<PlayButton>(  ) as PlayButton;
        playButton.LoadShit(vector, scrMedia);

	}
	
	// Update is called once per frame
	void Update () {


		playButton.CheckHeadPose ();
		
		foreach(Touch touch in Input.touches)
		{
			transform.localEulerAngles = new Vector3(
				transform.localEulerAngles.x, transform.localEulerAngles.y + touch.deltaPosition.x, transform.localEulerAngles.z);
		}
	
	}

	#if !UNITY_WEBGL

	/*void OnGUI() {


        if( GUI.Button(new Rect(50,50,200,200),"Load"))
		{
            Debug.Log("Load button pressed");
            scrMedia.Load("Vienna.mp4");
            //Handheld.PlayFullScreenMovie("EasyMovieTexture.mp4");
            
		}
		
		if( GUI.Button(new Rect(50,300,200,200),"Play"))
		{
			scrMedia.Play();
		}

        /*if( GUI.Button(new Rect(50,550,200,200),"stop"))
		{
			scrMedia.Stop();
		}
		
		if( GUI.Button(new Rect(50,800,200,200),"pause"))
		{
			scrMedia.Pause();
		}
		
		if( GUI.Button(new Rect(50,1050,200,200),"Unload"))
		{
			scrMedia.UnLoad();
		}


	}*/
#endif
    }
