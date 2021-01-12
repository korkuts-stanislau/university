#include <LiquidCrystal.h>
#include <Stepper.h> 

const int IN1 = 2; 
const int IN2 = 3; 
const int IN3 = 4; 
const int IN4 = 5; 
float gradus=0;

const int stepsPerRevolution = 32; // шагов за один оборот 

Stepper myStepper(stepsPerRevolution, IN1, IN2, IN3, IN4); 
LiquidCrystal lcd(7, 8, 9, 10, 11 , 12);

void setup() { 
myStepper.setSpeed(500); // скорость 500 об/минуту
lcd.begin(16,2);
lcd.setCursor(0,1);
}

void loop() {
myStepper.step(stepsPerRevolution); // 32 шага в одном направлении
if(gradus<348.75)
{
  gradus+=11.25;
}
else
{
  gradus-=348.75;
}
lcd.print(gradus);
delay(1000);
lcd.clear();
}
