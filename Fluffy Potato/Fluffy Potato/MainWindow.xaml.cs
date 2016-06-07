using CSharpVerbalExpressions;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadExpressions();
        }

        public void LoadExpressions()
        {
            ExpressionsStackPanel.Children.Add(new ExpressionElementSelectable() {ExpressionName = "StartOfLine", Clicked = ExpressionSelectableClicked });
            ExpressionsStackPanel.Children.Add(new ExpressionElementSelectable() { ExpressionName = "EndOfLine", Clicked = ExpressionSelectableClicked });
            ExpressionsStackPanel.Children.Add(new ExpressionElementSelectable() { ExpressionName = "Then", Clicked = ExpressionSelectableClicked });
            ExpressionsStackPanel.Children.Add(new ExpressionElementSelectable() { ExpressionName = "Maybe", Clicked = ExpressionSelectableClicked });
            ExpressionsStackPanel.Children.Add(new ExpressionElementSelectable() { ExpressionName = "AnythingBut", Clicked = ExpressionSelectableClicked });
        }

        public void test()
        {
            var expression = new VerbalExpressions();
        }

        public void ExpressionSelectableClicked(string expressionName)
        {
            ExpressionOutputStackPanel.Children.Add(new ExpressionElement() { ExpressionName = expressionName });
        }

        private string generateRegex()
        {
            var expression = VerbalExpressions.DefaultExpression;

            foreach(ExpressionElement ee in ExpressionOutputStackPanel.Children)
            {
                switch (ee.ExpressionName)
                {
                    case "StartOfLine":
                        expression.StartOfLine();
                        break;
                    case "EndOfLine":
                        expression.EndOfLine();
                        break;
                    case "Then":
                        expression.Then(ee.ExpressionValue);
                        break;
                    case "Maybe":
                        expression.Maybe(ee.ExpressionValue);
                        break;
                    case "AnythingBut":
                        expression.AnythingBut(ee.ExpressionValue);
                        break;
                }
            }


            return expression.ToRegex().ToString();
        }

        //Buttons
        private void RegexButton_Click(object sender, RoutedEventArgs e)
        {
            
            new RegexOutput() {Regex = generateRegex() }.Show();
        }

        
    }
}
