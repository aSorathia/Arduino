using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
namespace test2
{
    public partial class Form1 : Form
    {
        static int maxLevel = 4;//set this  
        static int noOfIC = 16;//set this
        static int motorPerIC = 4;//set this
        static int bitToUse = 2; //No of Bits required for each motor or bit per IC
        byte bitMask = 0x03;

        static int totalMotors = noOfIC * motorPerIC;                
        static int lenOfMD = totalMotors / (8/bitToUse);
        byte[] motorData = new byte[lenOfMD];//(totalMotors/No of MotorData in EachByte)        
        

        private SerialPort arduinoPort;

        public Form1()
        {
            InitializeComponent();
            arduinoPort = new SerialPort();
            getAvailablePorts();
        }

        void getAvailablePorts()
        {
            string[] port = SerialPort.GetPortNames();
            portName_cmbbx.Items.AddRange(port);
        }

        void enableComponents(bool enable)
        {
            openPort_btn.Enabled = !enable;
            closePort_btn.Enabled = enable;
            msgBox.Enabled = enable;
            reset_btn.Enabled = enable;
            setAll_btn.Enabled = enable;
            progressBar1.Enabled = enable;
            groupBox1.Enabled = enable;
            save_btn.Enabled = enable;
            invertAll.Enabled = enable;
            chk_Rt.Enabled = enable;
        }
     
        void generateBits()
        {
            if (chk_Rt.Checked)
            {
                string bits = string.Join("", motorData);
                msgBox.AppendText(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "\t\t" + "Dec: " + bits + "\n");
                msgBox.AppendText(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "\t\t" + "Hex: " + BitConverter.ToString(motorData).Replace("-", string.Empty) + "\n");
                arduinoPort.Write(motorData, 0, lenOfMD);
            }
        }

        void setByte(byte data,int arrayIndex, int position ) { 
                       
            byte shiftData;
            int maxBit = 8 - bitToUse;
            int bitPosition = maxBit - (position * bitToUse);
            byte temp = motorData[arrayIndex];  //copy original values from array
            byte mask = (byte)(~(bitMask << bitPosition)); //Move the mask to correct pos
            temp &= mask;  //clear the position for new data
            shiftData = (byte)(data << bitPosition);//Shift the data to correct pos
            temp |= shiftData; //copy the new data;
            motorData[arrayIndex] = temp;           
        }

        //Set Spefic Motor Level
        void setMotorLevel(Button motorbtn)
        {
            int motorNumber = Convert.ToInt32(motorbtn.Name.Substring(5));
            byte currentState = Convert.ToByte(motorbtn.Text);
            currentState++;            
            //Toggle between States           
            byte newState = Convert.ToByte(currentState % maxLevel);
            currentState = newState;
            setByte(newState, motorNumber/motorPerIC, motorNumber% motorPerIC); //setByte(state, array Index, ArrayPosition);           
            setMotorLabelText(motorbtn, newState);
        }

        //Set Specific Motor Label
        void setMotorLabelText(Button motorbtn, int state)
        {
            motorbtn.Text = state + "";
        }        
             
        //Apply Specific Level to all motors
        void setAllMotorLevelTo(byte level)
        {
            byte temp = 0;
            for (int i = 0; i<maxLevel; i++)
            {
                temp |= (byte)(level << (i * bitToUse));
            }
            for (int i = 0; i < lenOfMD; i++)
            {
                motorData[i] = temp;
            }
            setAllMotorLabelText();
        }
        
        //Apply Specific Label to all motors
        void setAllMotorLabelText()
        {
            int position;
            int index;
            int maxBit = 8 - bitToUse;
            
            foreach (Control motor in groupBox1.Controls)
            {
                int motorNumber = Convert.ToInt32(motor.Name.Substring(5));
                index = motorNumber / motorPerIC;
                position = motorNumber % motorPerIC;
                motor.Text = ((motorData[index] >> position) & bitMask)+"";                
            }
        }

        private void openPort_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (portName_cmbbx.Text == "")
                {
                    MessageBox.Show("Select PortName");

                }
                else
                {
                    //Port Setup
                    arduinoPort.PortName = portName_cmbbx.Text;
                    arduinoPort.BaudRate = (baudRate_cmbbx.Text == "") ? 9600 : Convert.ToInt32(baudRate_cmbbx.Text);
                    arduinoPort.Parity = Parity.None;
                    arduinoPort.DataBits = 8;
                    arduinoPort.StopBits = StopBits.One;
                    arduinoPort.Open();
                    enableComponents(true);
                    setAllMotorLevelTo(0);
                    generateBits();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void closePort_btn_Click(object sender, EventArgs e)
        {
            try
            {
                arduinoPort.Close();
                enableComponents(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void motorButton_Click(object sender, EventArgs eventArgs)
        {
             setMotorLevel((Button)sender);
             generateBits();            
        }

        private void setAll_btn_Click(object sender, EventArgs e)
        {
            setAllMotorLevelTo((byte)(maxLevel-1));
            generateBits();
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            setAllMotorLevelTo((byte)0);
            generateBits();
        }     

        private void save_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string pathFile = @"C:\users\Abdullah\desktop\data";
                string fileName = "motorData.txt";
                System.IO.File.WriteAllText(pathFile + fileName, msgBox.Text);
                MessageBox.Show("Data has been saved to " + pathFile, "Save FIle");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        
        private void invertAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lenOfMD; i++)
            {
                motorData[i] = (byte)(~motorData[i]);
            }
            setAllMotorLabelText();
            generateBits();
        }

        private void chk_Rt_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                sendRT.Enabled = false;
            }
            else
            {
                sendRT.Enabled = true;
            }
        }

        private void sendRT_Click(object sender, EventArgs e)
        {
            string bits = string.Join("", motorData);
            msgBox.AppendText(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "\t\t" + "Dec: " + bits + "\n");
            msgBox.AppendText(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "\t\t" + "Hex: " + BitConverter.ToString(motorData).Replace("-", string.Empty) + "\n");
            arduinoPort.Write(motorData, 0, lenOfMD);
        }
    }
}
