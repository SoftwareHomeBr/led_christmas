#include <Adafruit_NeoPixel.h>
#ifdef __AVR__
  #include <avr/power.h>
#endif

#define PIN 6
int count = 0; 

// Parameter 1 = number of pixels in strip
// Parameter 2 = Arduino pin number (most are valid)
// Parameter 3 = pixel type flags, add together as needed:
//   NEO_KHZ800  800 KHz bitstream (most NeoPixel products w/WS2812 LEDs)
//   NEO_KHZ400  400 KHz (classic 'v1' (not v2) FLORA pixels, WS2811 drivers)
//   NEO_GRB     Pixels are wired for GRB bitstream (most NeoPixel products)
//   NEO_RGB     Pixels are wired for RGB bitstream (v1 FLORA pixels, not v2)
//   NEO_RGBW    Pixels are wired for RGBW bitstream (NeoPixel RGBW products)
Adafruit_NeoPixel strip = Adafruit_NeoPixel(300, PIN, NEO_GRB + NEO_KHZ800);

// IMPORTANT: To reduce NeoPixel burnout risk, add 1000 uF capacitor across
// pixel power leads, add 300 - 500 Ohm resistor on first pixel's data input
// and minimize distance between Arduino and first pixel.  Avoid connecting
// on a live circuit...if you must, connect GND first.
  byte freeze = 0;
  int demoModeDelay = 10;
  uint32_t m_colors[] = {  strip.Color(20,  0, 0),
                           strip.Color(20, 15, 0),
                           strip.Color( 0, 15, 0),
                           strip.Color( 0, 15,20),
                           strip.Color( 0,  0,20),
                           strip.Color(20,  0,20),
                           strip.Color( 0,  0, 0),
                           strip.Color( 0,  0, 0),
                           strip.Color( 0,  0, 0)};

 #define NUM_COLORS sizeof(m_colors)/sizeof(uint32_t)
 
void setup() {
  // This is for Trinket 5V 16MHz, you can remove these three lines if you are not using a Trinket
  #if defined (__AVR_ATtiny85__)
    if (F_CPU == 16000000) clock_prescale_set(clock_div_1);
  #endif
  // End of trinket special code

  Serial.begin(9600);
  strip.begin();
  strip.show(); // Initialize all pixels to 'off'
}

