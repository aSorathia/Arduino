#include <stdio.h>
#include <stdlib.h>
#include <avr/io.h>
#include <util/delay.h>

#include "stepper04multi/stepper04multi.h"

int main(void) {
	uint8_t i = 0;

	//init stepper
	stepper04multi_init();

	//set step velocity
	for(i=0; i<STEPPER04MULTI_MOTORNUM; i++)
		stepper04multi_setsteptime(i, 1280);

	uint8_t motorstep[STEPPER04MULTI_MOTORNUM];
	for(i=0; i<STEPPER04MULTI_MOTORNUM; i++)
		motorstep[i] = 0;

	for(;;) {
		//alternate backward and forward
		for(i=0; i<STEPPER04MULTI_MOTORNUM; i++) {
			if(stepper04multi_getstep(i) == 0) {
				if(motorstep[i] == 0)
					stepper04multi_gobackward(i, 2000);
				else
					stepper04multi_goforward(i, 2000);
				motorstep[i]++;
				if(motorstep[i] == 2)
					motorstep[i] = 0;
			}
		}
	}
}
