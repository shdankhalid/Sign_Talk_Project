#include <SoftwareSerial.h>

int sensor =5;
const int numSensors = 5;
const int analogInPins[numSensors] = {A0, A1, A2, A3, A4};
const int averages[5];
 int value;

 // Define software serial pins
SoftwareSerial bluetoothSerial(2, 3); // RX, TX

void setup() {
   int sensor = 5;  // Set the desired size

  Serial.begin(9600);
  bluetoothSerial.begin(9600); // Start Bluetooth serial communication
}

void loop() {
  int readings[numSensors][50]; // Array to store readings for each sensor
  int averages[numSensors];     // Array to store averages for each sensor
  int readings_mapping[sensor][50]; 
  int i;
  int j,k;
  // Read and store the first 50 readings for each sensor
  for (int sensor = 0; sensor < numSensors; sensor++) {
    for (int i = 0; i < 50; i++) {
      readings[sensor][i] = analogRead(analogInPins[sensor]);
    }
  }
for (int sensor = 0; sensor < numSensors; sensor++) {
    for (int j = 0; j < 50; j++) {
      readings_mapping[sensor][j] = map(readings[sensor][j],0,1023,0,255) ;
    }
  }
  // Calculate averages for each sensor
  for (int sensor = 0; sensor < numSensors; sensor++) {
    int sum = 0;
    for (int k = 0; k < 50; k++) {
      sum += readings_mapping[sensor][k];
    }

    averages[sensor] = sum / 50; 
  }
 // Serial.println(value);
 delay(500);

  // You can also print individual sensor averages if needed
  for (int sensor = 0; sensor < numSensors; sensor++) {
      Serial.print("Sensor ");
    Serial.print(sensor);
    Serial.print(" Average: ");
    Serial.println(averages[sensor]);
  }

  // Send sensor readings over Bluetooth
  for (int sensor = 0; sensor < numSensors; sensor++) {
    bluetoothSerial.print(averages[sensor]+1); // Send sensor averages over Bluetooth
    if(sensor!=4){
      bluetoothSerial.print(',');
    }
    /*Serial.print(averages[sensor]+1);
    if(sensor!=4){
      Serial.print(',');
    }*/
    
  }

  delay(500); // Adjust delay based on your application
}