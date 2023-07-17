using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarlicPress
{
    public partial class GameNameDialogForm : Form
    {

        public GameNameDialogForm(GameResponse gameResponse, string searchText)
        {
            InitializeComponent();            
            labError.Text = labError.Text.Replace("[gamename]", searchText);
            labError.Text = labError.Text.Replace("[error]", gameResponse.statusMessage);
            txtNewSearch.Text = searchText;
        }
        public GameNameDialogForm(string searchText, string labErrorText)
        {
            InitializeComponent();
            labError.Text = labErrorText;
            txtNewSearch.Text = searchText;
        }

        public string NewSearchValue { get { return txtNewSearch.Text; } }
    }
}
