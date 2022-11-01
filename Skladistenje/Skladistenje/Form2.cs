using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Skladistenje
{
    public partial class Form2 : Form
    {

        MySqlConnection konekcija = new MySqlConnection("server=localhost;user id=root;database=mydbb;password=Zastita3211!");

        public Form2()
        {
            InitializeComponent();
            ciitajcombo();
            ciitajcomboo();
        }

        void ciitajcombo() // Combo Box Ispisivanje Materijala
        {
            MySqlConnection konekcija = new MySqlConnection();
            konekcija.ConnectionString = "server=localhost;user id=root;database=mydbb ;password=Zastita3211!";
            konekcija.Open();
            MySqlCommand komanda = new MySqlCommand("SELECT * from materijal", konekcija);
            MySqlDataReader reader;
            reader = komanda.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("naziv_materijala", typeof(string));
            dt.Columns.Add("idmaterijal", typeof(int));
            dt.Load(reader);
            comboBox1.DisplayMember = "naziv_materijala";
            comboBox1.ValueMember = "idmaterijal";
            comboBox1.DataSource = dt;
            konekcija.Close();
        }

        void ciitajcomboo() // Combo Box Ispisivanje Artikla
        {
            MySqlConnection konekcija = new MySqlConnection();
            konekcija.ConnectionString = "server=localhost;user id=root;database=mydbb ;password=Zastita3211!";
            konekcija.Open();
            MySqlCommand komanda = new MySqlCommand("SELECT * from artikl", konekcija);
            MySqlDataReader reader;
            reader = komanda.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("naziv_artikla", typeof(string));
            dt.Columns.Add("idartikl", typeof(int));
            dt.Load(reader);
            comboBox2.DisplayMember = "naziv_artikla";
            comboBox2.ValueMember = "idartikl";
            comboBox2.DataSource = dt;
            konekcija.Close();
        }

        private void button1_Click(object sender, EventArgs e) // Dodavanje materijala artiklima
        {
            konekcija.Open();
            //OleDbCommand komanda = new OleDbCommand();
            MySqlCommand komanda = new MySqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandType = CommandType.Text;
            komanda.CommandText = "UPDATE materijal SET kolicina_materijala = kolicina_materijala - '" + textBox1.Text + "' WHERE naziv_materijala = '" + comboBox1.Text + "' AND kolicina_materijala >= '" + textBox1.Text + "'";
            komanda.ExecuteNonQuery();
            MySqlCommand komanda1 = new MySqlCommand();
            komanda1.Connection = konekcija;
            komanda1.CommandType = CommandType.Text;
            komanda1.CommandText = "INSERT INTO artikl_has_materijal (artikl_idartikl, materijal_idmaterijal, kolicina) values('" + comboBox2.SelectedValue + "' ,'" + comboBox1.SelectedValue + "' ,'" + textBox1.Text + "')";
            komanda1.ExecuteNonQuery();
            konekcija.Close();
            comboBox2.Text = "";
            comboBox1.Text = "";
            textBox1.Text = "";
            MessageBox.Show("Uspjesno ste unijeli izabrani Materijal u željeni Artikal");
        }
    }
}
