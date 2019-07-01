#include "Wire.h"

void setup()
{
 Wire.begin();
 Serial.begin(9600);                    
 Serial.println ("IC2 master starting");
}


void i2c_scan_p()
{
 Serial.println ();
 Serial.println ("Scanning");
 int nbr_module = 0;
 Wire.begin();
 for (byte i = 1; i < 127; i++)
 {
   Wire.beginTransmission (i);
   if (Wire.endTransmission () == 0)
   {
     Serial.print ("adress found: "),Serial.print (i, DEC),Serial.print (" (0x"),Serial.print (i, HEX),Serial.println (")");
     nbr_module++;
   } 
 }
 delay(1000);
 Serial.println ("Scan done");
 Serial.print ("there is "),Serial.print (nbr_module, DEC),Serial.println (" module(s) on the bus");
}


void loop()
{
i2c_scan_p();
}
