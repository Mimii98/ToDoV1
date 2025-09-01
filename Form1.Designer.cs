namespace To_Do_Liste
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListBox = new CheckedListBox();
            TxtBox = new TextBox();
            BtnSave = new Button();
            BtnDel = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // ListBox
            // 
            ListBox.FormattingEnabled = true;
            ListBox.Location = new Point(390, 68);
            ListBox.Name = "ListBox";
            ListBox.Size = new Size(306, 378);
            ListBox.TabIndex = 0;
            ListBox.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // TxtBox
            // 
            TxtBox.Location = new Point(22, 68);
            TxtBox.Name = "TxtBox";
            TxtBox.Size = new Size(342, 27);
            TxtBox.TabIndex = 1;
            TxtBox.TextChanged += textBox1_TextChanged;
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(12, 268);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(154, 66);
            BtnSave.TabIndex = 2;
            BtnSave.Text = "Speichern";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += button1_Click;
            // 
            // BtnDel
            // 
            BtnDel.Location = new Point(210, 268);
            BtnDel.Name = "BtnDel";
            BtnDel.Size = new Size(154, 65);
            BtnDel.TabIndex = 3;
            BtnDel.Text = "Löschen";
            BtnDel.UseVisualStyleBackColor = true;
            BtnDel.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(390, 34);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 4;
            label1.Text = "To-Do´s";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(735, 458);
            Controls.Add(label1);
            Controls.Add(BtnDel);
            Controls.Add(BtnSave);
            Controls.Add(TxtBox);
            Controls.Add(ListBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox ListBox;
        private TextBox TxtBox;
        private Button BtnSave;
        private Button BtnDel;
        private Label label1;
    }
}
