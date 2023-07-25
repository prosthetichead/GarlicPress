using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GarlicPress
{
    public enum SearchType
    {
        GameName,
        GameID
    }

    public partial class GameSearchDialogForm : Form
    {

        private void SetupSearchType()
        {
            Dictionary<SearchType, string> items = new Dictionary<SearchType, string>();
            items.Add(SearchType.GameName, "Game Name");
            items.Add(SearchType.GameID, "SS Game ID");
            cbSearchType.DataSource = new BindingSource(items, null);
            cbSearchType.DisplayMember = "Value";
            cbSearchType.ValueMember = "Key";
            cbSearchType.SelectedIndex = 0;
        }

        
        public GameSearchDialogForm(string searchText, string message)
        {
            InitializeComponent();
            labMessage.Text = message;
            txtNewSearch.Text = searchText;

            SetupSearchType();
        }

        public string NewSearchValue { get { return txtNewSearch.Text; } }
        public SearchType SelectedSearchType { get { return (SearchType)cbSearchType.SelectedValue; } }
    }
}
