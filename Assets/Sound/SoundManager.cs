using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonMonoBehaviourFast<SoundManager> {



	List<string> seCueNameList = new List<string> ();
	List<string> bgmCueNameList = new List<string> ();

	CriAtomSource seAtomSource;
	CriAtomSource bgmAtomSource;

	CriAtomExPlayerOutputAnalyzer analyzer;


	// Use this for initialization
	void Start () {
		
		var criAtom = new GameObject("CRIAtom");
		criAtom.AddComponent<CriAtom>();

		CriAtom.AddCueSheet("CueSheet_0","CueSheet_0.acb","");

		seAtomSource = gameObject.AddComponent<CriAtomSource> ();
		bgmAtomSource = gameObject.AddComponent<CriAtomSource> ();

		// 種別にSpectrumAnalyzerを指定
		CriAtomExPlayerOutputAnalyzer.Type[] type = new CriAtomExPlayerOutputAnalyzer.Type[1];
		//type[0] = CriAtomExPlayerOutputAnalyzer.Type.SpectrumAnalyzer;
		type[0] = CriAtomExPlayerOutputAnalyzer.Type.LevelMeter;

		// コンフィグでバンド数を指定
		//CriAtomExPlayerOutputAnalyzer.Config[] config = new CriAtomExPlayerOutputAnalyzer.Config[1];
		//config[0] = new CriAtomExPlayerOutputAnalyzer.Config(8);

		analyzer = new CriAtomExPlayerOutputAnalyzer (type, null);//config);

		bgmAtomSource.AttachToAnalyzer (analyzer);
	}

	void Update()
	{
		
	}

	void OnDestroy()
	{
		bgmAtomSource.DetachFromAnalyzer (analyzer);
	}

	//#if UNITY_EDITOR

	float rms = 0;
	void OnGUI()
	{

		if (GUILayout.Button ("BachIntro")) {

			bgmAtomSource.Play ("BachIntro");
		}
		if (GUILayout.Button ("gymnopedieIntro")) {

			bgmAtomSource.Play ("gymnopedieIntro");
		}
		if (GUILayout.Button ("kiraIntro")) {

			bgmAtomSource.Play ("kiraIntro");
		}

		if (GUILayout.Button ("Analyze")) {

			//	失敗する？
			float[] levels = new float[8];
			analyzer.GetSpectrumLevels (ref levels);
			float db = 20.0f * Mathf.Log10(levels[0]);
			Debug.Log (db);
		}


		if (GUILayout.Button ("AnalyzeRMS")) {
			rms = analyzer.GetRms (0);
			Debug.Log("Player Level " + rms.ToString());
		}
		GUILayout.Label (rms.ToString());

	}
	//#endif
}
