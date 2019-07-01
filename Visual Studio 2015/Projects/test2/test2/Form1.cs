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

        static int noOfChips = 1;//set this
        static int motorPerChip = 4;//set this
        static int totalMotors = noOfChips * motorPerChip;
        static int totalLevels = 4;//set this
        byte[] motorData = new byte[totalMotors/2];
        
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



        void generateBits()
        {
            string bits = string.Join("", motorData);
            msgBox.AppendText(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "\t\t" +"Dec: "+bits + "\n");            
            msgBox.AppendText(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "\t\t" +"Hex: "+BitConverter.ToString(motorData).Replace("-", string.Empty) + "\n");
            arduinoPort.Write(motorData,0,totalMotors/2);
        }

        void setByte(byte data,int arrayIndex, int position )
        {
            // 0000 0000 0000 0000 0000 0000 0000 0000
            byte temp = 0;
            byte ogVal = motorData[arrayIndex];
            byte ogHigh = (byte)(ogVal & 0xF0);
            byte ogLow =  (byte)(ogVal & 0x0F);
            byte lowD = (byte)(data & 0x0F);
            if (position == 0)
            {
                temp = lowD;
                temp |= ogHigh; 
            }
            else
            {
                temp = ogLow;
                temp |= (byte)(lowD<<4);
            }
            motorData[arrayIndex] = temp;            
        }

        //Set Spefic Motor Level
        void setMotorLevel(Button motorbtn)
        {
            int motorNumber = Convert.ToInt32(motorbtn.Name.Substring(5));
            byte currentState = Convert.ToByte(motorbtn.Text);
            currentState++;            
            //Toggle between States           
            byte newState = Convert.ToByte(currentState % totalLevels);
            currentState = newState;
            setByte(newState, motorNumber/2, motorNumber%2);            
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
            temp = level;
            temp |= (byte)(level << 4);        
            for (int i = 0; i < totalMotors/2; i++)
            {

                motorData[i] = temp;
            }
            setAllMotorLabelText();
        }
        //Apply Specific Label to all motors
        void setAllMotorLabelText()
        {
            double i = 0;
            int j = 0;    
            foreach (Control motor in groupBox1.Controls)
            {
                motor.Text = (j % 2) == 0 ? ((motorData[(int)(i)] & 0x0F) +"") : (((motorData[(int)(i)] & 0xF0)>>4) + "");              
                i = i + 0.5;
                j++;
            }
        }

        private void motorButton_Click(object sender, EventArgs eventArgs)
        {
            setMotorLevel((Button)sender);
            generateBits();
        }
        private void setAll_btn_Click(object sender, EventArgs e)
        {
            setAllMotorLevelTo((byte)(totalLevels-1));
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
            for (int i = 0; i < totalMotors; i++)
            {
                motorData[i] = (byte)(~motorData[i]);
            }
            setAllMotorLabelText();
            generateBits();
        }  
    }
}
