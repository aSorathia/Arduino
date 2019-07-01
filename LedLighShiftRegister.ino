
// Demo sketch to turn on or off bits in a set of shift registers
// Author: Nick Gammon
// Date: 2 May 2012

#include <SPI.h>

const byte LATCH = 10;

const byte numberOfChips = 4;
const byte maxLEDs = numberOfChips * 8;

byte LEDdata [numberOfChips] = { 0 };  // initial pattern

void refreshLEDs ()
  {
  digitalWrite (LATCH, LOW);
  for (int i = numberOfChips - 1; i >= 0; i--)
    SPI.transfer (LEDdata [i]); 
  digitalWrite (LATCH, HIGH);
  } // end of refreshLEDs
  

// how much serial data we expect before a newline
const unsigned int MAX_INPUT = 10;

void setup ()
{
  Serial.begin(9600);
  SPI.begin ();
  refreshLEDs ();
} // end of setup
void process_data (char * data)
  {
  Serial.print ("Got command: ");
  Serial.println (data);
  
  // C: clear all bits
  switch (toupper (data [0]))
    {
     case 'C':
        {
        for (int i = 0; i < numberOfChips; i++) 
          LEDdata [i] = 0;
        Serial.println ("All bits cleared.");
        refreshLEDs ();
        return;
        }
  
    // S: set all bits
    case 'S':
        {
        for (int i = 0; i < numberOfChips; i++) 
          LEDdata [i] = 0xFF;
        Serial.println ("All bits set.");
        refreshLEDs ();
        return;
        }
    
    // I: invert all bits
    case 'I':
        {
        for (int i = 0; i < numberOfChips; i++) 
          LEDdata [i] ^= 0xFF;
        Serial.println ("All bits inverted.");
        refreshLEDs ();
        return;
        }
    } // end of switch
  
  // otherwise: nnx 
  //   where nn is 1 to 89 and x is 0 for off, or 1 for on
  
  // check we got numbers
  for (int i = 0; i < 3; i++)
    if (!isdigit (data [i]))
      {
      Serial.println ("Did not get 3 digits.");
      return;
      }
      
  // convert first 2 digits to the LED number
  byte led = (data [0] - '0') * 10 + (data [1] - '0');
  
  // convert third digit to state (0 = off)
  byte state = data [2] - '0';  // 0 = off, otherwise on
  
  if (led > maxLEDs)
      {
      Serial.println ("LED # too high.");
      return;
      }
   
   led--;  // make zero relative
   
   // divide by 8 to work out which chip
   byte chip = led / 8;  // which chip
   
   // remainder is bit number
   byte bit = 1 << (led % 8);
   
   // turn bit on or off
   if (state)
     LEDdata [chip] |= bit;
   else
     LEDdata [chip] &= ~ bit;
  
  Serial.print ("Turning ");
  Serial.print (state ? "on" : "off");
  Serial.print (" bit ");
  Serial.print (led & 0x7, DEC);
  Serial.print (" on chip ");
  Serial.println (chip, DEC);
  
  refreshLEDs ();
  }  // end of process_data
  
void loop()
{
static char input_line [MAX_INPUT];
static unsigned int input_pos = 0;

  if (Serial.available () > 0) 
    {
    char inByte = Serial.read ();    
    switch (inByte)
    {
    case '\n':   // end of text
        input_line [input_pos] = 0;  // terminating null byte        
        // terminator reached! process input_line here ...
        process_data (input_line);        
        // reset buffer for next time
        input_pos = 0;  
        break;  
      case '\r':   // discard carriage return
        break;  
      default:
        // keep adding if not full ... allow for terminating null byte
        if (input_pos < (MAX_INPUT - 1))
          input_line [input_pos++] = inByte;
        break;
      }  // end of switch
  }  // end of incoming data
  // do other stuff here like testing digital input (button presses) ...
}  // end of loop