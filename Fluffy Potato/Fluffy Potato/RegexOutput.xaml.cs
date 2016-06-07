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
using System.Windows.Shapes;

namespace Fluffy_Potato
{
    /// <summary>
    /// Interaction logic for RegexOutput.xaml
    /// </summary>
    public partial class RegexOutput : Window
    {
        string regex;

        public string Regex { get { return this.regex; } set { this.regex = value; RegexTextBox.Text = regex; } }


        public RegexOutput()
        {
            InitializeComponent();
        }
    }
}
