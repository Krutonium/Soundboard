using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NAudio;
using NAudio.Wave; //MS-PL, but only applies to Library https://softwareengineering.stackexchange.com/questions/185072/microsoft-public-license-vs-mit
using Indieteur.GlobalHooks; //CC0 1.0 Universal
using Newtonsoft.Json; //MIT
//using System.Media;

namespace Soundboard
{
    public partial class frmSoundboard : Form
    {
        static WaveOutEvent OutputDevice = new WaveOutEvent();
        static List<string> audioFiles = new List<string>();
        //Audio Stuff ^
        static GlobalKeyHook globalKeyHook = new GlobalKeyHook();
        static Keybinds Keybindings = new Keybinds();
        //Lets us bind and use keys globally ^
        static int CurrRow = 0;
        static int HeightOffset = 10;
        //Variables used to handle the actual binds & contol locations. ^
        public frmSoundboard()
        {
            InitializeComponent();
        }

        private void FrmSoundboard_Load(object sender, EventArgs e)
        {
            HashSet<string> AllowedExtensions = new HashSet<string>(new string[] { ".WAV", ".MP3" });
            foreach (var file in Directory.GetFiles("./sounds"))
            {

                if (AllowedExtensions.Contains(Path.GetExtension(file.ToUpper())))
                {
                    listSounds.Items.Add(Path.GetFileNameWithoutExtension(file));
                    audioFiles.Add(file);
                }
            }
            
            globalKeyHook.OnKeyDown += GlobalKeyHook_OnKeyDown;
            if (File.Exists("binds.json"))
            {
                Keybindings = JsonConvert.DeserializeObject<Keybinds>(File.ReadAllText("binds.json"));
                int tmprow = 0;
                foreach (var bind in Keybindings.binds)
                {
                    CreateNewKeybindRow();
                    var button = FindButtonByNumber(tmprow);
                    var label = FindLabelFromButton(button);
                    var textbox = FindTextBoxFromButton(button);
                    label.Text = bind.Key;
                    textbox.Text = bind.Value.ToString();
                    tmprow++;
                }
            } else
            {
                Keybindings.binds = new Dictionary<string, VirtualKeycodes>();
            }
            panelBinds.AutoScroll = true;
            listSounds.SelectedIndex = 0;
        }


        class Keybinds
        {
            public Dictionary<string, VirtualKeycodes> binds = new Dictionary<string, VirtualKeycodes>();
        }

        private void GlobalKeyHook_OnKeyDown(object sender, GlobalKeyEventArgs e)
        {
            foreach (var bind in Keybindings.binds)
            {
                if (bind.Value == e.KeyCode)
                {
                    if (OutputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        OutputDevice.Stop();
                    }
                    var AudioFile = new AudioFileReader(bind.Key);
                    OutputDevice.Init(AudioFile);
                    OutputDevice.Play();
                    return;
                }
            }
            if(e.Alt != ModifierKeySide.None && e.KeyCode == VirtualKeycodes.B)
            {
                Random rand = new Random();
                rand.Next();
                var b = audioFiles[rand.Next(0, audioFiles.Count)];
                var AudioFile = new AudioFileReader(b);
                if (OutputDevice.PlaybackState == PlaybackState.Playing)
                {
                    OutputDevice.Stop();
                }
                OutputDevice.Init(AudioFile);
                OutputDevice.Play();
                e.Handled = true;
                return;
            }
        }

        private void ListSounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SoundPlayer sound = new SoundPlayer(listSounds.SelectedItem.ToString());
            //sound.Play();
            if (OutputDevice.PlaybackState == PlaybackState.Playing)
            {
                OutputDevice.Stop();
            }
            var AudioFile = new AudioFileReader(audioFiles[listSounds.SelectedIndex]);
            OutputDevice.Init(AudioFile);
            OutputDevice.Play();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            CreateNewKeybindRow();
        }

        private void CreateNewKeybindRow()
        {
            var Button = new Button();
            Button.Name = "CMD_" + CurrRow.ToString();
            Button.Text = "Click to Assign";
            Button.Location = new Point(0, HeightOffset);
            Button.Size = new Size(110, 20);
            Button.Click += Button_Click;
            //Button Setup

            var TB = new TextBox();
            TB.Name = "TB_" + CurrRow.ToString();
            TB.Location = new Point(Button.Location.X + 120, HeightOffset);
            TB.Size = Button.Size;
            TB.Enabled = false;
            //TextBox Setup

            var Label = new Label();
            Label.Name = "LBL_" + CurrRow.ToString();
            Label.Text = "Audio File";
            Label.Location = new Point(TB.Location.X + 120, HeightOffset + 5);
            Label.Size = TB.Size;
            panelBinds.Controls.Add(Button);
            panelBinds.Controls.Add(TB);
            panelBinds.Controls.Add(Label);

            CurrRow++;
            HeightOffset += 35;
        }


        private void Button_Click(object sender, EventArgs e)
        {
            var filefield = FindLabelFromButton(sender as Button);
            var bind = FindTextBoxFromButton(sender as Button);
            globalKeyHook.Dispose();
            FrmGetInput frm = new FrmGetInput();
            frm.ShowDialog();
            globalKeyHook = new GlobalKeyHook();
            bind.Text = frm.returnValue.ToString(); //Dunno how to fix halp
            filefield.Text = audioFiles[listSounds.SelectedIndex];
        }
        private Label FindLabelFromButton(Button srcButton)
        {
            string lb = srcButton.Name.Substring(4, srcButton.Name.Length - 4);
            lb = "LBL_" + lb;
            var label = this.Controls.Find(lb, true);
            return (label[0] as Label);
            //Uses the integer from the end of the button name to find associated Label. #Hack
        }
        private TextBox FindTextBoxFromButton(Button srcButton)
        {
            string lb = srcButton.Name.Substring(4, srcButton.Name.Length - 4);
            lb = "TB_" + lb;
            var tb = this.Controls.Find(lb, true);
            return (tb[0] as TextBox);
            //Uses the integer from the end of the button name to find associated Textbox. #Hack
        }
        private Button FindButtonByNumber(int Number)
        {
            var button = this.Controls.Find("CMD_" + Number.ToString(), true);
            return button[0] as Button;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Keybindings = new Keybinds();
            for (int count = 0; count < CurrRow; count++)
            {
                var button = FindButtonByNumber(count);
                var label = FindLabelFromButton(button);
                var textbox = FindTextBoxFromButton(button);
                //We have our objects!
                if(label.Text != "Audio File")
                {
                    VirtualKeycodes keycode = (VirtualKeycodes)System.Enum.Parse(typeof(VirtualKeycodes), textbox.Text);
                    bool allowed = true;
                    foreach (var bind in Keybindings.binds)
                    {
                        if(bind.Value == keycode)
                        {
                            allowed = false;
                            MessageBox.Show("You have a duplicate keybinding. This does not work. Please remove it.");
                        }
                    }
                    if (allowed)
                    {
                        Keybindings.binds.Add(label.Text, keycode);
                    }
                }
            }
            File.WriteAllText("./binds.json", JsonConvert.SerializeObject(Keybindings,Formatting.Indented));
        }
    }
}
