using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace HttpServerDemo
{

    public partial class Form1 : Form
    {
        #region HttpServer相关变量
        public string Ip = Dns.GetHostEntry(Dns.GetHostName())
            .AddressList.FirstOrDefault<IPAddress>(a => a.AddressFamily.ToString().Equals("InterNetwork")).ToString();

        public int Port = 9091;

        public string EnvironmentUserName = Environment.UserName;

        private THttpListener _httpListener;
        #endregion

        public Form1()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;

            label1.Text = "";
            textBoxIP.Text = Ip;
            textBoxPort.Text = Port.ToString();

            textBoxPath.Text = Application.StartupPath;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (textBoxIP.Text == "" || textBoxPort.Text == "" || listView1.Items.Count == 0)
                return;

            textBoxPath_TextChanged(sender, e);

            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            label1.Text = "HttpServer已启动";
            label1.ForeColor = Color.FromArgb(0, 0, 255);

            Port = int.Parse(textBoxPort.Text.Trim());
            //添加防火墙例外端口，供客户端访问
            INetFwManger.NetFwAddPorts("ODOO ", Port, "TCP");

            #region 执行dos命令
            DosCommandOperation dosCommandOperation = new DosCommandOperation();
            string dosRet = dosCommandOperation.Execute(string.Format("netsh http add urlacl url=http://{0}:{1}/ user={2}", Ip, Port, EnvironmentUserName));
            #endregion

            #region 启动HttpServer
            List<string> listUrl = new List<string>();
            dicUrlResponse.Clear();
            foreach (ListViewItem item in listView1.Items)
            {
                listUrl.Add(item.SubItems[0].Text);
                dicUrlResponse.Add(item.SubItems[0].Text, item.SubItems[2].Text);
            }
            _httpListener = new THttpListener(listUrl.ToArray());

            _httpListener.ResponseEvent += _HttpListener_ResponseEvent;
            _httpListener.Start();
            #endregion
        }
        Dictionary<string, string> dicUrlResponse = new Dictionary<string, string>();

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (_httpListener != null)
            {
                buttonStart.Enabled = true;
                buttonStop.Enabled = false;
                label1.Text = "HttpServer已停止";
                label1.ForeColor = Color.Red;

                _httpListener.Stop();
            }
        }

        #region HttpServer相关

        void _HttpListener_ResponseEvent(System.Net.HttpListenerContext ctx)
        {
            //GET 还是 POST 是根据访问方式得来的           
            try
            {
                //响应消息 根据第一列，响应第三列
                Invoke((MethodInvoker)(() =>
                {
                    foreach (ListViewItem item in listView1.Items)
                    {
                        string url = ctx.Request.Url.ToString();
                        url = url.Contains('?') ? url.Substring(0, url.IndexOf('?')) : url;

                        if (item.SubItems[0].Text == url || item.SubItems[0].Text == url + "/")
                        {
                            ResponseWrite(item.SubItems[2].Text, ctx.Response);
                        }

                    }
                }));

            }
            catch (Exception ex)
            {
            }

            //测试页面
            //if (!ctx.Request.Url.AbsolutePath.ToLower().Contains("login"))
            //{
            //    ResponseWrite("<html><head><title>ODOO</title></head><body><div><h1>这是一个测试页面</h1><p>如果能打开这个页面，那么HttpServer已经启动成功了。</body></html>", ctx.Response, "text/html");
            //}
            //else
            //{
            //    ResponseWrite("ok", ctx.Response);
            //}
        }

        /// <summary>
        /// http响应
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="response"></param>
        /// <param name="type"></param>
        public void ResponseWrite(string msg, System.Net.HttpListenerResponse response, string type = "text/plain")
        {
            try
            {
                //使用Writer输出http响应代码
                if (type == "text/plain")
                {
                    //using (System.IO.StreamWriter writer = new System.IO.StreamWriter(response.OutputStream, new UTF8Encoding()))
                    //{
                    //    response.ContentType = type + ";charset=utf-8";
                    //    writer.WriteLine(msg);
                    //    writer.Close();
                    //    response.Close();
                    //}
                }

                using (StreamWriter writer = new StreamWriter(response.OutputStream))
                {
                    response.StatusCode = 200;
                    response.Headers.Add("Access-Control-Allow-Origin", "*");
                    response.ContentType = "application/json";
                    response.ContentEncoding = Encoding.UTF8;

                    writer.WriteLine(msg);
                    writer.Close();
                    response.Close();
                }

            }
            catch (Exception exception)
            {
            }
        }

        #endregion

        #region 其他控件事件
        static List<FileInformation> FileList = new List<FileInformation>();
        public static List<FileInformation> GetAllFiles(DirectoryInfo dir)
        {
            FileInfo[] allFile = dir.GetFiles();
            foreach (FileInfo fi in allFile)
            {
                FileList.Add(new FileInformation { FileName = fi.Name, FilePath = fi.FullName, FileRout = fi.DirectoryName });
            }
            DirectoryInfo[] allDir = dir.GetDirectories();
            foreach (DirectoryInfo d in allDir)
            {
                GetAllFiles(d);
            }
            return FileList;
        }

        public class FileInformation
        {
            public string FileName { get; set; }
            public string FilePath { get; set; }
            public string FileRout { get; set; }
        }

        private void textBoxPath_TextChanged(object sender, EventArgs e)
        {
            FileList.Clear();
            listView1.Items.Clear();
            string path = textBoxPath.Text;
            if (Directory.Exists(path))
            {
                List<FileInformation> list = GetAllFiles(new DirectoryInfo(path));

                //去掉重复的  只保留第一个                      
                list = list.Where((x, i) => list.FindIndex(z => z.FileRout == x.FileRout) == i).ToList();

                foreach (var item in list)
                {
                    Console.WriteLine(string.Format("文件名：{0}---文件目录{1}", item.FileName, item.FilePath));
                    string url = "http://" + item.FileRout.Replace(path, textBoxIP.Text.Trim() + ":" + textBoxPort.Text.Trim()).Replace('\\', '/') + "/";
                    string content = new StreamReader(item.FilePath, Encoding.Default).ReadToEnd();
                    listView1.Items.Add(new ListViewItem(new string[] { url, item.FileName, content }));
                }
            }
        }

        private void listView1_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            ToolTip toolTip = new ToolTip();

            string itemInfor =
            "URL" + e.Item.SubItems[0].Text + "\n" +
            "文件名：" + e.Item.SubItems[1].Text + "\n" +
            "内容：" + e.Item.SubItems[2].Text + "\n";

            toolTip.SetToolTip((e.Item).ListView, itemInfor);
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            //没选中，或没启动监听
            if (listView1.SelectedItems.Count == 0 || buttonStart.Enabled == true)
                return;

            //获取选中行 第1列的内容
            string text = listView1.SelectedItems[0].SubItems[0].Text; 
            System.Diagnostics.Process.Start("explorer.exe", text);
        }

        bool isCollapsed = false;
        private void Form1_Click(object sender, EventArgs e)
        {
            if (!isCollapsed)
            {
                splitContainer1.Panel1Collapsed = true;
                isCollapsed = true;
            }
            else
            {
                splitContainer1.Panel1Collapsed = false;
                isCollapsed = false;
            }
        }
        #endregion

    }
}
