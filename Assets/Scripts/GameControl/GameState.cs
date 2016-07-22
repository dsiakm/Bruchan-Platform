using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class GameState : MonoBehaviour {

	public static GameState gameState;

	List<string> weaponsAllList;
	List<string> weaponsUnlockedList;
	List<string> spellsAllList;
	List<string> spellsUnlockedList;
	List<string> itemsAllList;
	List<string> itemsUnlockedList;

	void Awake () {
		if (gameState == null) {
			DontDestroyOnLoad (gameObject);	
			gameState = this;
		}else if (gameState != this){
			Destroy (gameObject);
		}

		SetAllWeapons ();
		SetAllSpells ();
		SetAllItems ();
	}

	public void Save(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/GameState.dat");

		GameStateData gsd = new GameStateData ();

		gsd.weaponsUnlockedList = weaponsUnlockedList;
		gsd.spellsUnlockedList = spellsUnlockedList;
		gsd.itemsUnlockedList = itemsUnlockedList;

		bf.Serialize (file,gsd);
		file.Close ();
	}

	public void Load(){
		if (File.Exists(Application.persistentDataPath + "/GameState.dat")){
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/GameState.dat", FileMode.Open);
			GameStateData gsd = bf.Deserialize (file) as GameStateData;
			file.Close ();

			weaponsUnlockedList = gsd.weaponsUnlockedList;
			spellsUnlockedList = gsd.spellsUnlockedList;
			itemsUnlockedList = gsd.itemsUnlockedList;
		}
	}

	[Serializable]
	//The game state Data contains all the fields that will be persisted.
	class GameStateData{
		public List<string> weaponsUnlockedList;
		public List<string> spellsUnlockedList;
		public List<string> itemsUnlockedList;
	}

	//Add here all weapons available in the game
	void SetAllWeapons(){
		weaponsAllList = new List<string> ();
		weaponsUnlockedList = new List<string> ();

		weaponsAllList.Add ("basicWeapon");
	}

	//Add here all spells available in the game
	void SetAllSpells(){
		spellsAllList = new List<string> ();
		spellsUnlockedList = new List<string> ();

		spellsAllList.Add ("basicSpell");
	}

	//Add here all items available in the game
	void SetAllItems(){
		itemsAllList = new List<string> ();
		itemsUnlockedList = new List<string> ();

		itemsAllList.Add ("basicItem");
	}

	public void AddWeapon(String weaponName){
		weaponsUnlockedList.Add (weaponName);
	}
	public void AddSpell(String spellName){
		weaponsUnlockedList.Add (spellName);
	}
	public void AddItem(String itemName){
		weaponsUnlockedList.Add (itemName);
	}
	public string CicleUnlockedWeapons(int side){
		int index = weaponsUnlockedList.IndexOf(PlayerState.playerState.GetActiveWeapon())+side;
		if (index < 0){
			index = weaponsUnlockedList.Count - 1;
		}else if (index > weaponsUnlockedList.Count - 1){
			index = 0;
		}
		return weaponsUnlockedList[index];
	}
	public string CicleUnlockedSpells(int side){
		int index = spellsUnlockedList.IndexOf (PlayerState.playerState.GetActiveSpell())+side;
		if (index < 0){
			index = spellsUnlockedList.Count - 1;
		}else if (index > spellsUnlockedList.Count - 1){
			index = 0;
		}
		return spellsUnlockedList[index];
	}
	public string CicleUnlockedItems(int side){
		int index = itemsUnlockedList.IndexOf (PlayerState.playerState.GetActiveItem())+side;
		if (index < 0){
			index = itemsUnlockedList.Count - 1;
		}else if (index > itemsUnlockedList.Count - 1){
			index = 0;
		}
		return itemsUnlockedList[index];
	}


}
