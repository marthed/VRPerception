using UnityEngine;
using System.Collections;

public class PlayButton: MonoBehaviour {

	public float targetTime = 5.0f;
	public bool runPlay = false;
	public bool trueHeadPose = false;
	public GameObject prefabTC;
	public MediaPlayerCtrl scrMedia;
    Material matRed;
    Material matGreen;

	public PlayButton () {
		
	}


        public void LoadShit(Vector3 vector, MediaPlayerCtrl ScrMedia) {
        prefabTC = GameObject.CreatePrimitive(PrimitiveType.Cube);
        prefabTC.transform.position = vector;
        prefabTC.transform.localScale = new Vector3(0.2F,0.2F,0.2F);

        matRed = (Material)Resources.Load("/Assets/Materials/playCube.mat");
        matGreen = (Material)Resources.Load("/Assets/Materials/playCube.mat");

        prefabTC.GetComponent<Renderer>().material = matRed;
       
	    scrMedia = ScrMedia;

	    Debug.Log ("contruct playbutton");
            
        }
	

	public void CheckHeadPose() {


		Vector3 headPose = GvrViewer.Instance.HeadPose.Orientation.eulerAngles;

		//om headPose är inom ett visst områder runt (0,0,0)
		if (headPose.magnitude < 100) {
			Debug.Log ("trueHeadPose");
			trueHeadPose = true;
			targetTime -= Time.deltaTime;
			//gör kub grön
			prefabTC.GetComponent<Renderer>().material = matGreen;
		} else {
			Debug.Log ("falseHeadPose");
			trueHeadPose = false;
			//reset nedräkning
			targetTime = 5.0f;
			//gör kub röd   
			prefabTC.GetComponent<Renderer>().material = matRed;
		}

		if (targetTime <= 0.0f && !runPlay && trueHeadPose)
		{
			timerEnded();
			runPlay = true;
		}

	}

	void timerEnded()
	{
		Debug.Log ("done");
		//kör play-funktionen eller hoppa till ny scen
		scrMedia.Play();
		Vector3 vector = new Vector3 (0, 0, 2000);
		prefabTC.transform.position = vector;

	}


}