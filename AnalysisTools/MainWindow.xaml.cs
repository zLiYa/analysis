using System.Text;
using System.Windows;

namespace AnalysisTools
{
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = _viewModel = new MainWindowViewModel();
        }
    }
}