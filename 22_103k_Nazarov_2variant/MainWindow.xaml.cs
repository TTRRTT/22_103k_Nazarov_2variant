using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _22_103k_Nazarov_2variant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool isVowel(char ch)
        {
            ch = char.ToLower(ch);
            if (ch == 'a' || ch == 'e' || ch == 'u' || ch == 'i' || ch == 'o')
                return true;
            
            return false;
        }
        private void HandleWrongInput()
        {
            tb_input.Background = Brushes.Red;
            tb_input.Foreground = Brushes.White;

            tb_longWord.Text = string.Empty;
            tb_vowelsCount.Text = string.Empty;
        }

        private void tb_input_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_input.Background == Brushes.White)
                return;

            tb_input.Background = Brushes.White;
            tb_input.Foreground = Brushes.Black;
        }

        private void btn_execute_Click(object sender, RoutedEventArgs e)
        {
            if (tb_input.Text == string.Empty)
            {
                HandleWrongInput();
                return;
            }

            int vowelCounter = 0;
            string longestWord = "";

            foreach (var str in tb_input.Text.Split(" ", StringSplitOptions.RemoveEmptyEntries))
            {
                foreach (var ch in str)
                {
                    if (isVowel(ch))
                        vowelCounter++;
                }

                if (str.Length > longestWord.Length)
                    longestWord = str;
            }

            tb_vowelsCount.Text = vowelCounter.ToString();
            tb_longWord.Text = longestWord;
        }
    }
}