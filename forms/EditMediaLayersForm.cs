using GarlicPress.components;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;

namespace GarlicPress.forms;
public partial class EditMediaLayersForm : Form
{
    public EditMediaLayersForm()
    {
        InitializeComponent();
        var services = new ServiceCollection();
        services.AddWindowsFormsBlazorWebView();
        services.AddBlazorWebViewDeveloperTools();
        services.AddSingleton(this);
        bwvMediaEditor.HostPage = "wwwroot\\index.html";
        bwvMediaEditor.Services = services.BuildServiceProvider();
        bwvMediaEditor.RootComponents.Add<MediaGenerationEditor>("#app");
    }

    private void EditMediaLayersForm_LocationChanged(object sender, EventArgs e)
    {
        //fix for select not being in correct location if window is moved
        bwvMediaEditor.Width++;
        bwvMediaEditor.Width--;
    }
}
