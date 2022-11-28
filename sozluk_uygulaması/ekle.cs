using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sozluk_uygulaması
{
    public partial class ekle : Form
    {
        public ekle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Database db = new Database();
                db.KomutCalistir($"Insert ınto kelimeler values('{textBox_turkce.Text}','{textBox_ingilizce.Text}')");
                MessageBox.Show("Kayıt Başarılı");
                textBox_turkce.Clear();
                textBox_ingilizce.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

    }
}
