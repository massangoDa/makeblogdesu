using MaterialSkin;
using MaterialSkin.Controls;

public partial class MainForm : MaterialForm
{
    public MainForm()
    {
        InitializeComponent();

        // MaterialSkinManagerのセットアップ
        var materialSkinManager = MaterialSkinManager.Instance;
        materialSkinManager.AddFormToManage(this);
        materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

        // プライマリカラーとアクセントカラーのセットアップ
        materialSkinManager.ColorScheme = new ColorScheme(
            Primary.DeepPurple400, Primary.DeepPurple500,
            Primary.DeepPurple500, Accent.DeepPurple700,
            TextShade.WHITE
        );

        // フォームにテキストボックスを追加するメソッドを呼び出す
        AddMaterialTextBox();
    }

    private void AddMaterialTextBox()
    {
        var materialTextBox = new MaterialSingleLineTextField
        {
            Location = new System.Drawing.Point(20, 80),
            Size = new System.Drawing.Size(200, 50),
            Hint = "ここに入力",
            Depth = 0,
            Dock = DockStyle.None
        };

        // フォームにテキストボックスを追加
        Controls.Add(materialTextBox);
    }
}
