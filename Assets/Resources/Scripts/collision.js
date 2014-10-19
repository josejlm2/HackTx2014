function OnCollisionEnter(theCollision : Collision){
 if(theCollision.gameObject.name == "RiggedRightHand" || theCollision.gameObject.name == "RiggedLeftHand" ){
  Debug.Log("Hit the floor");
 }else if(theCollision.gameObject.name == "greenCube"){
  Debug.Log("Hit the wall");
 }
}