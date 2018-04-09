using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsController : MonoBehaviour {
	public Text stepText;
	public Text titleText;
	public Text bodyText;
	public RawImage imageGraphic;

	private int currentStep;
	private InstructionModel currentInstructionModel = new InstructionModel ();

	void Awake(){
		currentInstructionModel.LoadData ();
	}

	// Use this for initialization
	void Start () {
		currentStep = 0;
		CurrentInstructionUpdate ();

	}
	public void NextStep(){
		if (currentStep < currentInstructionModel.GetCount () - 1) {
			currentStep++;
			CurrentInstructionUpdate ();
		}
	}
	
	public void PreviousStep(){
		if (currentStep > 0) {
			currentStep--;
			CurrentInstructionUpdate ();
		}
	}
	private void CurrentInstructionUpdate() {

		instructionStep step = currentInstructionModel.GetInstructionStep (currentStep);
		stepText.text = "Step:  " + currentStep;
		titleText.text = step.Title;
		bodyText.text = step.BodyText;
		if(!string.IsNullOrEmpty (step.ImageName)){
			imageGraphic.GetComponent<LayoutElement>().enabled = true;
			imageGraphic.GetComponent<RawImage>().texture = Resources.Load((string)step.ImageName) as Texture;
			print (step.ImageName);
					
		}
		else{
			imageGraphic.GetComponent<LayoutElement>().enabled = false;
			imageGraphic.GetComponent<RawImage>().texture = null;
		}
	}
}