void loop() {
  Serial.write("Osw RGB 300 leds 2016-12-23 #");
  Serial.println(demoModeDelay);
  byte bb = freeze;
  if(demoModeDelay <1){
    bb = '9';
  }
  if(Serial.available()){
    bb = (Serial.read());
    demoModeDelay = 10;
  }
  // Some example procedures showing how to display to the pixels:
  switch(bb){
    case ('Z' ):
          freeze = 1;
          demoModeDelay--;
      break;
    case ('X' ):
          freeze = 0;
          demoModeDelay--;
      break;
    case '1':
      colorWipe(strip.Color(30, 0, 0), 1); // Red
    break;
    case '2':
      colorWipe(strip.Color(0, 30,0), 1); // Green
      break;
    case '3':
      colorWipe(strip.Color(0, 0, 30), 1); // Blue
      break;
    case '4':
      colorRightnBackWipe(strip.Color( 55, 0, 0), 4); // Red
      break;
    case '5':
      colorRightnBackWipe(strip.Color(0, 55, 0), 4); // Green
      break;
    case '6':
      colorRightnBackWipe(strip.Color(0,0, 55), 4); // Blue
    break;
    case '7':
      colorWipe(strip.Color(20, 20, 20), 1); // Blue
      break;
    case '8':
      //rainbowCycle(2);
      rainbow(2);
      break;
    case '9':
      rainbowCycle(5);
      if(Serial.available()) // ** abort on serial RX
        return;
      colorRightnBackWipe(strip.Color( 20, 0, 0), 4); // Green
      colorRightnBackWipe(strip.Color(0, 20, 0), 4); // Green
      colorRightnBackWipe(strip.Color(0,0, 20), 4); // Green
      if(Serial.available()) // ** abort on serial RX
        return;
      colorRightnBackWipe(strip.Color( 30, 30, 0), 4); // Green
      colorRightnBackWipe(strip.Color(0, 30, 30), 4); // Pourple
      if(Serial.available()) // ** abort on serial RX
        return;
      theaterChase(strip.Color( 15, 10, 2),180); //circus
      chasePalette(20);       // color circus
      if(Serial.available()) // ** abort on serial RX
        return;
      chasePalette(20);       // color circus
      if(Serial.available()) // ** abort on serial RX
        return;
      chasePalette(20);       // color circus
      if(Serial.available()) // ** abort on serial RX
        return;
      colorRightnBackWipe(strip.Color(30,0, 30), 4); // Lilas
      colorRightnBackWipe(strip.Color( 30, 15, 0), 4); // Orange
      if(Serial.available()) // ** abort on serial RX
        return;
      colorRightnBackWipe(strip.Color(0, 30, 10), 4); // Turquise
      colorRightnBackWipe(strip.Color(8,0, 30), 4); // Roxo
      for(int n=0; n<2; n++){
        colorWipe(strip.Color(30, 0, 0), 1); // Red
        colorWipe(strip.Color(0, 30,0), 1); // Blue
        colorWipe(strip.Color(0, 0, 20), 1); // Blue
        if(Serial.available()) // ** abort on serial RX
          return;
      }
      rainbow(20);
      ringUp(strip.Color(30, 0, 0), 100);
      ringUp(strip.Color(30, 0, 0), 100);
      ringUp(strip.Color(30, 30, 0), 100);
      ringUp(strip.Color(30, 30, 0), 100);
      ringUp(strip.Color(30, 0, 30), 100);
      ringUp(strip.Color(30, 0, 30), 100);
      ringUp(strip.Color(0, 0, 30), 100);
      ringUp(strip.Color(0, 0, 30), 100);
      theaterChaseRainbow(5);
      flashColors();
      flashColors();
      flashColors();
      flashColors();
      slowColors(20);
      slowColors(20);
      colorRightnBackWipe(strip.Color(0, 15, 15), 4); // White

      if(Serial.available()) // ** abort on serial RX
        return;
      
      break;
    case 'A':  // letter A
      ringUp(strip.Color(30, 0, 0), 100);
    break;
    case 'B':  // letter B
      ringUp(strip.Color(0, 30, 0), 100);
    break;
    case 'C':  // letter C
      ringUp(strip.Color(0, 0, 30), 100);
    break;
    case 'D':   //  letter D
      theaterChaseRainbow(5);
      break;
    case 'E':   //  letter E
      colorFastFill(strip.Color(10, 0, 0));
      break;
    case 'F':   //  letter F
      colorFastFill(strip.Color(0, 10, 0));
      break;
    case 'G':   //  letter G
      colorFastFill(strip.Color(0, 0, 10));
      break;
    case 'H':   //  letter H
      colorFastFill(strip.Color(10, 0, 5));
      break;
    case 'I':  //   letter I
      chasePalette(20);
      break;
    case 'J':  //   letter J
      flashColors();
      break;
    case 'K':  //   letter K
      slowColors(20);
      break;
    default:
      if(freeze == 0)
        theaterChase(strip.Color( 15, 10, 2),180); //circus
      else
        colorFastFill(strip.Color(00, 0, 00)); // Black
      demoModeDelay--;
      break;
  }
//colorWipe(strip.Color(0, 0, 0, 255), 50); // White RGBW
  // Send a theater pixel chase in...
  //theaterChase(strip.Color(127, 127, 127), 50); // White
  //theaterChase(strip.Color(127, 0, 0), 50); // Red
  //theaterChase(strip.Color(0, 0, 127), 50); // Blue

 // rainbow(20);
 // rainbowCycle(20);
 // theaterChaseRainbow(50);
}
// Fill the all dots with a color
void colorFastFill(uint32_t c) {
  for(uint16_t i=0; i<strip.numPixels(); i++) {
    strip.setPixelColor(i, c);
  }
  strip.show();
  while(!Serial.available());
    
}

void flashColors(){

  for(uint16_t j=0; j < (NUM_COLORS-3); j++) {
    for(uint16_t i=0; i<strip.numPixels(); i++) {
      strip.setPixelColor(i, m_colors[j]);
    }
    strip.show();
    delay(200);
    for(uint16_t i=0; i<strip.numPixels(); i++) {
      strip.setPixelColor(i, 0);
    }
    strip.show();
    delay(200);
    if(Serial.available())
      return;
  }
}

// Fill sequenced dots one after the other with a color from a vector
void chasePalette( uint8_t wait) {

  uint32_t c;
  uint32_t ptr=0;
  for(uint16_t j=0; j<100; j++) {
    for(uint16_t i=0; i<strip.numPixels(); i++) {
      int ix = (NUM_COLORS - (j % NUM_COLORS) + i ) % (NUM_COLORS);
      c = m_colors[ix];
      strip.setPixelColor(i, c);
    }
      strip.show();
      delay(wait);
  }
}
// fill all dots with WHEEL colors for a complete cycle
void slowColors( uint8_t wait){
  uint16_t i, j;
  for(j=0; j<256; j++) {
    for(i=0; i<strip.numPixels(); i++) {
      strip.setPixelColor(i, Wheel((j) & 255));
    }
    strip.show();
    delay(wait);
  }
}


