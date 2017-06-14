using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCtr : MonoBehaviour {

	//メニュー
	GameObject MenuObj;
	//テキスト
	GameObject PushTextObj;
	//フェードマネージャー
	GameObject FadeMngObj;
	//
	GameObject SceneMngObj;

	void Start(){
		//検索
		MenuObj = gameObject.transform.FindChild ("Menu").gameObject;
		PushTextObj = gameObject.transform.FindChild ("PushTextBtn").gameObject;
		FadeMngObj = GameObject.Find ("FadeCanvas").gameObject;
		SceneMngObj = GameObject.Find ("GameSceneManager").gameObject;
		//初期化
		PushTextObj.SetActive(true);
	}



	//スタートボタン
	public void StartBtn(){
		PushTextObj.GetComponent<AudioSource> ().PlayOneShot(PushTextObj.GetComponent<AudioSource>().clip);
		iTween.MoveTo(MenuObj, iTween.Hash("Y", MenuObj.transform.position.y+4.25f,"time",2) );
		PushTextObj.SetActive (false);
	}
	//一人プレイボタン
	public void SoloPlay(GameObject btn){
		FadeMngObj.GetComponent<FadeMng> ().FadeIn = true;
		btn.GetComponent<AudioSource> ().PlayOneShot(btn.GetComponent<AudioSource>().clip);
		SceneMngObj.GetComponent<GameMng> ().scene = 2;

	}
	//オンライン複数人プレイボタン
	public void OnLinePlay(){
		
	}
	//オフライン複数人プレイボタン
	public void OffLinePlay(){
		
	}
	//オプションボタン
	public void OptionBtn(){
		
	}
}
