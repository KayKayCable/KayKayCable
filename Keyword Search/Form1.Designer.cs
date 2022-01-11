
namespace Keyword_Search
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.directoryLabel = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.input = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.results = new System.Windows.Forms.ListBox();
            this.clearBtn = new System.Windows.Forms.Button();
            this.reportBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.details = new System.Windows.Forms.RichTextBox();
            this.openDirectory = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // directoryLabel
            // 
            this.directoryLabel.AutoSize = true;
            this.directoryLabel.Location = new System.Drawing.Point(9, 9);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(100, 13);
            this.directoryLabel.TabIndex = 0;
            this.directoryLabel.Text = "Selected Directory: ";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(229, 28);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(121, 23);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(123, 30);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(100, 20);
            this.input.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Input Keyword:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(123, 57);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Exact Match";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(397, 35);
            this.label3.TabIndex = 5;
            this.label3.Text = "WARNING: Must select \"Exact match\". The AI search is incomplete and will hang. ";
            // 
            // results
            // 
            this.results.FormattingEnabled = true;
            this.results.Location = new System.Drawing.Point(16, 128);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(359, 225);
            this.results.TabIndex = 6;
            this.results.SelectedIndexChanged += new System.EventHandler(this.results_SelectedIndexChanged);
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(20, 359);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(112, 34);
            this.clearBtn.TabIndex = 7;
            this.clearBtn.Text = "Clear Results";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // reportBtn
            // 
            this.reportBtn.Location = new System.Drawing.Point(138, 359);
            this.reportBtn.Name = "reportBtn";
            this.reportBtn.Size = new System.Drawing.Size(112, 34);
            this.reportBtn.TabIndex = 8;
            this.reportBtn.Text = "Generate Report";
            this.reportBtn.UseVisualStyleBackColor = true;
            this.reportBtn.Click += new System.EventHandler(this.reportBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(256, 359);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(112, 34);
            this.exitBtn.TabIndex = 9;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // details
            // 
            this.details.Location = new System.Drawing.Point(404, 128);
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(292, 129);
            this.details.TabIndex = 10;
            this.details.Text = "Select an item for more details";
            // 
            // openDirectory
            // 
            this.openDirectory.Location = new System.Drawing.Point(573, 9);
            this.openDirectory.Name = "openDirectory";
            this.openDirectory.Size = new System.Drawing.Size(95, 23);
            this.openDirectory.TabIndex = 11;
            this.openDirectory.Text = "Open Directory";
            this.openDirectory.UseVisualStyleBackColor = true;
            this.openDirectory.Click += new System.EventHandler(this.openDirectory_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 450);
            this.Controls.Add(this.openDirectory);
            this.Controls.Add(this.details);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.reportBtn);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.results);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.input);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.directoryLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label directoryLabel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox results;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button reportBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.RichTextBox details;
        private System.Windows.Forms.Button openDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

