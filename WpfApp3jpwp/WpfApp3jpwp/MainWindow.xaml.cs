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

namespace WpfApp3jpwp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //zmiana położenia figur geoemtrycznych
            MoveObject.ToLeft(Rectangle, 8000);
            MoveObject.ToRight(Rectangle, 8000);
            MoveObject.ToTop(Rectangle, 8000, GAME_FIELD);
            MoveObject.ToBottom(Rectangle, 8000, GAME_FIELD);
        }

        //generacja pseudolosowych liczb do zmiany położenia figur
        public class GeneracjaLiczb
        {
            static int minValue = -1000;
            static int maxValue = 1000;

            static Random xLeft_px = new Random();
            static Random xRight_px = new Random();
            static Random xTop_px = new Random();
            static Random xBottom_px = new Random();

            public int xLeft { get => xLeft; set => xLeft = xLeft_px.Next(minValue, maxValue); }
            public int xRight { get => xRight; set => xRight = xRight_px.Next(minValue, maxValue); }

            public int xTop { get => xTop; set => xTop = xTop_px.Next(minValue, maxValue); }
            public int xBottom { get => xBottom; set => xBottom = xBottom_px.Next(minValue, maxValue); }

        }

        
        public static class MoveObject
        {
            public static void ToLeft(Shape obj, int xLeft)
            {
                double leftPosition = Canvas.GetLeft(obj);
                double newLeftPostition = leftPosition - xLeft;

                if (newLeftPostition < 0)
                    newLeftPostition = 0;

                Canvas.SetLeft(obj, newLeftPostition);
            }

            public static void ToRight(Shape obj, int xRight)
            {
                double leftPosition = Canvas.GetLeft(obj);
                double objWidth = obj.Width;
                double newLeftPostition = leftPosition + xRight;
                var windowWidth = Application.Current.MainWindow.Width;

                if (newLeftPostition + objWidth > windowWidth)
                    newLeftPostition = windowWidth - objWidth - 24; //zmiana parametru do wartosci GAME_FIELD

                Canvas.SetLeft(obj, newLeftPostition);
            }

            public static void ToTop(Shape obj, int xTop, Rectangle gameField)
            {
                double bottomPosition = Canvas.GetBottom(obj);
                double objHeight = obj.Height;
                double newBottomPosition = bottomPosition + xTop;
                var gamefieldHeight = gameField.Height;

                if (newBottomPosition + objHeight > gamefieldHeight)
                    newBottomPosition = gamefieldHeight - objHeight + 5; //zmiana parametru do wartosci GAME_FIELD

                Canvas.SetBottom(obj, newBottomPosition);
            }

            public static void ToBottom(Shape obj, int xBottom, Rectangle gameField)
            {
                double bottomPosition = Canvas.GetBottom(obj);
                double newBottomPosition = bottomPosition - xBottom;

                if (newBottomPosition < 24)
                    newBottomPosition = 24; 

                Canvas.SetBottom(obj, newBottomPosition);
            }
        }

        //button sprawdzający ilość kliknięć pola GAME_INFO
        private void Game_Info_Button_Clicked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("GAME_INFO_button");
        }

        //button powodujący wyjście z gry
        private void End_Game_Button_Clicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //button wyświetlający informacji o użytkowniku
        private void User_Info_Button_Clicked(object sender, RoutedEventArgs e)
        {
            //otworzenie pliku .txt w którym zapisywane są odpalenie programu
        }
    }
}
