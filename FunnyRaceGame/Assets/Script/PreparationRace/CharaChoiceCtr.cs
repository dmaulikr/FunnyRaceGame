using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaChoiceCtr : MonoBehaviour {

	//Unityちゃんのパラメーター情報
	string[] unityChan;
	float[] unityChan_p;
	public Sprite unityChanImage;
	//ポニーテールちゃん
	string[] ponyTails;
	float[] ponyTails_p;
	public Sprite ponyChanImage;
	//猫耳ちゃん
	string[] catEar;
	float[] catEar_p;
	public Sprite catChanImage;
	//メガネちゃん
	string[] glasses;
	float[] glasses_p;
	public Sprite glassesChanImage;

	//選択中のキャラクター
	public int charaNo;

	//情報を表示するテキスト
	GameObject nameObj;
	GameObject PrameteObj;
	//パラメーターオブジェクト
	GameObject[] parameterObj;
	//選択したキャラクターの別差分を表示させるオブジェクト
	GameObject charaImageObj;
	//ポップアップ
	GameObject charaPopUpObj;


	void Awake(){
		//情報を記載
		unityChan = new string[2]{ "UnityChan", "今作の主人公。主人公という事もありパラメーターを全て中間設定にしてみた。今作に正式に登場するかは定かではない" };
		unityChan_p = new float[5]{ 0.5f, 0.5f, 0.5f, 0.5f, 0.5f};

		ponyTails = new string[2]{ "PonyChan", "ただのポニーテールの女の子。ポニーテールを装着する事によりとんでもない馬力を手に入れた。今作に正式に登場するかは定かではない" };
		ponyTails_p = new float[5]{1.0f,0.75f,0.5f,0.15f,0.15f};

		catEar = new string[2]{"CatChan","猫耳？を生やしたクーデレーガール（多分）。猫っぽいので機敏なタイプにした。今作に正式に登場するかは定かではない。"};
		catEar_p = new float[5]{0.25f,0.5f,0.1f,1.0f,0.75f};

		glasses = new string[2]{ "Glasses", "メガネをかけている女の子。開発者の好みではないが素材がない為仕方なく導入した。今作に正式に登場は絶対にしない。" };
		glasses_p = new float[5]{0.4f,0.4f,0.6f,0.3f,0.8f};
	}



	void Start () {
		//習得
		nameObj = GameObject.Find("NameText").gameObject;
		PrameteObj = GameObject.Find("DescriptionText").gameObject;
		charaImageObj = GameObject.Find ("CharaImage").gameObject;
		charaPopUpObj = GameObject.Find ("ChoiceFinImage").gameObject;

		parameterObj = new GameObject[5] {
			GameObject.Find("Paramete0").gameObject,
			GameObject.Find("Paramete1").gameObject,
			GameObject.Find("Paramete2").gameObject,
			GameObject.Find("Paramete3").gameObject,
			GameObject.Find("Paramete4").gameObject
			};

		//初期化
		charaNo = 0;

		//シーンが切り替わった処理
		GameObject.Find("FadeCanvas").GetComponent<FadeMng>().FadeOut = true;
		GameObject.Find ("GameSceneManager").GetComponent<AudioSource> ().Play ();
	}




	void Update () {}




	//キャラクター選択のボタン
	public void CharacterChoiceBtn(GameObject chara){
		GameObject parent = chara.transform.parent.gameObject;
		charaNo = int.Parse(parent.name);

		switch (charaNo) {
		//ユニティちゃん
		case 0:
			charaImageObj.GetComponent<Image> ().sprite = unityChanImage;
			nameObj.GetComponent<Text> ().text = unityChan [0].ToString ();
			PrameteObj.GetComponent<Text> ().text = unityChan [1].ToString ();
			for (int i = 0; i < 5; i++) {
				parameterObj [i].transform.FindChild ("Slider").GetComponent<Slider> ().value = unityChan_p [i];
			}
			iTween.MoveTo (charaPopUpObj, iTween.Hash (
				"y", 	 -5f,
				"time",  2.0f
			));
			break;
		//ポニーテールちゃん
		case 1:
			charaImageObj.GetComponent<Image> ().sprite = ponyChanImage;
			nameObj.GetComponent<Text> ().text = ponyTails [0].ToString ();
			PrameteObj.GetComponent<Text> ().text = ponyTails [1].ToString ();
			for (int i = 0; i < 5; i++) {
				parameterObj [i].transform.FindChild ("Slider").GetComponent<Slider> ().value = ponyTails_p [i];
			}
			iTween.MoveTo (charaPopUpObj, iTween.Hash (
				"y", 	 -5f,
				"time",  2.0f
			));
			break;
		//猫耳ちゃん
		case 2:
			charaImageObj.GetComponent<Image> ().sprite = catChanImage;
			nameObj.GetComponent<Text> ().text = catEar [0].ToString ();
			PrameteObj.GetComponent<Text> ().text = catEar [1].ToString ();
			for (int i = 0; i < 5; i++) {
				parameterObj [i].transform.FindChild ("Slider").GetComponent<Slider> ().value = catEar_p [i];
			}
			iTween.MoveTo (charaPopUpObj, iTween.Hash (
				"y", 	 -5f,
				"time",  2.0f
			));
			break;
		//メガネババァ
		case 3:
			charaImageObj.GetComponent<Image> ().sprite = glassesChanImage;
			nameObj.GetComponent<Text> ().text = glasses [0].ToString ();
			PrameteObj.GetComponent<Text> ().text = glasses [1].ToString ();
			for (int i = 0; i < 5; i++) {
				parameterObj [i].transform.FindChild ("Slider").GetComponent<Slider> ().value = glasses_p [i];
			}
			iTween.MoveTo (charaPopUpObj, iTween.Hash (
				"y", 	 -5f,
				"time",  2.0f
			));
			break;
		//エラー処理
		default:
			nameObj.GetComponent<Text> ().text = "エラー".ToString ();
			PrameteObj.GetComponent<Text> ().text = "参照に失敗致しました。".ToString ();
			for (int i = 0; i < 5; i++) {
				parameterObj [i].transform.FindChild ("Slider").GetComponent<Slider> ().value = 0.0f;
			}
			iTween.MoveTo (charaPopUpObj, iTween.Hash (
				"y", 	 -5f,
				"time",  2.0f
			));
			break;	
		}
	}

	public void CancelBtn(){
		iTween.MoveTo (charaPopUpObj, iTween.Hash (
			"y", 	 -150f,
			"time",  2.0f
		));
	}
}
