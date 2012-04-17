using System;
using System.Collections.Generic;
using System.Linq;
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
using Diplom.MyWindows;
using Diplom.MyClasses;
using System.Windows.Media.Animation;
//using SDKSample;
using System.Drawing;
using System.Windows.Controls.DataVisualization.Charting;


namespace Diplom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Setup();
            kalkulate.Visibility = System.Windows.Visibility.Hidden;
        }

        #region Обработка кнопок главного окна
        // Вызов окна О программе
        private void about_Click(object sender, RoutedEventArgs e)
        {
            About about = About.GetAbout();
            about.Show();
            about.Activate();

        }

        // Параметры базовой станции GSM
        private void GSM_base_param_Click(object sender, RoutedEventArgs e)
        {
            GSM_Base_Params GSMbase = GSM_Base_Params.GetGSM_Base_Params();
            GSMbase.Show();
            GSMbase.Activate();
        }

        // Параметры абонентской станции GSM
        private void GSM_abon_param_Click(object sender, RoutedEventArgs e)
        {
            GSM_Abon_Params GSMabon = GSM_Abon_Params.GetGSM_Abon_Params();
            GSMabon.Show();
            GSMabon.Activate();
        }

        // Параметры базовой станции CDMA
        private void CDMA_base_param_Click(object sender, RoutedEventArgs e)
        {
            CDMA_Base_Params CDMAbase = CDMA_Base_Params.GetCDMA_Base_Params();
            CDMAbase.Show();
            CDMAbase.Activate();
        }

        // Параметры абонентской станции CDMA
        private void CDMA_abon_param_Click(object sender, RoutedEventArgs e)
        {
            CDMA_Abon_Params CDMAabon = CDMA_Abon_Params.GetCDMA_Abon_Params();
            CDMAabon.Show();
            CDMAabon.Activate();
        }

        // Закрытие программы
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Обработка события нажатия кнопки Генерация
        private void Generation_Click(object sender, RoutedEventArgs e)
        {
            MainPanel.Cursor = Cursors.Wait;
            if (numbOfGsmBase >= 0 & numbOfGsmAbon >= 0 & numbOfCdmaBase >= 0 & numbOfCdmaAbon >= 0)
            {
                ClearLists();
                Cleaning();
                FillLists();
                Drawing();
                statusbar.Text = "Станции успешно сгенерированы: GSM Base-" + Storage.GsmBases.Count.ToString() + " Abon-" + Storage.GsmAbons.Count.ToString() + " CDMA Base-" + Storage.CdmaBases.Count.ToString() + " Abon-" + Storage.CdmaAbons.Count.ToString();
            }
            else
            {
                ClearLists();
                Cleaning();
                statusbar.Text = "Введите верное колличество станций";
            }
            MainPanel.Cursor = Cursors.Arrow;
            kalkulate.Visibility = System.Windows.Visibility.Visible;
        }

        // Обработка события нажатия на кнопку Очистить
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            MainPanel.Cursor = Cursors.Wait;
            ClearLists();
            Cleaning();
            statusbar.Text = "Станции успешно удалены: GSM Base-" + Storage.GsmBases.Count.ToString() + " Abon-" + Storage.GsmAbons.Count.ToString() + " CDMA Base-" + Storage.CdmaBases.Count.ToString() + " Abon-" + Storage.CdmaAbons.Count.ToString();
            kalkulate.Visibility = System.Windows.Visibility.Hidden;
            MainPanel.Cursor = Cursors.Arrow;
        }

        // Обработка события нажатия кнопки Рассчета
        private void kalkulate_Click(object sender, RoutedEventArgs e)
        {
            MainPanel.Cursor = Cursors.Wait;
            #region нахождение Isum
            if (Storage.CdmaBases.Count > 0)
            {
                foreach (GSM_Base gsmBase in Storage.GsmBases)
                {
                    gsmBase.SetIsum(Storage.CdmaBases); // нахождение Isum для каждой GSM базовой станции
                    //  gsmBase.SetCarier(gsmAbons); // нахождение Carier для каждого абонента GSM и станции записанной для него как родительская.
                }
            }
            else
            {
                foreach (GSM_Base gsmBase in Storage.GsmBases)
                {
                    gsmBase.Isum = 0; // Если CDMA станций нет, то Isum = 0
                }
            }
            #endregion
            #region нахождение родителя, установка carier, попытка подключиться
            foreach (GSM_Abon abon in Storage.GsmAbons)
            {
                do
                {
                    abon.FindParent(Storage.GsmBases); // нахождение ближайшей базовой для GSM абонентов
                    abon.SetCarier(); // нахождение Carier для каждого абонента
                    abon.TryToConnect();
                } while (abon.Orphan && abon.BadParent.Count != Storage.GsmBases.Count);

            }
            #endregion
            #region подсчет подключенных абонентов и не подключенных
            int connectFirstTime = new int();
            int connectSecondTime = new int();
            int orphan = new int();
            foreach (GSM_Abon abon in Storage.GsmAbons)
            {
                if (abon.Orphan)
                {
                    orphan++;
                }
                if (!abon.Orphan && abon.BadParent.Count == 0)
                {
                    connectFirstTime++;
                }
                if (!abon.Orphan && abon.BadParent.Count > 0)
                {
                    connectSecondTime++;
                }
            }
            Storage.Connecteds.Add(new Connected("Подключились сразу", connectFirstTime));
            Storage.Connecteds.Add(new Connected("Подключились не сразу", connectSecondTime));
            Storage.Connecteds.Add(new Connected("Не подключились", orphan));
            #endregion
            MainPanel.Cursor = Cursors.Arrow;
            #region вывод окна с результатами
            Results Result = Results.GetResults();
            Result.Show();
            Result.Activate();
            #endregion
        }
        #endregion

        #region заполнение и очистка списков
        private void FillLists() // Заполнение списков
        {
            for (int i = 0; i < numbOfGsmBase; i++)
            {
                Storage.GsmBases.Add(new GSM_Base(rand.Next(size_X), rand.Next(size_Y)));
            }
            for (int i = 0; i < numbOfGsmAbon; i++)
            {
                Storage.GsmAbons.Add(new GSM_Abon(rand.Next(size_X), rand.Next(size_Y)));
            }
            for (int i = 0; i < numbOfCdmaBase; i++)
            {
                Storage.CdmaBases.Add(new CDMA_Base(rand.Next(size_X), rand.Next(size_Y)));
            }
            for (int i = 0; i < numbOfCdmaAbon; i++)
            {
                Storage.CdmaAbons.Add(new CDMA_Abon(rand.Next(size_X), rand.Next(size_Y)));
            }

        }

        private void ClearLists() // Очистка списков
        {
            Storage.GsmBases.Clear();
            Storage.GsmAbons.Clear();
            Storage.CdmaBases.Clear();
            Storage.CdmaAbons.Clear();
            Storage.Connecteds.Clear();
            Storage.AbonsResults.Clear();
            Storage.BaseResults.Clear();
            GSM_Abon.Count = 0;
            GSM_Base.Count = 0;
        }
        #endregion

        #region обработка рисования
        private void Drawing()
        { // отрисовка списков станций
            GSM_base_graph.DataContext = Storage.GsmBases;
            GSM_abon_graph.DataContext = Storage.GsmAbons;
            CDMA_base_graph.DataContext = Storage.CdmaBases;
            CDMA_abon_graph.DataContext = Storage.CdmaAbons;
        }

        private void Cleaning()
        { // Стирание списков станций
            GSM_base_graph.DataContext = null;
            GSM_abon_graph.DataContext = null;
            CDMA_base_graph.DataContext = null;
            CDMA_abon_graph.DataContext = null;
        }

        #endregion

        #region Поля

        Random rand = new Random();
        public int numbOfGsmBase { get; set; }
        public int numbOfGsmAbon { get; set; }
        public int numbOfCdmaBase { get; set; }
        public int numbOfCdmaAbon { get; set; }
        private int size_Y;
        private int size_X;
        #endregion

        #region проверка ввода колличества станций и размеров поля
        private void numbGsmBase_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                kalkulate.Visibility = System.Windows.Visibility.Hidden;
            }
            catch (Exception) { }

            try
            {
                numbOfGsmBase = Int32.Parse(numbGsmBase.Text);
            }
            catch (Exception)
            {
                numbOfGsmBase = 0;
                numbGsmBase.Text = "";
            }
        }

        private void numbGsmAbon_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                kalkulate.Visibility = System.Windows.Visibility.Hidden;
            }
            catch (Exception) { }
            try
            {
                numbOfGsmAbon = Int32.Parse(numbGsmAbon.Text);

            }
            catch (Exception)
            {
                numbOfGsmAbon = 0;
                numbGsmAbon.Text = "";
            }
        }

        private void numbCdmaBase_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                kalkulate.Visibility = System.Windows.Visibility.Hidden;
            }
            catch (Exception) { }
            try
            {
                numbOfCdmaBase = Int32.Parse(numbCdmaBase.Text);
            }
            catch (Exception)
            {
                numbOfCdmaBase = 0;
                numbCdmaBase.Text = "";
            }
        }

        private void numbCdmaAbon_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                kalkulate.Visibility = System.Windows.Visibility.Hidden;
            }
            catch (Exception) { }
            try
            {
                numbOfCdmaAbon = Int32.Parse(numbCdmaAbon.Text);
            }
            catch (Exception)
            {
                numbOfCdmaAbon = 0;
                numbCdmaAbon.Text = "";
            }

        }

        private void text_size_X_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                kalkulate.Visibility = System.Windows.Visibility.Hidden;
            }
            catch (Exception) { }
            try
            {
                size_X = Int32.Parse(text_size_X.Text);
            }
            catch (Exception)
            {
                size_X = 0;
                text_size_X.Text = "";
                statusbar.Text = "Размер поля должен быть целым числом, больше нуля";
            }
        }

        private void text_size_Y_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                kalkulate.Visibility = System.Windows.Visibility.Hidden;
            }
            catch (Exception) { }
            try
            {
                size_Y = Int32.Parse(text_size_Y.Text);
            }
            catch (Exception)
            {
                size_Y = 0;
                text_size_Y.Text = "";
                statusbar.Text = "Размер поля должен быть целым числом, больше нуля";
            }
        }
        #endregion

        #region Обработка события захвата фокуса текстбоксами
        private void text_size_X_GotFocus(object sender, RoutedEventArgs e)
        {
            text_size_X.Text = "";
        }

        private void text_size_Y_GotFocus(object sender, RoutedEventArgs e)
        {
            text_size_Y.Text = "";
        }

        private void numbGsmBase_GotFocus(object sender, RoutedEventArgs e)
        {
            numbGsmBase.Text = "";
        }

        private void numbGsmAbon_GotFocus(object sender, RoutedEventArgs e)
        {
            numbGsmAbon.Text = "";
        }

        private void numbCdmaBase_GotFocus(object sender, RoutedEventArgs e)
        {
            numbCdmaBase.Text = "";
        }

        private void numbCdmaAbon_GotFocus(object sender, RoutedEventArgs e)
        {
            numbCdmaAbon.Text = "";
        }
        #endregion

        #region метод инициализации стартовых параметров базовых станций и абонентов
        private void Setup()
        {
            #region параметры GSM базовой станции
            GSM_Base.Ful = 950; // МГц
            GSM_Base.Fdl = 890; // МГц
            GSM_Base.P = 40;    // Ват
            GSM_Base.G = 17;    // дБ
            GSM_Base.Lf = 3;    // дБ
            #endregion

            #region параметры GSM абонтской станции
            GSM_Abon.P = 2;     // Ват
            GSM_Abon.G = 3;     // дБ
            GSM_Abon.Lf = 3;    // дБ
            #endregion

            #region параметры CDMA базовой станции
            CDMA_Base.Ful = 887; // МГц
            CDMA_Base.Fdl = 830; // МГц
            CDMA_Base.P = 40;    // Ват
            CDMA_Base.G = 17;    // дБ
            CDMA_Base.Lf = 3;    // дБ
            #endregion

            #region параметры CDMA абонтской станции
            CDMA_Abon.P = 2;    // Ват
            CDMA_Abon.G = 3;    // дБ
            CDMA_Abon.Lf = 3;   // дБ
            #endregion
        }
        #endregion
    }
}
