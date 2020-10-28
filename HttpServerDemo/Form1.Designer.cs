namespace HttpServerDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelServer = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonOpenPath = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.labelPath = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(816, 431);
            this.textBox1.TabIndex = 0;
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(26, 17);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(41, 12);
            this.labelServer.TabIndex = 1;
            this.labelServer.Text = "server";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(85, 12);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(237, 21);
            this.textBoxIP.TabIndex = 2;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(337, 11);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(40, 21);
            this.textBoxPort.TabIndex = 4;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(462, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 42);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "启动";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(816, 343);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.listView1_ItemMouseHover);
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "URL";
            this.columnHeader1.Width = 252;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "文件名";
            this.columnHeader2.Width = 258;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "返回内容";
            this.columnHeader3.Width = 200;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(-1, 66);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Size = new System.Drawing.Size(816, 499);
            this.splitContainer1.SplitterDistance = 343;
            this.splitContainer1.TabIndex = 7;
            // 
            // buttonOpenPath
            // 
            this.buttonOpenPath.Font = new System.Drawing.Font("宋体", 10F);
            this.buttonOpenPath.Location = new System.Drawing.Point(337, 38);
            this.buttonOpenPath.Name = "buttonOpenPath";
            this.buttonOpenPath.Size = new System.Drawing.Size(40, 23);
            this.buttonOpenPath.TabIndex = 10;
            this.buttonOpenPath.Text = "...";
            this.buttonOpenPath.UseVisualStyleBackColor = true;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(572, 12);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 42);
            this.buttonStop.TabIndex = 9;
            this.buttonStop.Text = "停止";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(26, 42);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(53, 12);
            this.labelPath.TabIndex = 8;
            this.labelPath.Text = "文件路径";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(85, 39);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(237, 21);
            this.textBoxPath.TabIndex = 7;
            this.textBoxPath.TextChanged += new System.EventHandler(this.textBoxPath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(672, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "serverStatus";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 410);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOpenPath);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelServer);
            this.Name = "Form1";
            this.Text = "VirtualHttpServer";
            this.Click += new System.EventHandler(this.Form1_Click);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonOpenPath;
        private System.Windows.Forms.Label label1;
    }
}

