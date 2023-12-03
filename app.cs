using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

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
    private Button gazou;
    private TextBox codebox;
    private Button codesender;
    private Label h2mozi;
    private Label pmozi;
    private Label codemozi;



    public MyForm()
    {

        string pathToAnotherExe = @"htmlview.exe";

        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = pathToAnotherExe,
            CreateNoWindow = true,
            UseShellExecute = false
        };

        Process.Start(psi);




            string htmlContent = @"
<!DOCTYPE html>
<html lang=""ja"">
<head>
    <meta charset=""UTF-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>MakeBlog | MASSANGO</title>
    <meta content=""MakeBlog | MASSANGO"" name=""description"">
    <meta property=""og:title"" content=""Massango"" />
    <meta property=""og:description"" content=""MakeBlog | MASSANGO"" />
    <meta property=""og:type"" content=""website"" />
    <meta property=""og:url"" content=""https://massangooo.net"" />
    <meta property=""og:image"" content=""https://massangooo.net/mass.png"" />
    <meta property=""og:site_name"" content=""Massango"" />
    <meta property=""og:locale"" content=""ja_JP""  />
    <link rel=""stylesheet"" href=""style.css"">
    <link rel=""stylesheet"" href=""st.css"">
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






        this.Text = "ブログ作成";
        this.Size = new Size(600, 600);


        textbox1 = new TextBox();
        textbox1.Size = new Size(600,400);
        textbox1.Location = new System.Drawing.Point(0,25);

        textbox2 = new TextBox();
        textbox2.Size = new Size(600,600);
        textbox2.Location = new System.Drawing.Point(0, 120);

        sendButton = new Button();
        sendButton.Text = "送信";
        sendButton.Location = new System.Drawing.Point(170, 45);
        sendButton.ForeColor = System.Drawing.Color.White;
        sendButton.BackColor = Color.FromArgb(110, 123, 73);
        sendButton.Click += sendButton_Click;

        sendButton2 = new Button();
        sendButton2.Text = "送信1";
        sendButton2.Location = new System.Drawing.Point(170,160);
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
        akairo1.Location = new System.Drawing.Point(0,160);
        akairo1.Click += akairo1_Click;

        kuroiro1 = new Button();
        kuroiro1.Text = "黒色";
        kuroiro1.Location = new System.Drawing.Point(80,160);
        kuroiro1.Click += kuroiro1_Click;

        gazou = new Button();
        gazou.Text = "画像を入れる";
        gazou.Location = new System.Drawing.Point(0,300);
        gazou.Size = new Size(100,40);
        gazou.Click += gazou_Click;

        codebox = new TextBox();
        codebox.Size = new Size(100,700);
        codebox.Multiline = true;
        codebox.Height = 200;
        codebox.Location = new System.Drawing.Point(100,300);

        codesender = new Button();
        codesender.Text = "送信2";
        codesender.Location = new System.Drawing.Point(200,300);
        codesender.Click += codesender_Click;


        h2mozi = new Label();
        h2mozi.Text = "H2で書けるよ";
        h2mozi.Location = new System.Drawing.Point(0,0);

        pmozi = new Label();
        pmozi.Text = "Pでかけるよ";
        pmozi.Location = new System.Drawing.Point(0,95);

        codemozi = new Label();
        codemozi.Text = "コードを入れれます";
        codemozi.Location = new System.Drawing.Point(200,400);

        Controls.Add(codemozi);
        Controls.Add(pmozi);
        Controls.Add(h2mozi);
        Controls.Add(codesender);
        Controls.Add(codebox);
        Controls.Add(gazou);
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

  
    private void codesender_Click(object sender, EventArgs e)
    {
        string textToSave3 = codebox.Text;
        AppendToHtmlFile3(textToSave3);
        codebox.Clear();
    }

    private void AppendToHtmlFile3(string text)
    {
        string filepath = Path.Combine("saved_text.html");
        using (StreamWriter writer = new StreamWriter(filepath, true))
        {
            writer.WriteLine("<pre><code>" + text + "</code></pre>");
        }

    }


    private void gazou_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "画像ファイル|*.jpg;*.jpeg;*.png;*.gif;*.bmp|すべてのファイル|*.*";
            openFileDialog.Title = "画像を選択してください";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;

                string fileName = Path.GetFileName(selectedImagePath);

                string destinationFolderPath = Path.Combine(Environment.CurrentDirectory, "pic");

                string destinationFilePath = Path.Combine(destinationFolderPath, fileName);

                if (!Directory.Exists(destinationFolderPath))
                {
                    Directory.CreateDirectory(destinationFolderPath);
                }

                File.Copy(selectedImagePath, destinationFilePath, true);

                string imgElement = string.Format("<img src=\"pic/{0}\" alt=\"\" width=\"100%\">", fileName);
                string filepath = Path.Combine("saved_text.html");

                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    writer.WriteLine(imgElement);
            
                }
            }
        }
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
        string filepath = Path.Combine("saved_text.html");
        using (StreamWriter writer = new StreamWriter(filepath, true))
        {
            if (textbox1.ForeColor != Color.Red)
            {
                writer.WriteLine("<h2>" + text + "</h2>");
            }
            else
            {
               writer.WriteLine("<h2 class=\"akairo1\">" + text + "</h2>");
            }
        }

    }

    private void sendButton2_Click(object sender, EventArgs e)
    {
        string textToSave1 = textbox2.Text;
        AppendToHtmlFile1(textToSave1);
        textbox2.Clear(); 
    }

    private void AppendToHtmlFile1(string text)
    {
        string filePath = Path.Combine("saved_text.html");
        using (StreamWriter writer = new StreamWriter(filePath, true ))
        {
            if (textbox2.ForeColor != Color.Red)
            {
                writer.WriteLine("<p>" + text + "</p>");
            }
            else
            {
               writer.WriteLine("<p class=\"akairo1\">" + text + "</p>");
            }
        }

    }

    private void okbutton_Click(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show("終了しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            string filePath = Path.Combine("saved_text.html");
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("</div>");
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