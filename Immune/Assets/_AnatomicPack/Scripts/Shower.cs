using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shower : MonoBehaviour {

	public Text Description;
	public List<GameObject> list;
	public int index = 0;
	public GameObject OpenedObject;
	public Text ObjectName;
	
	public void Start(){
		Open(index);
	}

	public void Open(int i){
		if(OpenedObject != null){
			OpenedObject.SetActive(false);
		}
		index = i;
		OpenedObject = list[index];
		OpenedObject.SetActive(true);
		ObjectName.text = OpenedObject.name;
		updateDescription ();
	}

	public void Previous(){
		if(index > 0){
			Open (index-1);
		}
		else{
			Open (list.Count-1);
		}
	}

	public void Next(){
		Open((index+1)%list.Count);
	}

	public void updateDescription () {
		if (OpenedObject.name.Contains ("Platelet")) {
			Description.text = "Primary function: Stop bleedings by clumping and clotting blood vessels.\n\nDescription: " +
				"Platelets are a component of blood and do not have a nucleus. They are about 1/5 of the size of red blood cells.";
		} else if (OpenedObject.name.Contains ("Macrophage")) {
			Description.text = "Primary function: Eat foreign entities (a process called Phagocytosis) such as bacteria, viruses, cancer cells and many more." +
				"\n\nDescription: Macrophages are a type of white blood cells and usually the first line of defense against infections.";
		} else if (OpenedObject.name.Contains ("Helper")) {
			Description.text = "Primary function: Identify intruders to activate other immune cells such as killer T cells. However, they need help " +
				"of other cells.(Macrophages)\n\nDescription: Helper T-Cells play an important role in our immune system. " +
				"As an example, HIV mainly targets Helper T-Cells.";
		} else if (OpenedObject.name.Contains ("Killer")) {
			Description.text = "Primary function: Destroy identified foreign cells. They need to be activated by Helper T-Cells first." +
				"\n\nDescription: Millions of Killer T-Cells are present in your body but very few are active. " +
				"They must be sought by Helper T-Cells before interacting with infected cells.";
		}
	}
}
