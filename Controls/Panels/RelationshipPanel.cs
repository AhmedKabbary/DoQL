using System;
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
    public partial class RelationshipPanel : UserControl
    {
        public RelationshipPanel()
        {
            InitializeComponent();
        }
        /*public void CalculateCardinality()
        {
            foreach (var item in Controls)
            {
                if (item is AttachedAttribute attachedAttribute)
                {
                    if (attachedAttribute.GetCardinality() == "M")
                    {
                        TblNameLbl.Visible = true;
                        TableName.Visible = true;
                    }
                    else
                    {
                        TblNameLbl.Visible = false;
                        TableName.Visible = false;
                    }
                }

            }
        }*/
    }
}
