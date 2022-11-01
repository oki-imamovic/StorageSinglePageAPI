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
    public partial class Form1 : Form
    {
        MySqlConnection konekcija = new MySqlConnection("server=localhost;user id=root;database=mydbb;password=Zastita3211!");

        public Form1()
        {
            InitializeComponent();
            ciitajcombo();
            ciitajcomboo();
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void button3_Click(object sender, EventArgs e) // Osvježi Materijal
        {
            konekcija.Open();
            // OleDbCommand komanda = new OleDbCommand();
            MySqlCommand komanda = new MySqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandType = CommandType.Text;
            komanda.CommandText = " select naziv_materijala, kolicina_materijala, mjerna_jedinica, sifra_materijala from materijal ";
            komanda.ExecuteNonQuery();
            DataTable dt = new DataTable();
            //OleDbDataAdapter da = new OleDbDataAdapter(komanda);
            MySqlDataAdapter da = new MySqlDataAdapter(komanda);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            konekcija.Close();
        }

        private void button6_Click(object sender, EventArgs e) // Osvježi Artikle
        {
            konekcija.Open();
            // OleDbCommand komanda = new OleDbCommand();
            MySqlCommand komanda = new MySqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandType = CommandType.Text;
            komanda.CommandText = " select naziv_artikla, datum, sifra_artikl from artikl ";
            komanda.ExecuteNonQuery();
            DataTable dt = new DataTable();
            //OleDbDataAdapter da = new OleDbDataAdapter(komanda);
            MySqlDataAdapter da = new MySqlDataAdapter(komanda);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            konekcija.Close();
        }

        private void button12_Click(object sender, EventArgs e) // Osvježi Skart
        {
            konekcija.Open();
            // OleDbCommand komanda = new OleDbCommand();
            MySqlCommand komanda = new MySqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandType = CommandType.Text;
            komanda.CommandText = " SELECT naziv_materijala, s.kolicina_skarta, mjerna_jedinica, sifra_materijala FROM skart AS s INNER JOIN materijal AS m ON s.materijal_idmaterijal = m.idmaterijal ";
            komanda.ExecuteNonQuery();
            DataTable dt = new DataTable();
            //OleDbDataAdapter da = new OleDbDataAdapter(komanda);
            MySqlDataAdapter da = new MySqlDataAdapter(komanda);
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            konekcija.Close(); 
        }

        private void button4_Click(object sender, EventArgs e) // Snimi Materijal
        {
            konekcija.Open();
            //OleDbCommand komanda = new OleDbCommand();
            MySqlCommand komanda = new MySqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandType = CommandType.Text;
            komanda.CommandText = "insert into materijal (sifra_materijala,naziv_materijala,kolicina_materijala,mjerna_jedinica)values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "') ";
            komanda.ExecuteNonQuery();
            konekcija.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            MessageBox.Show("Uspjesno ste dodali materijal u bazu");
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

        private void button9_Click_1(object sender, EventArgs e)
        {
            Form2 myForm;
            myForm = new Form2();
            myForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e) // Snimi Artikl
        {
            konekcija.Open();
            //OleDbCommand komanda = new OleDbCommand();
            MySqlCommand komanda = new MySqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandType = CommandType.Text;
            komanda.CommandText = "insert into artikl (sifra_artikl,naziv_artikla,datum)values ('" + textBox5.Text + "','" + textBox6.Text + "','" + dateTimePicker1.Text + "') ";
            komanda.ExecuteNonQuery();
            konekcija.Close();
            textBox5.Text = "";
            textBox6.Text = "";
            MessageBox.Show("Uspjesno ste dodali Proizvod u bazu");
        }

        private void button1_Click(object sender, EventArgs e) // Izbriši Materijal
        {
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(rowIndex);
                konekcija.Open();
                MySqlCommand komanda = new MySqlCommand();
                komanda.Connection = konekcija;
                komanda.CommandType = CommandType.Text;
                komanda.CommandText = "delete from materijal where sifra_materijala='" + textBox1.Text + "'";
                komanda.ExecuteNonQuery();
                konekcija.Close();
                textBox1.Text = "";
                MessageBox.Show("Uspjesno ste izbrisali Materijal iz baze");
            }
        }

        private void button8_Click(object sender, EventArgs e) // Izbriši Artikl
        {
            {
                int rowIndex = dataGridView2.CurrentCell.RowIndex;
                dataGridView2.Rows.RemoveAt(rowIndex);
                konekcija.Open();
                MySqlCommand komanda = new MySqlCommand();
                komanda.Connection = konekcija;
                komanda.CommandType = CommandType.Text;
                komanda.CommandText = "delete from artikl where sifra_artikl='" + textBox5.Text + "'";
                komanda.ExecuteNonQuery();
                konekcija.Close();
                textBox5.Text = "";
                MessageBox.Show("Uspjesno ste izbrisali Proizvod iz baze");
            }
        }

        private void button2_Click(object sender, EventArgs e) // Uredi Materijal 
        {
            konekcija.Open();
            //OleDbCommand komanda = new OleDbCommand();
            MySqlCommand komanda = new MySqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandType = CommandType.Text;
            komanda.CommandText = "UPDATE materijal SET kolicina_materijala = '" + textBox3.Text + "' WHERE sifra_materijala = '" + textBox1.Text + "'";
            komanda.ExecuteNonQuery();
            konekcija.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            MessageBox.Show("Uspjesno ste uredili izabrani Materijal");
        }

        private void button13_Click(object sender, EventArgs e) // Snimanje Skarta I Update materijal tabele
        {
            konekcija.Open();
            //OleDbCommand komanda = new OleDbCommand();
            MySqlCommand komanda = new MySqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandType = CommandType.Text; 
            komanda.CommandText = "UPDATE materijal SET kolicina_materijala = kolicina_materijala - '" + textBox7.Text + "' WHERE naziv_materijala = '" + comboBox1.Text + "' AND kolicina_materijala >= '" + textBox7.Text + "'";
            komanda.ExecuteNonQuery();
            MySqlCommand komanda1 = new MySqlCommand();
            komanda1.Connection = konekcija;
            komanda1.CommandType = CommandType.Text;
            komanda1.CommandText = "INSERT INTO skart (materijal_idmaterijal, kolicina_skarta) values('" + comboBox1.SelectedValue + "' ,'" + textBox7.Text + "')";
            komanda1.ExecuteNonQuery();
            konekcija.Close();
            comboBox1.Text = "";
            textBox7.Text = "";
            MessageBox.Show("Uspjesno ste unijeli izabrani Škart");
        }

        private void button10_Click(object sender, EventArgs e) // Brisanje Skarta
        {
            int rowIndex = dataGridView3.CurrentCell.RowIndex;
            dataGridView3.Rows.RemoveAt(rowIndex);
            konekcija.Open();
            MySqlCommand komanda = new MySqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandType = CommandType.Text;
            komanda.CommandText = "DELETE from skart WHERE materijal_idmaterijal='" + comboBox1.SelectedValue + "'";
            komanda.ExecuteNonQuery();
            konekcija.Close();
            comboBox1.Text = "";
            MessageBox.Show("Uspjesno ste izbrisali Skart iz baze");
        }

        private void button7_Click(object sender, EventArgs e) // Uredi Artikl
        {
            konekcija.Open();
            //OleDbCommand komanda = new OleDbCommand();
            MySqlCommand komanda = new MySqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandType = CommandType.Text;
            komanda.CommandText = "UPDATE artikl SET naziv_artikla = '" + textBox6.Text + "' WHERE sifra_artikl = '" + textBox5.Text + "'";
            komanda.ExecuteNonQuery();
            konekcija.Close();
            textBox6.Text = "";
            textBox5.Text = "";
            MessageBox.Show("Uspjesno ste uredili izabrani Artikl");
        }


        private void button14_Click(object sender, EventArgs e) // Osvježi Artikli sa Materijalima
        {
            konekcija.Open();
            // OleDbCommand komanda = new OleDbCommand();
            MySqlCommand komanda = new MySqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandType = CommandType.Text;
            komanda.CommandText = "SELECT naziv_artikla, datum, sifra_artikl, naziv_materijala, kolicina, mjerna_jedinica, sifra_materijala FROM artikl_has_materijal as ahm INNER JOIN artikl AS a ON  ahm.artikl_idartikl = a.idartikl INNER JOIN materijal AS m ON ahm.materijal_idmaterijal = m.idmaterijal";
            komanda.ExecuteNonQuery();
            DataTable dt = new DataTable();
            //OleDbDataAdapter da = new OleDbDataAdapter(komanda);
            MySqlDataAdapter da = new MySqlDataAdapter(komanda);
            da.Fill(dt);
            dataGridView4.DataSource = dt;
            konekcija.Close();
        }

        private void button17_Click(object sender, EventArgs e) // Izbriši artikl sa materijalom
        {
            int rowIndex = dataGridView4.CurrentCell.RowIndex;
            dataGridView4.Rows.RemoveAt(rowIndex);
            konekcija.Open();
            MySqlCommand komanda = new MySqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandType = CommandType.Text;
            komanda.CommandText = "DELETE from artikl_has_materijal WHERE artikl_idartikl ='" + comboBox2.SelectedValue + "'";
            komanda.ExecuteNonQuery();
            konekcija.Close();
            comboBox1.Text = "";
            MessageBox.Show("Uspjesno ste izbrisali Artikl sa Materijalima iz baze");
        }

    }
}
