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
    public partial class düzenle : Form
    {
        public düzenle()
        {
            InitializeComponent();
        }
        private int IslemYapilanId = 0;

        private void düzenle_Load(object sender, EventArgs e)
        {
            Database db = new Database();
            dataGridView1.DataSource = db.GetDataTable("select*from kelimeler");
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IslemYapilanId = Convert.ToInt16(dataGridView1[0, e.RowIndex].Value);
            textBox_turkce.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            textBox_ingilizce.Text = dataGridView1[2, e.RowIndex].Value.ToString();

        }

        private void button_kaydet_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Turkce", textBox_turkce.Text);
            parameters.Add("@Ingilizce", textBox_ingilizce.Text);
            parameters.Add("@Id", IslemYapilanId);
            db.KomutCalistir($"update kelime Set Turkce=@Turkce,Ingilizce=@Ingilizce where Id=@Id",parameters);
            
        }

    }
}
