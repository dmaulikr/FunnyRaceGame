using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeMng : MonoBehaviour {

	//フェードする画像
	GameObject FadeObj;
	//ナウローディングテキスト
	GameObject TextObj;
	//
	GameObject gameSceneMngObj;

	//フェード開始フラグ
	public bool FadeIn;
	public bool FadeOut;


	GameObject Fade;


	void Awake(){
		//オブジェクトを検索し定義
		FadeObj = gameObject.transform.FindChild ("FadeImage").gameObject;
		TextObj = gameObject.transform.FindChild ("NowLoadingText").gameObject;
		gameSceneMngObj = GameObject.Find ("GameSceneManager").gameObject;
		FadeObj.GetComponent<Image> ().fillAmount = 1;
		TextObj.SetActive (true);
		FadeObj.SetActive (true);

		Fade = gameObject;
		if (Fade != null) {
			DontDestroyOnLoad (gameObject);
		}else{
			Destroy(GameObject.FindWithTag("GameController"));
		}
	}

	void Start () {
		//初期化
		FadeIn = false;
		FadeOut = true;
	}
	
	void Update () {
		//フェードイン
		if (FadeIn == true) {
			FadeObj.SetActive (true);
			FadeInStart ();
		}
		//フェードアウト
		if (FadeOut == true) {
			TextObj.SetActive (false);
			FadeOutStart ();
		}
	}


	void FadeInStart(){
		if (FadeObj.GetComponent<Image> ().fillAmount < 1) {
			FadeObj.GetComponent<Image> ().fillAmount += 0.05f;
		}
		else {
			FadeObj.GetComponent<Image> ().fillAmount = 1;
			TextObj.SetActive (true);
			FadeIn = false;
			gameSceneMngObj.GetComponent<GameMng> ().sceneChange = true;
		}
	}

	void FadeOutStart(){
		if (FadeObj.GetComponent<Image> ().fillAmount > 0) {
			FadeObj.GetComponent<Image> ().fillAmount -= 0.05f;
		} 
		else {
			FadeObj.GetComponent<Image> ().fillAmount = 0;
			FadeOut = false;
			FadeObj.SetActive (false);
		}
	}
}
