using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormWebtoon
{
    public partial class Form2 : Form
    {

        private int wt_no;
        private string wt_name, writer_name, wt_description, wt_update_day, genre_name, use_standard;
        private int selectedRowIndex;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(int selectedRowIndex, int v1, string v2, string v3, string v4, string v5, string v6, string v7)
        {
            InitializeComponent();
            this.selectedRowIndex = selectedRowIndex;
            this.wt_no = v1;
            this.wt_name = v2;
            this.writer_name = v3;
            this.wt_description = v4;
            this.wt_update_day = v5;
            this.genre_name = v6;
            this.use_standard = v7;

        }

        Form1 mainForm;
        private void Form2_Load(object sender, EventArgs e)
        {
            if (wt_no.ToString() != "0") no.Text = wt_no.ToString();
            name.Text = wt_name;
            writer.Text = writer_name;
            description.Text = wt_description;
            day.Text = wt_update_day;
            genre.Text = genre_name;
            standard.Text = use_standard;

            if (Owner != null)
            {
                mainForm = Owner as Form1;
            }
            SetComboBox();

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (no.Text == "" || name.Text == "" || day.Text == "" || standard.Text == "")
            {
                MessageBox.Show("번호, 제목, 요일, 등급를 전부 입력하세요.");
            }
            else
            {
                string[] rowDatas = {
                no.Text,
                name.Text,
                writer.Text,
                description.Text,
                day.Text,
                genre.Text,
                standard.Text
            };
                mainForm.InsertRow(rowDatas);
                this.Close();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (no.Text == "" || name.Text == "" || day.Text == "" || standard.Text == "")
            {

                MessageBox.Show("제목, 요일, 등급를 전부 입력하세요");

            }
            else
            {
                string[] rowDatas = {
                no.Text,
                name.Text,
                writer.Text,
                description.Text,
                day.Text,
                genre.Text,
                standard.Text};
                mainForm.UpdateRow(rowDatas);
                this.Close();
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            mainForm.DeleteRow(wt_no);
            this.Close();
        }

       
        private void btnTextBoxClear_Click(object sender, EventArgs e)
        {
            no.Clear();
            name.Clear();
            writer.Clear();
            description.Clear();
            day.Text = "";
            genre.Text = "";
            standard.Text = "";
        }
        private void SetComboBox()
        {
            MySqlConnection conn;
            string connStr = "server=localhost;port=3306;database=cswebtoon;uid=root;pwd=kkgyrm";
            conn = new MySqlConnection(connStr);
            string sql = "SELECT distinct genre_name FROM genre";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                // genre_name 목록 표시
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                genre.Items.Clear();
                genre.Items.Clear();

                while (reader.Read())  // 다음 레코드가 있으면 true
                {
                    genre.Items.Add(reader.GetString("genre_name"));
                }
                reader.Close();

                // 등급 목록 표시
                sql = "SELECT distinct use_standard FROM wt_use_rank";
                cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())  // 다음 레코드가 있으면 true
                {
                    standard.Items.Add(reader.GetString("use_standard"));
                }
                reader.Close();

                day.Items.Add("MON");
                day.Items.Add("TUE");
                day.Items.Add("WED");
                day.Items.Add("THU");
                day.Items.Add("FRI");
                day.Items.Add("SAT");
                day.Items.Add("SUN");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
