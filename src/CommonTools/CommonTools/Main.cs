using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonTools
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var text = rtbText.Text;
                if (string.IsNullOrEmpty(text))
                    return;

                var data = Encoding.ASCII.GetBytes(text);
                rtbEncode.Text = BitConverter.ToString(data).Replace("-", "");
            }
            catch (Exception ex)
            {
                rtbEncode.Text = ex.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var text = rtbEncode.Text;
                if (string.IsNullOrEmpty(text))
                    return;

                var data = text.ToBytes();
                rtbText.Text = Encoding.ASCII.GetString(data);
            }
            catch (Exception ex)
            {
                rtbText.Text = ex.ToString();
            }
        }
    }
}
