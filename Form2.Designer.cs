namespace WinFormWebtoon
{
    partial class Form2
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnTextBoxClear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.standard = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.day = new System.Windows.Forms.ComboBox();
            this.writer = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.genre = new System.Windows.Forms.ComboBox();
            this.no = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnInsert.Location = new System.Drawing.Point(350, 97);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(214, 32);
            this.btnInsert.TabIndex = 2;
            this.btnInsert.Text = "입력";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnUpdate.Location = new System.Drawing.Point(350, 178);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(214, 32);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "수정";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDelete.Location = new System.Drawing.Point(350, 258);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(214, 32);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnTextBoxClear
            // 
            this.btnTextBoxClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnTextBoxClear.Location = new System.Drawing.Point(350, 338);
            this.btnTextBoxClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTextBoxClear.Name = "btnTextBoxClear";
            this.btnTextBoxClear.Size = new System.Drawing.Size(214, 32);
            this.btnTextBoxClear.TabIndex = 6;
            this.btnTextBoxClear.Text = "비우기";
            this.btnTextBoxClear.UseVisualStyleBackColor = true;
            this.btnTextBoxClear.Click += new System.EventHandler(this.btnTextBoxClear_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(152, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(297, 39);
            this.label5.TabIndex = 7;
            this.label5.Text = "인터넷 웹툰 관리 시스템";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.description);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.no);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.standard);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.day);
            this.groupBox1.Controls.Add(this.writer);
            this.groupBox1.Controls.Add(this.name);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.genre);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 339);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "웹툰관리";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("나눔고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(28, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "등급";
            // 
            // standard
            // 
            this.standard.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.standard.FormattingEnabled = true;
            this.standard.Location = new System.Drawing.Point(96, 290);
            this.standard.Name = "standard";
            this.standard.Size = new System.Drawing.Size(151, 31);
            this.standard.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(28, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "요일";
            // 
            // day
            // 
            this.day.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.day.FormattingEnabled = true;
            this.day.Location = new System.Drawing.Point(96, 210);
            this.day.Name = "day";
            this.day.Size = new System.Drawing.Size(151, 31);
            this.day.TabIndex = 7;
            // 
            // writer
            // 
            this.writer.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.writer.Location = new System.Drawing.Point(96, 130);
            this.writer.Name = "writer";
            this.writer.Size = new System.Drawing.Size(151, 30);
            this.writer.TabIndex = 6;
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.name.Location = new System.Drawing.Point(96, 90);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(151, 30);
            this.name.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(28, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "작가";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(28, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "장르";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(28, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "제목";
            // 
            // genre
            // 
            this.genre.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.genre.FormattingEnabled = true;
            this.genre.Location = new System.Drawing.Point(96, 251);
            this.genre.Name = "genre";
            this.genre.Size = new System.Drawing.Size(151, 31);
            this.genre.TabIndex = 1;
            // 
            // no
            // 
            this.no.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.no.Location = new System.Drawing.Point(96, 49);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(151, 30);
            this.no.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("나눔고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(28, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 21);
            this.label7.TabIndex = 11;
            this.label7.Text = "번호";
            // 
            // description
            // 
            this.description.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.description.Location = new System.Drawing.Point(96, 170);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(151, 30);
            this.description.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("나눔고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(28, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 21);
            this.label8.TabIndex = 13;
            this.label8.Text = "설명";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 400);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnTextBoxClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form2";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnTextBoxClear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox standard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox day;
        private System.Windows.Forms.TextBox writer;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox genre;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox no;
        private System.Windows.Forms.Label label7;
    }
}