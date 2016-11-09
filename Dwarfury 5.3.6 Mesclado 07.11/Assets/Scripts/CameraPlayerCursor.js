 #pragma strict
 
 var Parent : Transform; // Whatever you want to camera locked to
 var Obj : Transform; // The object to place the camera on
 var Radius = 4.5;
 var Dist : float;
 var MousePos1 : Vector3;
 var MousePos2 : Vector3;
 var ScreenMouse : Vector3;
 var MouseOffset : Vector3;
  
 function Update() {
     MousePos1 = Input.mousePosition;
     ScreenMouse = GetComponent.<Camera>().main.ScreenToWorldPoint(Vector3(MousePos1.x, MousePos1.y, Obj.position.z-GetComponent.<Camera>().main.transform.position.z));
     MouseOffset = ScreenMouse - Parent.position;
 
     MousePos2 = Camera.main.ScreenToWorldPoint(Vector3(Input.mousePosition.x, Input.mousePosition.y, -transform.position.z));
     Obj.position.y = ((MousePos2.y - Parent.position.y)/2.0)+Parent.position.y;
     Obj.position.x = ((MousePos2.x - Parent.position.x)/2.0)+Parent.position.x;
      
     Dist = Vector2.Distance(Vector2(Obj.position.x, Obj.position.y), Vector2(Parent.position.x, Parent.position.y));
      
     if(Dist > Radius){
         var norm = MouseOffset.normalized;
         Obj.position.x = norm.x*Radius + Parent.position.x;
         Obj.position.y = norm.y*Radius + Parent.position.y;
     }
 }