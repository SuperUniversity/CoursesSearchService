﻿namespace WindowsFormsTest
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.Find = new System.Windows.Forms.Button();
            this.GetAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(246, 56);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ntu Check Duplicate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(36, 131);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(246, 56);
            this.button2.TabIndex = 1;
            this.button2.Text = "Success Check Duplicate";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(36, 215);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(246, 56);
            this.button3.TabIndex = 2;
            this.button3.Text = "Ntpu Check Duplicate";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(341, 215);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(246, 56);
            this.button4.TabIndex = 3;
            this.button4.Text = "Ntpu Advance Check Duplicate";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(341, 131);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(246, 56);
            this.button5.TabIndex = 4;
            this.button5.Text = "Success Advance Check Duplicate";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(341, 54);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(246, 56);
            this.button6.TabIndex = 5;
            this.button6.Text = "Ntu Advance Check Duplicate";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Find
            // 
            this.Find.Location = new System.Drawing.Point(36, 349);
            this.Find.Name = "Find";
            this.Find.Size = new System.Drawing.Size(246, 56);
            this.Find.TabIndex = 6;
            this.Find.Text = "Test Find Method";
            this.Find.UseVisualStyleBackColor = true;
            this.Find.Click += new System.EventHandler(this.Find_Click);
            // 
            // GetAll
            // 
            this.GetAll.Location = new System.Drawing.Point(341, 349);
            this.GetAll.Name = "GetAll";
            this.GetAll.Size = new System.Drawing.Size(246, 56);
            this.GetAll.TabIndex = 7;
            this.GetAll.Text = "Test Find Method(Get All)";
            this.GetAll.UseVisualStyleBackColor = true;
            this.GetAll.Click += new System.EventHandler(this.GetAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 519);
            this.Controls.Add(this.GetAll);
            this.Controls.Add(this.Find);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button Find;
        private System.Windows.Forms.Button GetAll;
    }
}

