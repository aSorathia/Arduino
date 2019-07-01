#include<stdio.h>
#include<conio.h>
char motordata[16];
int bitToUse=5;
char bitMask = 0x1F;

char data;
int index;
int position;
int c;

void setter(int data, int index, int position){
	char shiftData;
	int maxBit = 8 - bitToUse;
	int bitPosition = maxBit - (position * bitToUse);
	char temp = motordata[index];  //copy original values from array
	char mask = ~(bitMask << bitPosition); //Move the mask to correct pos
	temp &= mask;  //clear the position for new data
	shiftData = (data << bitPosition);//Shift the data to correct pos
	temp |= shiftData; //copy the new data;
	motordata[index] = temp;
}

void main(){
c=1;
	while(c!=0){
		printf("Enter hex data: ");
		scanf("%x", &data);
		printf("Enter Index: ");
		scanf("%d", &index);
		printf("Enter position: ");
		scanf("%d", &position);
		setter(data, index, position);
		printf("Do u want to continue: ");
		scanf("%d",&c);
	}
	getch();
}