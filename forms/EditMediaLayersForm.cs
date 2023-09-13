using GarlicPress.components;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;

namespace GarlicPress.forms;
public partial class EditMediaLayersForm : Form
{
    static EditMediaLayersForm? _instance;

    public GarlicDrive? _garlicDrive { get; set; }
    public GarlicSystem? _garlicSystem { get; set; }
    public string _game { get; set; } = "";

    public event Action? OnUpdatedModels;

    public static EditMediaLayersForm Instance
    {
        get
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new();
            }
            return _instance;
        }
    }

    public EditMediaLayersForm(GarlicDrive? garlicDrive = null, GarlicSystem? garlicSystem = null, string game = "")
    {
        InitializeComponent();

        _garlicDrive = garlicDrive;
        _garlicSystem = garlicSystem;
        _game = game;

        var services = new ServiceCollection();
        services.AddWindowsFormsBlazorWebView();
        services.AddBlazorWebViewDeveloperTools();
        services.AddSingleton(this);
        bwvMediaEditor.HostPage = "wwwroot\\index.html";
        bwvMediaEditor.Services = services.BuildServiceProvider();
        bwvMediaEditor.RootComponents.Add<MediaGenerationEditor>("#app");
    }

    public void UpdateModels()
    {
        OnUpdatedModels?.Invoke();
    }

    private void EditMediaLayersForm_LocationChanged(object sender, EventArgs e)
    {
        //fix for select not being in correct location if window is moved
        bwvMediaEditor.Width++;
        bwvMediaEditor.Width--;
    }

    //Stop the form from disposing when closed
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);

        if (e.CloseReason == CloseReason.UserClosing
            && this == Instance)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
