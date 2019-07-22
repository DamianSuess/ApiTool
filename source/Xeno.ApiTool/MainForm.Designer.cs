namespace Xeno.ApiTool
{
  partial class MainForm
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
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.lblWindowParentText = new System.Windows.Forms.Label();
      this.lblWindowClass = new System.Windows.Forms.Label();
      this.lblWindowText = new System.Windows.Forms.Label();
      this.lblWindowHwnd = new System.Windows.Forms.Label();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.lblWindowParentClass = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.lblCursorXY = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.lblWindowPath = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Location = new System.Drawing.Point(12, 12);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(514, 366);
      this.tabControl1.TabIndex = 4;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.groupBox1);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(506, 340);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Window";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.label7);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.lblWindowPath);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.lblCursorXY);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.lblWindowParentClass);
      this.groupBox1.Controls.Add(this.lblWindowParentText);
      this.groupBox1.Controls.Add(this.lblWindowClass);
      this.groupBox1.Controls.Add(this.lblWindowText);
      this.groupBox1.Controls.Add(this.lblWindowHwnd);
      this.groupBox1.Location = new System.Drawing.Point(6, 6);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(494, 150);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Window API Tool";
      // 
      // lblWindowParentText
      // 
      this.lblWindowParentText.AutoSize = true;
      this.lblWindowParentText.Location = new System.Drawing.Point(93, 84);
      this.lblWindowParentText.Name = "lblWindowParentText";
      this.lblWindowParentText.Size = new System.Drawing.Size(67, 13);
      this.lblWindowParentText.TabIndex = 6;
      this.lblWindowParentText.Text = "parent - Text";
      // 
      // lblWindowClass
      // 
      this.lblWindowClass.AutoSize = true;
      this.lblWindowClass.Location = new System.Drawing.Point(93, 71);
      this.lblWindowClass.Name = "lblWindowClass";
      this.lblWindowClass.Size = new System.Drawing.Size(56, 13);
      this.lblWindowClass.TabIndex = 5;
      this.lblWindowClass.Text = "win - class";
      // 
      // lblWindowText
      // 
      this.lblWindowText.AutoSize = true;
      this.lblWindowText.Location = new System.Drawing.Point(93, 58);
      this.lblWindowText.Name = "lblWindowText";
      this.lblWindowText.Size = new System.Drawing.Size(49, 13);
      this.lblWindowText.TabIndex = 4;
      this.lblWindowText.Text = "win - text";
      // 
      // lblWindowHwnd
      // 
      this.lblWindowHwnd.AutoSize = true;
      this.lblWindowHwnd.Location = new System.Drawing.Point(93, 45);
      this.lblWindowHwnd.Name = "lblWindowHwnd";
      this.lblWindowHwnd.Size = new System.Drawing.Size(61, 13);
      this.lblWindowHwnd.TabIndex = 3;
      this.lblWindowHwnd.Text = "win - hWnd";
      // 
      // tabPage2
      // 
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(506, 340);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Hot Keys";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // lblWindowParentClass
      // 
      this.lblWindowParentClass.AutoSize = true;
      this.lblWindowParentClass.Location = new System.Drawing.Point(93, 97);
      this.lblWindowParentClass.Name = "lblWindowParentClass";
      this.lblWindowParentClass.Size = new System.Drawing.Size(65, 13);
      this.lblWindowParentClass.TabIndex = 7;
      this.lblWindowParentClass.Text = "parent Class";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(22, 19);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(40, 13);
      this.label6.TabIndex = 8;
      this.label6.Text = "Cursor:";
      // 
      // lblCursorXY
      // 
      this.lblCursorXY.AutoSize = true;
      this.lblCursorXY.Location = new System.Drawing.Point(93, 19);
      this.lblCursorXY.Name = "lblCursorXY";
      this.lblCursorXY.Size = new System.Drawing.Size(20, 13);
      this.lblCursorXY.TabIndex = 9;
      this.lblCursorXY.Text = "x,y";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(22, 45);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(36, 13);
      this.label1.TabIndex = 10;
      this.label1.Text = "hWnd";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(22, 58);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(31, 13);
      this.label2.TabIndex = 11;
      this.label2.Text = "Text:";
      // 
      // lblWindowPath
      // 
      this.lblWindowPath.AutoSize = true;
      this.lblWindowPath.Location = new System.Drawing.Point(95, 110);
      this.lblWindowPath.Name = "lblWindowPath";
      this.lblWindowPath.Size = new System.Drawing.Size(28, 13);
      this.lblWindowPath.TabIndex = 12;
      this.lblWindowPath.Text = "path";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(22, 71);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(35, 13);
      this.label3.TabIndex = 13;
      this.label3.Text = "Class:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(22, 84);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(65, 13);
      this.label4.TabIndex = 14;
      this.label4.Text = "Parent Text:";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(22, 97);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(69, 13);
      this.label5.TabIndex = 15;
      this.label5.Text = "Parent Class:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(22, 110);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(51, 13);
      this.label7.TabIndex = 16;
      this.label7.Text = "File Path:";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(538, 390);
      this.Controls.Add(this.tabControl1);
      this.Name = "MainForm";
      this.Text = "API Tool";
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label lblWindowClass;
    private System.Windows.Forms.Label lblWindowText;
    private System.Windows.Forms.Label lblWindowHwnd;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.Label lblWindowParentText;
    private System.Windows.Forms.Label lblWindowParentClass;
    private System.Windows.Forms.Label lblCursorXY;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label lblWindowPath;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
  }
}

