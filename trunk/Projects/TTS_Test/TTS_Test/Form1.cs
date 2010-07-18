using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpeechLib;

namespace TTS_Test
{
    public partial class Form1 : Form
    {

        private SpeechLib.SpVoiceClass voice;
        private SpeechLib.ISpeechObjectTokens tokens;


        public Form1()
        {
            InitializeComponent();
            voice = new SpeechLib.SpVoiceClass();
            tokens = voice.GetVoices("", "");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "开始")
            {
                voice.SetVoice((SpeechLib.ISpObjectToken)voice.GetVoices("Name=" + cbxVoices.Text, string.Empty).Item(0));
                voice.SetVolume((ushort)volBar.Value);
                voice.SetRate((ushort)speedBar.Value);
                voice.Speak(txtS.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                btnStart.Text = "暂停";
            }
            else if (btnStart.Text.Trim() == "暂停")
            {
                voice.Pause();
                btnStart.Text = "继续";
            }
            else
            {
                btnStart.Text = "暂停";
                voice.Resume();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                cbxVoices.Items.Add(tokens.Item(i).GetAttribute("Name"));
            }
            cbxVoices.SelectedIndex = 0;
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Text = "开始";
           voice.Speak("", SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);
           voice.SetVoice(null);
        }
    }
}
