using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace WinFormWebtoon
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        MySqlDataAdapter dataAdapter;
        DataSet dataSet;
        int selectedRowIndex;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connStr = "server=localhost;port=3306;database=cswebtoon;uid=root;pwd=kkgyrm";
            conn = new MySqlConnection(connStr);
            dataAdapter = new MySqlDataAdapter("SELECT * FROM webtoon", conn);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "webtoon");
            dataGridView1.DataSource = dataSet.Tables["webtoon"];

            SetComboBox();
        }
        #region ComboBox 세팅
        // **** 검색 조건 목록 세팅 ****
        private void SetComboBox()
        {
            string sql = "SELECT distinct genre_name FROM genre";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                // genre_name 목록 표시
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                CBGenre.Items.Clear();
                CBRank.Items.Clear();

                while (reader.Read())  // 다음 레코드가 있으면 true
                {
                    CBGenre.Items.Add(reader.GetString("genre_name"));
                }
                reader.Close();

                // 등급 목록 표시
                sql = "SELECT distinct use_standard FROM wt_use_rank";
                cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())  // 다음 레코드가 있으면 true
                {
                    CBRank.Items.Add(reader.GetString("use_standard"));
                }
                reader.Close();

                CBDate.Items.Add("MON");
                CBDate.Items.Add("TUE");
                CBDate.Items.Add("WED");
                CBDate.Items.Add("THU");
                CBDate.Items.Add("FRI");
                CBDate.Items.Add("SAT");
                CBDate.Items.Add("SUN");
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
        #endregion
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage1"])
            {
                dataAdapter = new MySqlDataAdapter("SELECT * FROM webtoon", conn);
                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "webtoon");
                dataGridView1.DataSource = dataSet.Tables["webtoon"];

            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage2"])
            {
                dataAdapter = new MySqlDataAdapter("SELECT * FROM genre", conn);
                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "genre");
                dataGridView2.DataSource = dataSet.Tables["genre"];

            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage3"])
            {
                dataAdapter = new MySqlDataAdapter("SELECT * FROM wt_use_rank", conn);
                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "wt_use_rank");
                dataGridView3.DataSource = dataSet.Tables["wt_use_rank"];

            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string queryStr;

            #region Select QueryString Create
            string[] conditions = new string[5];
            conditions[0] = (TBTitle.Text != "") ? "wt_name=@wt_name" : null;
            conditions[1] = (TBWriter.Text != "") ? "writer_name=@writer_name" : null;
            conditions[2] = (CBGenre.Text != "") ? "genre_name=@genre_name" : null;
            conditions[3] = (CBDate.Text != "") ? "wt_update_day=@wt_update_day" : null;
            conditions[4] = (CBRank.Text != "") ? "use_standard=@use_standard" : null;

            //Select QueryString 만들기
            if (conditions[0] != null || conditions[1] != null || conditions[2] != null || conditions[3] != null || conditions[4] != null)
            {
                queryStr = $"SELECT * FROM webtoon WHERE ";
                bool firstCondition = true;
                for (int i = 0; i < conditions.Length; i++)
                {
                    if (conditions[i] != null)
                        if (firstCondition)
                        {
                            queryStr += conditions[i];
                            firstCondition = false;
                        }
                        else
                        {
                            queryStr += " and " + conditions[i];
                        }
                }
            }
            else
            {
                queryStr = "SELECT * FROM webtoon";
            }
            #endregion

            #region SelectCommand 객체 생성 및 Parameters 설정
            dataAdapter.SelectCommand = new MySqlCommand(queryStr, conn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@wt_name", TBTitle.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@writer_name", TBWriter.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@genre_name", CBGenre.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@wt_update_day", CBDate.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@use_standard", CBRank.Text);
            #endregion

            try
            {
                conn.Open();
                dataSet.Clear();
                if (dataAdapter.Fill(dataSet, "webtoon") > 0)
                    dataGridView1.DataSource = dataSet.Tables["webtoon"];
                else
                    MessageBox.Show("찾는 데이터가 없습니다.");
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
        private void btnClear_Click(object sender, EventArgs e)
        {
            TBTitle.Clear();
            TBWriter.Clear();
            CBGenre.Text = "";
            CBDate.Text = "";
            CBRank.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRowIndex = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[selectedRowIndex];

                // 새로운 폼에 선택된 row의 정보를 담아서 생성
                Form2 Dig = new Form2(
                    selectedRowIndex,
                    int.Parse(row.Cells[0].Value.ToString()),
                    row.Cells[1].Value.ToString(),
                    row.Cells[2].Value.ToString(),
                    row.Cells[3].Value.ToString(),
                    row.Cells[4].Value.ToString(),
                    row.Cells[5].Value.ToString(),
                    row.Cells[6].Value.ToString()
                    );

                Dig.Owner = this;               // 새로운 폼의 부모가 Form1 인스턴스임을 지정
                Dig.ShowDialog();               // 폼 띄우기(Modal)
                Dig.Dispose();
            }
            catch (Exception)
            {
            }
        }

        // **** Insert SQL 실행 ****
        public void InsertRow(string[] rowDatas)
        {
            string queryStr = "INSERT INTO webtoon (wt_no, wt_name, writer_name, wt_description, wt_update_day, genre_name, use_standard) " +
                "VALUES(@wt_no, @wt_name, @writer_name, @wt_description, @wt_update_day, @genre_name, @use_standard)";
            dataAdapter.InsertCommand = new MySqlCommand(queryStr, conn);
            dataAdapter.InsertCommand.Parameters.Add("@wt_no", MySqlDbType.Int32);
            dataAdapter.InsertCommand.Parameters.Add("@wt_name", MySqlDbType.VarChar);
            dataAdapter.InsertCommand.Parameters.Add("@writer_name", MySqlDbType.VarChar);
            dataAdapter.InsertCommand.Parameters.Add("@wt_description", MySqlDbType.VarChar);
            dataAdapter.InsertCommand.Parameters.Add("@wt_update_day", MySqlDbType.VarChar);
            dataAdapter.InsertCommand.Parameters.Add("@genre_name", MySqlDbType.VarChar);
            dataAdapter.InsertCommand.Parameters.Add("@use_standard", MySqlDbType.VarChar);

            #region Parameter를 이용한 처리
            dataAdapter.InsertCommand.Parameters["@wt_no"].Value = rowDatas[0];
            dataAdapter.InsertCommand.Parameters["@wt_name"].Value = rowDatas[1];
            dataAdapter.InsertCommand.Parameters["@writer_name"].Value = rowDatas[2];
            dataAdapter.InsertCommand.Parameters["@wt_description"].Value = rowDatas[3];
            dataAdapter.InsertCommand.Parameters["@wt_update_day"].Value = rowDatas[4];
            dataAdapter.InsertCommand.Parameters["@genre_name"].Value = rowDatas[5];
            dataAdapter.InsertCommand.Parameters["@use_standard"].Value = rowDatas[6];

            try
            {
                conn.Open();
                dataAdapter.InsertCommand.ExecuteNonQuery();

                dataSet.Clear();                                        // 이전 데이터 지우기
                dataAdapter.Fill(dataSet, "webtoon");                      // DB -> DataSet
                dataGridView1.DataSource = dataSet.Tables["webtoon"];      // dataGridView에 테이블 표시  


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            #endregion
        }

        // **** Delete SQL 실행 ****
        internal void DeleteRow(int wt_no)
        {
            string sql = "DELETE FROM webtoon WHERE wt_no=@wt_no";
            dataAdapter.DeleteCommand = new MySqlCommand(sql, conn);
            dataAdapter.DeleteCommand.Parameters.AddWithValue("@wt_no", wt_no);

            try
            {
                conn.Open();
                dataAdapter.DeleteCommand.ExecuteNonQuery();

                dataSet.Clear();
                dataAdapter.Fill(dataSet, "webtoon");
                dataGridView1.DataSource = dataSet.Tables["webtoon"];
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

        // **** Update SQL 실행 ****
        internal void UpdateRow(string[] rowDatas)
        {
            string sql = "UPDATE webtoon SET wt_name=@wt_name, writer_name=@writer_name, wt_description=@wt_description, wt_update_day=@wt_update_day, genre_name=@genre_name,  use_standard=@use_standard WHERE wt_no=@wt_no";
            dataAdapter.UpdateCommand = new MySqlCommand(sql, conn);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@wt_no", rowDatas[0]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@wt_name", rowDatas[1]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@writer_name", rowDatas[2]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@wt_description", rowDatas[3]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@wt_update_day", rowDatas[4]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@genre_name", rowDatas[5]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@use_standard", rowDatas[6]);

            try
            {
                conn.Open();
                dataAdapter.UpdateCommand.ExecuteNonQuery();

                dataSet.Clear();  // 이전 데이터 지우기
                dataAdapter.Fill(dataSet, "webtoon");
                dataGridView1.DataSource = dataSet.Tables["webtoon"];
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

        // **** Insert 버튼 클릭(새창 띄우기) ****
        private void btnCare_Click(object sender, EventArgs e)
        {
            Form2 Dig = new Form2();
            Dig.Owner = this;               // 새로운 폼의 부모가 Form1 인스턴스임을 지정
            Dig.ShowDialog();               // 폼 띄우기(Modal)
            Dig.Dispose();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (rbExcel.Checked || rbText.Checked)
            {
                if (dataGridView1.RowCount == 0)
                {
                    MessageBox.Show("저장할 데이터가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (rbText.Checked)
                {
                    saveFileDialog1.Filter = "텍스트 파일(*.txt)|*.txt";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        SaveTxtFile(saveFileDialog1.FileName);
                    }
                }
                else
                {
                    saveFileDialog1.Filter = "엑셀 파일(*.xlsx)|*.xlsx";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        SaveExcelFile(saveFileDialog1.FileName);
                    }
                }
            }
            else
            {
                MessageBox.Show("저장할 형식을 지정해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveTxtFile(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {

                foreach (DataColumn col in dataSet.Tables["webtoon"].Columns)
                {
                    sw.Write($"{col.ColumnName}\t");
                }
                sw.WriteLine();

                foreach (DataRow row in dataSet.Tables["webtoon"].Rows)
                {
                    string rowString = "";
                    foreach (var item in row.ItemArray)
                    {
                        rowString += $"{item}\t";
                    }
                    sw.WriteLine(rowString);
                }
            }
        }

        private void SaveExcelFile(string filePath)
        {

            Excel.Application eApp;
            Excel.Workbook eWorkbook;
            Excel.Worksheet eWorkSheet;

            eApp = new Excel.Application();
            eWorkbook = eApp.Workbooks.Add();
            eWorkSheet = eWorkbook.Sheets[1];


            int colCount = dataSet.Tables["webtoon"].Columns.Count;
            int rowCount = dataSet.Tables["webtoon"].Rows.Count + 1;
            string[,] dataArr = new string[rowCount, colCount];


            for (int i = 0; i < dataSet.Tables["webtoon"].Columns.Count; i++)
            {
                dataArr[0, i] = dataSet.Tables["webtoon"].Columns[i].ColumnName;
            }

            for (int i = 0; i < dataSet.Tables["webtoon"].Rows.Count; i++)
            {
                for (int j = 0; j < dataSet.Tables["webtoon"].Columns.Count; j++)
                {
                    dataArr[i + 1, j] = dataSet.Tables["webtoon"].Rows[i].ItemArray[j].ToString();
                }
            }

            string endCell = Convert.ToChar(65 + dataSet.Tables["webtoon"].Columns.Count - 1).ToString() + rowCount.ToString();
            eWorkSheet.get_Range($"A1:{endCell}").Value = dataArr;

            eWorkbook.SaveAs(filePath, Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                false, false, Excel.XlSaveAsAccessMode.xlShared, false, false, Type.Missing, Type.Missing,
                Type.Missing);
            eWorkbook.Close(false, Type.Missing, Type.Missing);
            eApp.Quit();
        }
    }
}
    
