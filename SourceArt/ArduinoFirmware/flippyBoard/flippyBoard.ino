/* Flippy Board
 * Global Game Jam 2017
 */
 
// Characters to send over serial to cause different button flash actions
 const int MODE_ATTRACT = 0;  // A
 const int MODE_OFF     = 1;  // 0
 const int MODE_ON      = 2;  // 1
 const int MODE_DIE     = 3;  // X
 const int MODE_WIN     = 4;  // W
 
 int led = 9;
 int brightness = 0;
 int fadeAmount = 5;
 int mode = MODE_ATTRACT;
 int dieStage = 0;
 
 void attractMode() {
   fadeAmount = 5;
   brightness = 0;
   mode = MODE_ATTRACT;
 }
 
 void offMode() {
   fadeAmount = 0;
   brightness = 0;
   mode = MODE_OFF;
 }
 
 void onMode() {
   fadeAmount = 0;
   brightness = 255;
   mode = MODE_ON;
 }
 
 void dieMode() {
   brightness = 255;
   fadeAmount = 25;
   dieStage = 0;
   mode = MODE_DIE;
 }
 
 void winMode() {
   mode = MODE_WIN;
 }
 
 void fade() {
   analogWrite(led, brightness);
   brightness = brightness + fadeAmount;
   if(brightness <= 0 || brightness >= 255) {
    fadeAmount = -fadeAmount; 
   }
 }
 
 void die() {
   if(dieStage == 0) {
     analogWrite(led, brightness);
     brightness -= fadeAmount;
     if (brightness <= 0) {
      dieStage = 1; 
     }
   } else if(dieStage == 1) {
     analogWrite(led, 255);
     delay(100);
     analogWrite(led, 0);
     delay(100);
     analogWrite(led, 255);
     delay(100);
     analogWrite(led, 0);
     delay(100);
     analogWrite(led, 255);
     delay(100);
     analogWrite(led, 0);
     delay(100);
     onMode();
   }
 }
 
 void win() {
   int i;
   for(i=0; i < 20; i++) {
     analogWrite(led, 255);
     delay(50);
     analogWrite(led, 0);
     delay(50);
   }
   onMode();
 }
 
 void handleSerial() {
   if(Serial.available()) {
    char inChar = (char)Serial.read();
      if(inChar == 'A') {
        attractMode();
      } else if(inChar == '0') {
        offMode();
      } else if(inChar == '1') {
        onMode();
      } else if(inChar == 'X') {
        dieMode();
      } else if(inChar == 'W') {
        winMode();
      }
   }
 };
 
 void setup() {
   pinMode(led, OUTPUT);
   Serial.begin(9600);
 }
 
 void loop() {
     if(mode == MODE_DIE) {
       die();
     } else if(mode == MODE_WIN) {
       win();
     } else {
       fade();
     }
     handleSerial();
     delay(30);
 }
