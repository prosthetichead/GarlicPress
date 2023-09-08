using GarlicPress.components;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;

namespace GarlicPress.forms;
public partial class EditMediaLayersForm : Form
{
    public EditMediaLayersForm(GarlicDrive? garlicDrive = null, GarlicSystem? garlicSystem = null, string? game = null)
    {
        InitializeComponent();
        var services = new ServiceCollection();
        services.AddWindowsFormsBlazorWebView();
        services.AddBlazorWebViewDeveloperTools();
        services.AddSingleton(this);
        bwvMediaEditor.HostPage = "wwwroot\\index.html";
        bwvMediaEditor.Services = services.BuildServiceProvider();

        var parameters = new Dictionary<string, object?>
        {
            { nameof(MediaGenerationEditor._selectedDrive), garlicDrive },
            { nameof(MediaGenerationEditor._selectedSystem), garlicSystem },
            { nameof(MediaGenerationEditor._selectedGame), game }
        };

        var rootComp = new RootComponent("#app", typeof(MediaGenerationEditor), parameters);
        
        bwvMediaEditor.RootComponents.Add(rootComp);
    }

    private void EditMediaLayersForm_LocationChanged(object sender, EventArgs e)
    {
        //fix for select not being in correct location if window is moved
        bwvMediaEditor.Width++;
        bwvMediaEditor.Width--;
    }
}
