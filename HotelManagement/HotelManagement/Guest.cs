using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
	public partial class Guest : Form
	{
		public Guest()
		{
			InitializeComponent();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=HotelDB;Integrated Security=true;TrustServerCertificate=true");


			con.Open();

			SqlCommand cnn = new SqlCommand("insert into guest Values(@guestid,@firstname,@lastname,@email,@phone)", con);

			cnn.Parameters.AddWithValue("@guestid", int.Parse(textBox2.Text));
			cnn.Parameters.AddWithValue("@firstname", textBox2.Text);
			cnn.Parameters.AddWithValue("@lastname", textBox3.Text);
			cnn.Parameters.AddWithValue("@email", textBox4.Text);
			cnn.Parameters.AddWithValue("@phone", textBox5.Text);
			cnn.ExecuteNonQuery();
			con.Close();
			MessageBox.Show("Record Saved");
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=HotelDB;Integrated Security=true;TrustServerCertificate=true");


			con.Open();

			SqlCommand cnn = new SqlCommand("Select * from guests", con);
			
			SqlDataAdapter da = new SqlDataAdapter();
			DataTable table = new DataTable();
			da.Fill(table);

			dataGridView1.DataSource = table;

		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=HotelDB;Integrated Security=true;TrustServerCertificate=true");


			con.Open();

			SqlCommand cnn = new SqlCommand("update guests set firstname=@firstname,lastname=@lastname,email=@email,phone=@phone where guestid=@guestid", con);

			cnn.Parameters.AddWithValue("@guestid", int.Parse(textBox2.Text));
			cnn.Parameters.AddWithValue("@firstname", textBox2.Text);
			cnn.Parameters.AddWithValue("@lastname", textBox3.Text);
			cnn.Parameters.AddWithValue("@email", textBox4.Text);
			cnn.Parameters.AddWithValue("@phone", textBox5.Text);
			cnn.ExecuteNonQuery();
			con.Close();
			MessageBox.Show("Record Updated");
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=HotelDB;Integrated Security=true;TrustServerCertificate=true");


			con.Open();

			SqlCommand cnn = new SqlCommand("delete guests where guestid=@guestid", con);

			cnn.Parameters.AddWithValue("@guestid", int.Parse(textBox2.Text));

			cnn.ExecuteNonQuery();
			con.Close();
			MessageBox.Show("Record Deleted");
		}

		private void Guest_Load(object sender, EventArgs e)
		{
			SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=HotelDB;Integrated Security=true;TrustServerCertificate=true");


			con.Open();

			SqlCommand cnn = new SqlCommand("Select * from guests", con);
			
			SqlDataAdapter da = new SqlDataAdapter();
			DataTable table = new DataTable();
			da.Fill(table);

			dataGridView1.DataSource = table;
		}
	}
}
