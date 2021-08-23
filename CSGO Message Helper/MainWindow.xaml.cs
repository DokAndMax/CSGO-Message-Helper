using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CSGO_Message_Helper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Langs rus = new Langs("*МЕРТВ*", "(Террорист)", "(Спецназовец)", "Молодцы!", "База террористов ", "База спецназа ");
        readonly Langs eng = new Langs("*DEAD*", "(Terrorist)", "(Counter-Terrorist)", "Cheer!", "T Start ", "CT Start ");

        Langs selectedlang;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }

        private void GenerateResult (object sender, RoutedEventArgs e)
        {
            string TeamColor;
            string MessageResult = "";
            string ReversedString = "";
            if (CTTeam.IsChecked == true)
                TeamColor = "#a2c6ff";
            else
                TeamColor = "#ffdf93";
            ResultMessage.Text = "";
            ResultMessage.Inlines.Add(new Run("● ") { Foreground = BrushFromHex("#00b562") });
            ResultMessage.Inlines.Add(new Run("YourNickName @ ") { Foreground = BrushFromHex(TeamColor) });
            ResultMessage.Inlines.Add(new Run("Somewhere ") { Foreground = BrushFromHex("#40ff40") });
            ResultMessage.Inlines.Add(new Run("● ") { Foreground = BrushFromHex("#00b562") });
            ResultMessage.Inlines.Add(new Run("(RADIO): " + selectedlang.radioMessage + "\n") { Foreground = BrushFromHex(TeamColor) });
            ResultMessage.Inlines.Add(new Run("● ") { Foreground = BrushFromHex(((PlayerColors)ColorsCB.SelectedItem).ProgrammTextColor) });
            MessageResult += "playerradio radio.cheer \"" + selectedlang.radioMessage + "\u2029\x202E"; // початок команди, додоаємо символ RIGHT-TO-LEFT 

            ReversedString += "●" + ((PlayerColors)ColorsCB.SelectedItem).CSGOColor + " "; // додаємо в реверсивну строчку маркер кольору гравця
            if (IsDead.IsChecked == true)
            {
                ReversedString += selectedlang.dead; // якщо гравець мертвий, додаємо префікс
                ResultMessage.Inlines.Add(new Run(selectedlang.dead) { Foreground = BrushFromHex(TeamColor) });
            }

            if (IsTeamMessage.IsChecked == true && CTTeam.IsChecked == true)
            {
                ReversedString += selectedlang.TeamCT; // якщо гравець використовує командний чат і грає за КТ
                ResultMessage.Inlines.Add(new Run(selectedlang.TeamCT) { Foreground = BrushFromHex(TeamColor) });
            }
            else if (IsTeamMessage.IsChecked == true)
            {
                ReversedString += selectedlang.TeamT; // якщо гравець використовує командний чат і грає за Т
                ResultMessage.Inlines.Add(new Run(selectedlang.TeamT) { Foreground = BrushFromHex(TeamColor) });
            }

            ReversedString += " " + VictimNick.Text; // додаємо нік гравця і перед ним пробіл
            ResultMessage.Inlines.Add(new Run(" " + VictimNick.Text) { Foreground = BrushFromHex(TeamColor) });

            if (IsTeamMessage.IsChecked == true && IsDead.IsChecked != true)
            {
                ReversedString += " @ "; // якщо гравець живий і використовує командний чат, то додаємо собаку до реверсивної строчки
                ResultMessage.Inlines.Add(new Run(" @ ") { Foreground = BrushFromHex(TeamColor) });
            }

            if (IsDead.IsChecked == true && IsTeamMessage.IsChecked == true)
            {
                ReversedString += " :  "; // два пробіли в командному чаті (без зеленого тексту)
                ResultMessage.Inlines.Add(new Run(" :  ") { Foreground = BrushFromHex(TeamColor) });
            }
            else if (IsDead.IsChecked != false || IsTeamMessage.IsChecked != true)
            {
                ReversedString += " :"; // один  пробіл в загальному чаті (без зеленого тексту)
                ResultMessage.Inlines.Add(new Run(" : ") { Foreground = BrushFromHex(TeamColor) });
            }

            MessageResult += ReverseString(ReversedString); // отдзеркалюємо строчку

            if (IsTeamMessage.IsChecked == true && CTTeam.IsChecked == true && IsDead.IsChecked != true) // ЗЕЛЕНИЙ ЧАТ
            {
                MessageResult += "\x202C\x04" + selectedlang.positionCT + ":  "; // додоаємо символ який позначає закінчення RIGHT-TO-LEFT,
                                                                                 // і вказуємо положення гравця КТ
                ResultMessage.Inlines.Add(new Run(selectedlang.positionCT + ":  ") { Foreground = BrushFromHex("#40ff40") });
            }
            else if (IsTeamMessage.IsChecked == true && IsDead.IsChecked != true)
            {
                MessageResult += "\x202C\x04" + selectedlang.positionT + ":  "; // додоаємо символ який позначає закінчення RIGHT-TO-LEFT,
                                                                                // і вказуємо положення гравця Т
                ResultMessage.Inlines.Add(new Run(selectedlang.positionT + ":  ") { Foreground = BrushFromHex("#40ff40") });
            }
            else
                MessageResult += "\x202C\x01  "; // додоаємо символ який позначає закінчення RIGHT-TO-LEFT
            MessageResult += "\x01" + Message.Text + "\""; // саме повідомлення
            ResultMessage.Inlines.Add(new Run(Message.Text) { Foreground = BrushFromHex("#ffffff") });

            Clipboard.SetText(MessageResult);

        }
        public static string ReverseString(string myStr)
        {
            char[] myArr = myStr.ToCharArray();
            Array.Reverse(myArr);
            return new String(myArr);

        }
        public SolidColorBrush BrushFromHex(string hexColorString)
        {
            if (CTTeam.IsChecked == true && hexColorString == "#Yellow")
                return BrushFromHex("#a2c6ff");
            else if (hexColorString == "#Yellow")
                return BrushFromHex("#ffdf93");
            return (SolidColorBrush)new BrushConverter().ConvertFrom(hexColorString);
        }

        private void EngLang_Checked(object sender, RoutedEventArgs e)
        {
            selectedlang = eng;
        }

        private void RusLang_Checked(object sender, RoutedEventArgs e)
        {
            selectedlang = rus;
        }

        private void VictimNick_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = ((TextBox)sender).Text;
            if (!String.IsNullOrEmpty(text) && text.Substring(0, 1).All(char.IsDigit))
                ((TextBox)sender).Text = text.Remove(0, 1);
        }
    }
}
