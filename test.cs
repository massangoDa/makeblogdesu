using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;
using System.IO;

class MyForm : Form
{
    private TextBox textbox1;
    private Button sendButton;
    private TextBox textbox2;
    private Button sendButton2;
    private Button okbutton;
    private Button akairo;
    private Button kuroiro;
    private Button akairo1;
    private Button kuroiro1;

    public MyForm()
    {




            string htmlContent = @"
<!DOCTYPE html>
<html lang=""ja"">
<head>
    <meta charset=""UTF-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Rehiniの借金時計 ｜ MASSANGO</title>
    <meta content=""Rehiniの借金時計"" name=""description"">
    <meta property=""og:title"" content=""Massango"" />
    <meta property=""og:description"" content=""Rehiniの借金時計"" />
    <meta property=""og:type"" content=""website"" />
    <meta property=""og:url"" content=""https://massangooo.net"" />
    <meta property=""og:image"" content=""https://massangooo.net/mass.png"" />
    <meta property=""og:site_name"" content=""Massango"" />
    <meta property=""og:locale"" content=""ja_JP""  />
    <link rel=""stylesheet"" href=""style.css"">
    <link rel=""stylesheet"" href=""../footer/footer.css"">
    <link rel=""icon"" href=""../favicon.ico"">
</head>
<body>
    <header>
        <a href=""../index.html""><div class=""logo"">MASSANGO</div></a>
        <nav>
          <ul>
            <li><a href=""../index.html"">Home</a></li>
            <li><a href=""../about.html"">Profile</a></li>
            
            <li><a href=""../service.html"">Services</a></li>
            <li><a href=""../blog.html"">Blog</a></li>
          </ul>
        </nav>
      </header>

      <div class=""main-content"">
        <div class=""box"">
";

            // ファイルに書き込み
            File.WriteAllText("saved_text.html", htmlContent, Encoding.UTF8);

            Console.WriteLine("HTMLファイルが正常に作成されました。");





        this.Text = "ブログ作成";
        this.Size = new Size(600, 600);

        textbox1 = new TextBox();
        textbox1.SuspendLayout();
        textbox1.Size = new Size(600,400);

        textbox2 = new TextBox();
        textbox2.SuspendLayout();
        textbox2.Size = new Size(600,600);
        textbox2.Location = new System.Drawing.Point(0, 100);

        sendButton = new Button();
        sendButton.Text = "送信";
        sendButton.Location = new System.Drawing.Point(170, 45);
        sendButton.Click += sendButton_Click;

        sendButton2 = new Button();
        sendButton2.Text = "送信1";
        sendButton2.Location = new System.Drawing.Point(170,140);
        sendButton2.Click += sendButton2_Click;

        okbutton = new Button();
        okbutton.Text = "終了";
        okbutton.Location = new System.Drawing.Point(515,545);
        okbutton.Click += okbutton_Click;

        akairo = new Button();
        akairo.Text = "赤色";
        akairo.Location = new System.Drawing.Point(0,45);
        akairo.Click += akairo_Click;

        kuroiro = new Button();
        kuroiro.Text = "黒色";
        kuroiro.Location = new System.Drawing.Point(80,45);
        kuroiro.Click += kuroiro_Click;

        akairo1 = new Button();
        akairo1.Text = "赤色";
        akairo1.Location = new System.Drawing.Point(0,140);
        akairo1.Click += akairo1_Click;

        kuroiro1 = new Button();
        kuroiro1.Text = "黒色";
        kuroiro1.Location = new System.Drawing.Point(80,140);
        kuroiro1.Click += kuroiro1_Click;

        Controls.Add(kuroiro1);
        Controls.Add(akairo1);
        Controls.Add(kuroiro);
        Controls.Add(akairo);
        Controls.Add(okbutton);
        Controls.Add(sendButton);
        Controls.Add(sendButton2);
        Controls.Add(textbox2);
        Controls.Add(textbox1);

    }

    private void sendButton_Click(object sender, EventArgs e)
    {
        string textToSave = textbox1.Text;
        AppendToHtmlFile(textToSave);
        textbox1.Clear();
    }

    private void kuroiro_Click(object sender, EventArgs e)
    {
        textbox1.ForeColor = Color.Black;
    }

    private void akairo_Click(object sender, EventArgs e)
    {
        textbox1.ForeColor = Color.Red;
    }

    private void kuroiro1_Click(object sender, EventArgs e)
    {
        textbox2.ForeColor = Color.Black;
    }

    private void akairo1_Click(object sender, EventArgs e)
    {
        textbox2.ForeColor = Color.Red;
    }

    private void AppendToHtmlFile(string text)
    {
        string filePath = Path.Combine("saved_text.html");
        using (StreamWriter writer = new StreamWriter(filePath, true ))
        {
            if (textbox1.ForeColor != Color.Red)
            {
                writer.WriteLine("<p>" + text + "</p>");
            }
            else
            {
               writer.WriteLine("<p class=\"reddesu\">" + text + "</p>");
            }
        }

        MessageBox.Show("HTMLファイルに追加しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void sendButton2_Click(object sender, EventArgs e)
    {
        string textToSave1 = textbox2.Text;
        AppendToHtmlFile1(textToSave1);
        textbox2.Clear(); 
    }

    private void AppendToHtmlFile1(string text)
    {
        string filepath = Path.Combine("saved_text.html");
        using (StreamWriter writer = new StreamWriter(filepath, true))
        {
            if (textbox1.ForeColor != Color.Red)
            {
                writer.WriteLine("<h2>" + text + "</h2>");
            }
            else
            {
               writer.WriteLine("<h2 class=\"blackdesu\">" + text + "</h2>");
            }
        }

        MessageBox.Show("H2をファイルに追加しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void okbutton_Click(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show("終了しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            string filePath = Path.Combine("saved_text.html");
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("</div> </div>");
                writer.WriteLine("</div>");
                writer.WriteLine("</body>");
                writer.WriteLine("</html>");
            }

            Application.Exit();
        }
    }
}

class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MyForm());
    }
}