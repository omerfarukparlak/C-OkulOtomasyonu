﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class waitForm : Form
    {
        public Action Action { get; set; }
        public waitForm(Action action)
        {
            InitializeComponent();
            if (action!=null)
            {
                Action = action;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Action).ContinueWith(x => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        private void waitForm_Load(object sender, EventArgs e)
        {

        }
    }
}
