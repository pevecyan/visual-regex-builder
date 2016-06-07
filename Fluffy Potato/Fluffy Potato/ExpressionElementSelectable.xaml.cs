using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fluffy_Potato
{
    /// <summary>
    /// Interaction logic for ExpressionElementSelectable.xaml
    /// </summary>
    public partial class ExpressionElementSelectable : UserControl
    {
        string expressionName;

        public string ExpressionName { get { return this.expressionName; } set { this.expressionName = value; ExpressionElementTextBlock.Text = this.expressionName; } }

        Action<string> clicked;
        public Action<string> Clicked { get { return this.clicked; } set { this.clicked = value; } }

        public ExpressionElementSelectable()
        {
            InitializeComponent();
            this.MouseLeftButtonUp += ExpressionElementSelectable_MouseLeftButtonUp;
        }

        private void ExpressionElementSelectable_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            clicked(expressionName);
        }
    }
}
