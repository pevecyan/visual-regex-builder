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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace vrb
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
            ExpressionsStackPanel.Children.Add(new ExpressionElementSelectable() { ExpressionName = "Any", Clicked = ExpressionSelectableClicked });
            ExpressionsStackPanel.Children.Add(new ExpressionElementSelectable() { ExpressionName = "Or", Clicked = ExpressionSelectableClicked });
            ExpressionsStackPanel.Children.Add(new ExpressionElementSelectable() { ExpressionName = "Multiple", Clicked = ExpressionSelectableClicked });
            ExpressionsStackPanel.Children.Add(new ExpressionElementSelectable() { ExpressionName = "Something", Clicked = ExpressionSelectableClicked });
            ExpressionsStackPanel.Children.Add(new ExpressionElementSelectable() { ExpressionName = "SomethingBut", Clicked = ExpressionSelectableClicked });
            ExpressionsStackPanel.Children.Add(new ExpressionElementSelectable() { ExpressionName = "Word", Clicked = ExpressionSelectableClicked });
            ExpressionsStackPanel.Children.Add(new ExpressionElementSelectable() { ExpressionName = "LineBreak", Clicked = ExpressionSelectableClicked });
            ExpressionsStackPanel.Children.Add(new ExpressionElementSelectable() { ExpressionName = "Tab", Clicked = ExpressionSelectableClicked });

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
                try
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
                        case "Any":
                            expression.Any(ee.ExpressionValue);
                            break;
                        case "Or":
                            expression.Or(ee.ExpressionValue);
                            break;
                        case "Multiple":
                            expression.Multiple(ee.ExpressionValue);
                            break;
                        case "Something":
                            expression.Something();
                            break;
                        case "SomethingBut":
                            expression.SomethingBut(ee.ExpressionValue);
                            break;
                        case "Word":
                            expression.Word();
                            break;
                        case "LineBreak":
                            expression.LineBreak();
                            break;
                        case "Tab":
                            expression.Tab();
                            break;
                            
                    }
                }catch(ArgumentNullException anx)
                {
                    ShowNotification("One of the elements is missing something!");
                    return null;
                }
            }
            


            return expression.ToRegex().ToString();
        }

        //Buttons
        private void RegexButton_Click(object sender, RoutedEventArgs e)
        {
            string regex = generateRegex();
            if(regex != null) {
                Clipboard.SetText(regex);
                ShowNotification("Generated regex was copied to your clipboard");
            }
            //new RegexOutput() {Regex = generateRegex() }.Show();
            
            
        }

        private void ShowNotification(string text)
        {
            NotificationTextBlock.Text = text;
            Storyboard sb = this.FindResource("ShowNotifcation") as Storyboard;
            Storyboard.SetTarget(sb, this.NotificationGird);
            sb.Begin();
        }

        
    }
}
