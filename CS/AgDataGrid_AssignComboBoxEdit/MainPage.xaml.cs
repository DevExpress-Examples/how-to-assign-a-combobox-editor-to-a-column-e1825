using System.Collections.Generic;
using System.Windows.Controls;
using DevExpress.AgDataGrid;
using DevExpress.AgEditors.Settings;

namespace AgDataGrid_AssignComboBoxEdit {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            grid.DataSource = ProductList.GetData();
            InitComboBoxColumn(grid.Columns["Country"]);
        }
        private void InitComboBoxColumn(AgDataGridColumn column) {
            ((ComboBoxEditSettings)column.EditSettings).ItemsSource = GetCountries((List<Product>)grid.DataSource);
        }
        private List<string> GetCountries(List<Product> ds) {
            List<string> list = new List<string>();
            foreach (Product p in ds) {
                if (!list.Contains(p.Country))
                    list.Add(p.Country);
            }
            return list;
        }
    }
}
