using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Indieteur.GlobalHooks;
namespace Soundboard
{
    public partial class FrmGetInput : Form
    {
        GlobalKeyHook globalKeyHook = new GlobalKeyHook();
        public VirtualKeycodes returnValue;
        public FrmGetInput()
        {
            InitializeComponent();
        }

        private void FrmGetInput_Load(object sender, EventArgs e)
        {
            this.Shown += FrmGetInput_Shown;
        }

        private void FrmGetInput_Shown(object sender, EventArgs e)
        {
            
            globalKeyHook.OnKeyDown += GlobalKeyHook_OnKeyDown;
        }

        private void GlobalKeyHook_OnKeyDown(object sender, GlobalKeyEventArgs e)
        {
            returnValue = e.KeyCode;
            globalKeyHook.Dispose();
            this.Close();
        }
    }
}
