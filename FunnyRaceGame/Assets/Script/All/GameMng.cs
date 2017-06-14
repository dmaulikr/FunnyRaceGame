using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMng : MonoBehaviour {

	GameObject MngObj;

//プレイヤーの選択情報
	public int[] playerStatus;
	/* 0列目:選択キャラクター
	 * 1列目:選択車
	 * 2列目:選択コース */

//シーン管理変数
	public int scene;
	/* 0:予備(スポンサーロゴなど入れるかも)
	 * 1:タイトル
	 * 2:レース準備(キャラクター、車、コース選択)
	 * 3:モノローグ
	 * 4:ゲーム
	 * 5:リザルトかな？ */
	public bool sceneChange = false;


//BGM管理変数
	public AudioClip[] bgm;

	void Awake(){
		MngObj = gameObject;
		if (MngObj != null) {
			DontDestroyOnLoad (gameObject);
		}else{
			Destroy(GameObject.FindWithTag("GameController"));
		}
	}

	void Start () {
		playerStatus = new int[3]{0,0,0};
		gameObject.GetComponent<AudioSource> ().clip = bgm [0];
		scene = 1;
	}
	
	void Update () {
		if (sceneChange == true) {
			SceneChange ();
			sceneChange = false;
		}
	}

	void SceneChange(){
		switch (scene) 
		{
			case 0:
				SceneManager.LoadScene ("");
				gameObject.GetComponent<AudioSource> ().clip = bgm [0];
				break;
			case 1:
				SceneManager.LoadScene ("Title");
				gameObject.GetComponent<AudioSource> ().clip = bgm [0];
				break;
			case 2:
				SceneManager.LoadScene ("PreparationRace");
				gameObject.GetComponent<AudioSource> ().clip = bgm [1];
				break;
			case 3:
				SceneManager.LoadScene ("");
				break;
			case 4:
				SceneManager.LoadScene ("");
				break;
			default:
				break;
		}
	}
}