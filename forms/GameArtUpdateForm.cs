using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarlicPress.forms
{
    public partial class GameArtUpdateForm : Form
    {
        BindingList<GarlicGameArtSearch> searchItems = new BindingList<GarlicGameArtSearch>();


        public GameArtUpdateForm(List<GarlicGameArtSearch> searchItems)
        {
            InitializeComponent();

            foreach (GarlicGameArtSearch item in searchItems)
                this.searchItems.Add(item);


            dataGridSearch.AutoGenerateColumns = false;

            gridColSearchText.DataPropertyName = "searchText";
            gridColDrive.DataPropertyName = "driveName";
            gridColSystem.DataPropertyName = "systemName";
            gridColStatus.DataPropertyName = "status";

            dataGridSearch.DataSource = this.searchItems;
        }
    }
}
