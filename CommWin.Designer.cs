namespace Comm
{
	partial class CommWin
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
			this.rtfMain = new System.Windows.Forms.RichTextBox();
			this.txtIn = new System.Windows.Forms.TextBox();
			this.listView1 = new System.Windows.Forms.ListView();
			this.btnConnect = new System.Windows.Forms.Button();
			this.btnListen = new System.Windows.Forms.Button();
			this.btnDiscon = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// rtfMain
			// 
			this.rtfMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtfMain.Location = new System.Drawing.Point(0, 0);
			this.rtfMain.Name = "rtfMain";
			this.rtfMain.ReadOnly = true;
			this.rtfMain.Size = new System.Drawing.Size(449, 457);
			this.rtfMain.TabIndex = 0;
			this.rtfMain.Text = "";
			// 
			// txtIn
			// 
			this.txtIn.AcceptsReturn = true;
			this.txtIn.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.txtIn.Location = new System.Drawing.Point(0, 5);
			this.txtIn.Multiline = true;
			this.txtIn.Name = "txtIn";
			this.txtIn.Size = new System.Drawing.Size(449, 20);
			this.txtIn.TabIndex = 1;
			this.txtIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIn_KeyPress);
			// 
			// listView1
			// 
			this.listView1.Location = new System.Drawing.Point(12, 12);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(156, 97);
			this.listView1.TabIndex = 2;
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(12, 115);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(75, 23);
			this.btnConnect.TabIndex = 3;
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// btnListen
			// 
			this.btnListen.Location = new System.Drawing.Point(93, 115);
			this.btnListen.Name = "btnListen";
			this.btnListen.Size = new System.Drawing.Size(75, 23);
			this.btnListen.TabIndex = 4;
			this.btnListen.Text = "Listen";
			this.btnListen.UseVisualStyleBackColor = true;
			this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
			// 
			// btnDiscon
			// 
			this.btnDiscon.Location = new System.Drawing.Point(12, 144);
			this.btnDiscon.Name = "btnDiscon";
			this.btnDiscon.Size = new System.Drawing.Size(156, 23);
			this.btnDiscon.TabIndex = 5;
			this.btnDiscon.Text = "Disconnect";
			this.btnDiscon.UseVisualStyleBackColor = true;
			this.btnDiscon.Click += new System.EventHandler(this.btnDiscon_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.Location = new System.Drawing.Point(174, 13);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.rtfMain);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.txtIn);
			this.splitContainer1.Size = new System.Drawing.Size(449, 486);
			this.splitContainer1.SplitterDistance = 457;
			this.splitContainer1.TabIndex = 6;
			// 
			// CommWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(623, 511);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.btnDiscon);
			this.Controls.Add(this.btnListen);
			this.Controls.Add(this.btnConnect);
			this.Controls.Add(this.listView1);
			this.Name = "CommWin";
			this.Text = "winMain";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox rtfMain;
		private System.Windows.Forms.TextBox txtIn;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.Button btnListen;
		private System.Windows.Forms.Button btnDiscon;
		private System.Windows.Forms.SplitContainer splitContainer1;
	}
}