// Fill the dots one after the other with a color
void colorWipe(uint32_t c, uint8_t wait) {
  for(uint16_t i=0; i<strip.numPixels(); i++) {
    strip.setPixelColor(i, c);
    strip.show();
    delay(wait);
  }
}
// Fill the rings in cone form
void ringUp(uint32_t c, uint8_t wait) {
  int ringSize = 30;
  for(uint16_t i=0; i<(strip.numPixels()); i+= ringSize) {
    for(uint16_t x=0; x<strip.numPixels(); x++)
      strip.setPixelColor(x, 0);
    strip.show();
    for(uint16_t j=0; j< ringSize; j++) {
      strip.setPixelColor(i + j, c);
    }
    ringSize -= 1;
    strip.show();
    delay(wait);
  }
}
// Fill the dots one after the other with a color in oposite sides
void colorRightnBackWipe(uint32_t c, uint8_t wait) {
  for(uint16_t i=1; i<strip.numPixels(); i++) {
    strip.setPixelColor(i, c);
    strip.setPixelColor(i-1, 0);
    //strip.setPixelColor(strip.numPixels()-i-1, c ^ 0xffffffff);
    strip.setPixelColor(strip.numPixels()-i-1, c );
    strip.setPixelColor(strip.numPixels()-i, 0);
    strip.show();
    delay(wait);
  }
}

void rainbow(uint8_t wait) {
  uint16_t i, j;

  for(j=0; j<256; j++) {
    for(i=0; i<strip.numPixels(); i++) {
      strip.setPixelColor(i, Wheel((i+j) & 255));
    }
    strip.show();
    delay(wait);
  }
}

// Slightly different, this makes the rainbow equally distributed throughout
void rainbowCycle(uint8_t wait) {
  uint16_t i, j;

  for(j=0; j<256*5; j++) { // 5 cycles of all colors on wheel
    for(i=0; i< strip.numPixels(); i++) {
      strip.setPixelColor(i, Wheel(((i * 256 / strip.numPixels()) + j) & 255));
    }
    strip.show();
    delay(wait);
  }
}

//Theatre-style crawling lights.
void theaterChase(uint32_t c, uint8_t wait) {
  for (int j=0; j<10; j++) {  //do 10 cycles of chasing
    for (int q=0; q < 3; q++) {
      for (uint16_t i=0; i < strip.numPixels(); i=i+3) {
        strip.setPixelColor(i+q, c);    //turn every third pixel on
      }
      strip.show();
      if(Serial.available()) // ** abort on serial RX
        return;
      delay(wait);

      for (uint16_t i=0; i < strip.numPixels(); i=i+3) {
        strip.setPixelColor(i+q, 0);        //turn every third pixel off
      }
    }
  }
}

//Theatre-style crawling lights with rainbow effect
void theaterChaseRainbow(uint8_t wait) {
  for (int j=0; j < 256; j++) {     // cycle all 256 colors in the wheel
    for (int q=0; q < 3; q++) {
      for (uint16_t i=0; i < strip.numPixels(); i=i+3) {
        strip.setPixelColor(i+q, Wheel( (i+j) % 255));    //turn every third pixel on
      }
      strip.show();
      if(Serial.available())
        return;
      delay(wait);

      for (uint16_t i=0; i < strip.numPixels(); i=i+3) {
        strip.setPixelColor(i+q, 0);        //turn every third pixel off
      }
    }
  }
}

// Input a value 0 to 255 to get a color value.
// The colours are a transition r - g - b - back to r.
uint32_t Wheel(byte WheelPos) {
  WheelPos = 255 - WheelPos;
  if(WheelPos < 85) {
    return strip.Color((255 - WheelPos * 3)/4, 0, (WheelPos * 3)/4);
  }
  if(WheelPos < 170) {
    WheelPos -= 85;
    return strip.Color(0, (WheelPos * 3)/4, (255 - WheelPos * 3)/4);
  }
  WheelPos -= 170;
  return strip.Color((WheelPos * 3)/4, (255 - WheelPos * 3)/4, 0);
}
uint32_t WheelOriginal(byte WheelPos) {
  WheelPos = 255 - WheelPos;
  if(WheelPos < 85) {
    return strip.Color(255 - WheelPos * 3, 0, WheelPos * 3);
  }
  if(WheelPos < 170) {
    WheelPos -= 85;
    return strip.Color(0, WheelPos * 3, 255 - WheelPos * 3);
  }
  WheelPos -= 170;
  return strip.Color(WheelPos * 3, 255 - WheelPos * 3, 0);
}
