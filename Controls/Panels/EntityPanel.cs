﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoQL.Controls.Panels
{
    public partial class EntityPanel : UserControl
    {
        public string Id { get; init; }

        public EntityPanel()
        {
            InitializeComponent();
        }
    }
}
