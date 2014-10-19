// JavaScript

var sliderValue = 1.0;
var maxSliderValue = 10.0;
var buttonHeight = 40;
var buttonCounter = 1;
function OnGUI () {


    // Make a background box
    GUI.Box (Rect (Screen.width - 100,10,100,90), "Main Menu");

	
	var mainButton = GUI.RepeatButton (Rect (Screen.width - 100,buttonHeight,80,20), "Button" + buttonCounter);
	
	if(mainButton){
		buttonHeight += 30;
    	buttonCounter++;
    	Debug.Log(buttonHeight + " - " + buttonCounter);
    	
    	GUI.Button (Rect (Screen.width - 100,buttonHeight,80,20), "Button " + buttonCounter);
	
	}
	
	
	
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    

    /*// Make the second button.
    if (GUI.Button (Rect (20,70,80,20), "Button 2")) {
    	Debug.Log("TEST 2");
       // Application.LoadLevel (2);
    }*/
    
    
    
    // Wrap everything in the designated GUI Area
        GUILayout.BeginArea (new Rect (0,0,200,60));
    
        // Begin the singular Horizontal Group
        GUILayout.BeginHorizontal();
    
        // Place a Button normally
        if (GUILayout.RepeatButton ("Increase max\nSlider Value"))
        {
            maxSliderValue += 3.0f * Time.deltaTime;
        }
    
        // Arrange two more Controls vertically beside the Button
        GUILayout.BeginVertical();
        GUILayout.Box("Slider Value: " + Mathf.Round(sliderValue));
        sliderValue = GUILayout.HorizontalSlider (sliderValue, 0.0f, maxSliderValue);
    
        // End the Groups and Area
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
}
