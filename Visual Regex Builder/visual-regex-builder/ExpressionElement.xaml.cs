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

namespace vrb
{
    /// <summary>
    /// Interaction logic for ExpressionElement.xaml
    /// </summary>
    public partial class ExpressionElement : UserControl
    {
        string expressionName;

        public string ExpressionName { get { return this.expressionName; } set { this.expressionName = value; ExpressionNameText.Text = this.expressionName; UpdateExpressionValueTextboxVisibility(); } }

        public string ExpressionValue { get { return ExpressionValueText.Text; } }

        public ExpressionElement()
        {
            InitializeComponent();
        }

        private void UpdateExpressionValueTextboxVisibility()
        {
            switch (expressionName)
            {
                case "StartOfLine":
                    ExpressionValueText.Visibility = Visibility.Collapsed;
                    break;
                case "EndOfLine":
                    ExpressionValueText.Visibility = Visibility.Collapsed;
                    break;
                case "Then":
                    ExpressionValueText.Visibility = Visibility.Visible;
                    break;
                case "Maybe":
                    ExpressionValueText.Visibility = Visibility.Visible;
                    break;
                case "AnythingBut":
                    ExpressionValueText.Visibility = Visibility.Visible;
                    break;
                case "Any":
                    ExpressionValueText.Visibility = Visibility.Visible;
                    break;
                case "Or":
                    ExpressionValueText.Visibility = Visibility.Visible;
                    break;
                case "Multiple":
                    ExpressionValueText.Visibility = Visibility.Visible;
                    break;
                case "Something":
                    ExpressionValueText.Visibility = Visibility.Collapsed;
                    break;
                case "SomethingBut":
                    ExpressionValueText.Visibility = Visibility.Visible;
                    break;
                case "Word":
                    ExpressionValueText.Visibility = Visibility.Collapsed;
                    break;
                case "LineBreak":
                    ExpressionValueText.Visibility = Visibility.Collapsed;
                    break;
                case "Tab":
                    ExpressionValueText.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            ((StackPanel)this.Parent).Children.Remove(this);
            
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            StackPanel parent = ((StackPanel)this.Parent);
            int prevIndex = parent.Children.IndexOf(this);
            int nextIndex = prevIndex - 1;
            if (nextIndex < 0) nextIndex = 0;
            parent.Children.Remove(this);
            parent.Children.Insert(nextIndex, this);
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            StackPanel parent = ((StackPanel)this.Parent);
            int prevIndex = parent.Children.IndexOf(this);
            int nextIndex = prevIndex + 1;
            if (nextIndex > parent.Children.Count-1) nextIndex = parent.Children.Count - 1;
            parent.Children.Remove(this);
            parent.Children.Insert(nextIndex, this);
        }
    }
}
