using UnityEngine;
using System.Collections;

public class OpenUrl : MonoBehaviour {
	public string URL;
	public string AndroidURL;
	public string IPhoneURL;
	public void OpenFacebook(){
		if (Application.platform == RuntimePlatform.Android) {
			Application.OpenURL (AndroidURL);
		} else if (Application.platform == RuntimePlatform.IPhonePlayer) {
			Application.OpenURL (IPhoneURL);
		} else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor) {
			Application.OpenURL (URL);
		}
	}
}
