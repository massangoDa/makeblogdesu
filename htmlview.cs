using System;
using System.IO;
using System.Windows.Forms;

public class EntryPoint
{
    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        string htmlFileName = "saved_text.html";
        string htmlFilePath = Path.Combine(GetApplicationDirectory(), htmlFileName);

        HtmlPreviewForm previewForm = new HtmlPreviewForm(htmlFilePath);
        Application.Run(previewForm);
    }

    private static string GetApplicationDirectory()
    {
        return Path.GetDirectoryName(Application.ExecutablePath);
    }
}

public class HtmlPreviewForm : Form
{
    private WebBrowser webBrowser;
    private string htmlFilePath;

    public HtmlPreviewForm(string htmlFilePath)
    {
        this.htmlFilePath = htmlFilePath;
        InitializeForm();
        LoadHtml();
        SetUpFileSystemWatcher();
    }

    private void InitializeForm()
    {
        this.Text = "HTML プレビュー";
        this.Size = new System.Drawing.Size(800, 600);

        webBrowser = new WebBrowser();
        webBrowser.Dock = DockStyle.Fill;

        this.Controls.Add(webBrowser);
    }

    private void LoadHtml()
    {
        try
        {
            webBrowser.Navigate(new Uri(htmlFilePath));
        }
        catch (Exception ex)
        {
            MessageBox.Show("HTML ファイルの読み込みエラー: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SetUpFileSystemWatcher()
    {
        string directoryPath = Path.GetDirectoryName(htmlFilePath);

        FileSystemWatcher watcher = new FileSystemWatcher();
        watcher.Path = directoryPath;
        watcher.Filter = Path.GetFileName(htmlFilePath);
        watcher.NotifyFilter = NotifyFilters.LastWrite;
        watcher.Changed += OnHtmlFileChanged;
        watcher.EnableRaisingEvents = true;
    }

    private void OnHtmlFileChanged(object sender, FileSystemEventArgs e)
    {
        if (e.ChangeType == WatcherChangeTypes.Changed)
        {
            Invoke(new Action(LoadHtml));
        }
    }
}
