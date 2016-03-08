using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace Arduino_Voice_Serial_2
{
    public partial class Form1 : Form
    { 
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        public Form1()
        {
            InitializeComponent();
            serialPort1.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            button2.Enabled = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Choices commands = new Choices();
            commands.Add(new string[] { "Hello", "abaay baaatee baand kar", "Good", "who am i", "i am good", "lights on, sir", "lights off, sir", "Very well sir !", "print my name", "lights on", "lights off", "abaay baaatee on kar" });
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);

            recEngine.LoadGrammar(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += recEngine_SpeechRecognized;

        }

        private void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            switch (e.Result.Text)
            {
                case "Hello":
                    synthesizer.SpeakAsync("Hello Aakshat. How are you ?");
                    break;
                case "Good":
                    synthesizer.SpeakAsync("Very well sir! ");
                    MessageBox.Show(":)");
                    break;
               case "who am i" :
                    synthesizer.SpeakAsync("You are my mentor and designer Mister Aakshat, you are a student and you are a cool person");
                    break;
                case "i am good, how are you ?":
                    synthesizer.SpeakAsync("Very well sir! ");
                    break;
                case "print my name":
                    synthesizer.SpeakAsync("Akshaat");
                    richTextBox1.Text += "\n Akshat";
                    break;
                case "abaay baaatee baand kar":
                    if (true)
                    {
                        synthesizer.SpeakAsync("lights off, sir");
                        serialPort1.Write("k");
                        richTextBox1.Text += "\n Light Switched OFF";
                        break;
                    }
                case "abaay baaatee on kar":
                    if (true)
                    {
                        synthesizer.SpeakAsync("lights on, sir");
                        serialPort1.Write("A");
                        richTextBox1.Text += "\n Light Switched ON";
                        break;
                    }
                    
               case "lights on":
                    if (true)
                    {
                        synthesizer.SpeakAsync("lights on, sir");
                        serialPort1.Write("A");
                        richTextBox1.Text += "\n Light Switched ON";
                        break;
                    }
                case "lights off":
                    if (true)
                    {
                        synthesizer.SpeakAsync("lights off, sir");
                        serialPort1.Write("k");
                        richTextBox1.Text += "\n Light Switched OFF";
                        break;
                    }
                    

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            recEngine.RecognizeAsyncStop();
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.Write("A");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            serialPort1.Write("k");
        }
    }
}
