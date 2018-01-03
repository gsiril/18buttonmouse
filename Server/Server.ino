#include <ESP8266WiFi.h>
#include <WiFiClient.h>
#include <WiFiServer.h>
'Siril change test
#define PORT 23

WiFiClient client;
WiFiServer server(PORT);

String dataClient;
String dataServer;

const char* ssid     = "Agent 47";
const char* pass = "defnetopal";

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  Serial.print("Koneksi TCPIP ");
  Serial.println("Port : ");
  Serial.print(PORT);
  pinMode(LED_BUILTIN,OUTPUT);// output LED
  digitalWrite(LED_BUILTIN,LOW);
  WiFi.begin(ssid,pass);
  while(WiFi.status()!=WL_CONNECTED){
    Serial.print(".");
    delay(500);
  }

Serial.println("You are connected to : ");
Serial.print(ssid);
Serial.println("@IP Address : ");
Serial.print(WiFi.localIP());
Serial.println("");
delay(200);
server.begin();

}

void loop() {
  // put your main code here, to run repeatedly:
 while(!client.connected()){
  client=server.available();
  client.print("L11");
 }

 while(client.connected()){
  if(client.available()){
      
  }
 }
}
