using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Diplom.MyClasses;

namespace Diplom.MyWindows
{
    /// <summary>
    /// Interaction logic for Results.xaml
    /// </summary>
    public partial class Results : Window
    {
        #region Реализация шаблона Одиночка
        private Results()
        {
            InitializeComponent();
            ResultPie.DataContext = Storage.Connecteds;
            GetResultsForAbons(Storage.GsmAbons);
            GetResultsForBases(Storage.GsmBases);
            GridResultAbons.ItemsSource = Storage.AbonsResults;
            GridResultBases.ItemsSource = Storage.BaseResults;
            ShowIsum();
        }

        private static Results _instance;
        public static Results GetResults()
        {
            if (_instance == null)
            {
                _instance = new Results();
            }
            return _instance;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Storage.Connecteds.Clear();
            Storage.AbonsResults.Clear();
            Storage.BaseResults.Clear();
            GridResultAbons.ItemsSource = null;
            GridResultBases.ItemsSource = null;
            _instance = null;
        }
        #endregion

        #region реализация методов подсчета результатов
        private void GetResultsForAbons(List<GSM_Abon> abons)
        {
            foreach (GSM_Abon abon in abons)
            {
                AbonsResult abonResult = new AbonsResult();
                abonResult.number = abon.Number;
                if (abon.Orphan)
                {
                    abonResult.connected = "Не подключен";
                    abonResult.parent = 0;
                }
                else
                {
                    abonResult.connected = "Подключен";
                    abonResult.parent = abon.Parent.Number;
                }
                abonResult.carier = abon.Carier;
                abonResult.power = GSM_Abon.P;
                abonResult.g = GSM_Abon.G;
                abonResult.lf = GSM_Abon.Lf;
                abonResult.bedparents = abon.BadParent.Count;
                abonResult.cin = abon.CIN;
                Storage.AbonsResults.Add(abonResult);
            }
        }

        private void GetResultsForBases(List<GSM_Base> bases)
        {
            foreach (GSM_Base gsm in bases)
            {
                BaseResults baseResult = new BaseResults();
                baseResult.number = gsm.Number;
                baseResult.isum = gsm.Isum;
                baseResult.ful = GSM_Base.Ful;
                baseResult.fdl = GSM_Base.Fdl;
                baseResult.power = GSM_Base.P;
                baseResult.g = GSM_Base.G;
                baseResult.lf = GSM_Base.Lf;
                foreach (AbonsResult abonResult in Storage.AbonsResults)
                {
                    if (abonResult.parent == gsm.Number)
                    {
                        baseResult.childs++;
                    }
                }
                Storage.BaseResults.Add(baseResult);
            }
        }
        #endregion

        #region управление размерами элементов
        private void cartResultPlus_Click(object sender, RoutedEventArgs e)
        {
            ChartResult.Width = 859;
            DataResult.Width = 0;
        }

        private void dataResultPlus_Click(object sender, RoutedEventArgs e)
        {
            ChartResult.Width = 0;
            DataResult.Width = 859;
            DataResult.Margin = new Thickness(0, 0, 0, 0);
        }

        private void chartResultEquallyDataResult_Click(object sender, RoutedEventArgs e)
        {
            ChartResult.Width = 430;
            DataResult.Width = 430;
            DataResult.Margin = new Thickness(429, 0, 0, 0);
        }

        private void basePlus_Click(object sender, RoutedEventArgs e)
        {
            GridResultBases.Height = 340;
            GridResultAbons.Height = 25;
        }

        private void baseMinus_Click(object sender, RoutedEventArgs e)
        {
            GridResultBases.Height = 25;
            GridResultAbons.Height = 340;
        }

        private void baseEqually_Click(object sender, RoutedEventArgs e)
        {
            GridResultBases.Height = 180;
            GridResultAbons.Height = 180;
        }

        private void abonPlus_Click(object sender, RoutedEventArgs e)
        {
            GridResultBases.Height = 25;
            GridResultAbons.Height = 340;
        }

        private void abonMinus_Click(object sender, RoutedEventArgs e)
        {
            GridResultBases.Height = 340;
            GridResultAbons.Height = 25;
        }

        private void abonEqually_Click(object sender, RoutedEventArgs e)
        {
            GridResultBases.Height = 180;
            GridResultAbons.Height = 180;
        }
        #endregion

        #region вывод данных на график DataResult
        private void ShowIsum()
        {
            this.Cursor = Cursors.Wait;
            if ((bool) LinearGraph.IsChecked)
            {
                DataResult.Series.Clear();
                var Graph = new LineSeries
                {
                    ItemsSource = Storage.BaseResults,
                    DependentValuePath = "isum",
                    IndependentValuePath = "number",
                    Title = "I сумма"
                };
                DataResult.Series.Add(Graph);
            }
            if ((bool) AreaGraph.IsChecked)
            {
                DataResult.Series.Clear();
                var Graph = new AreaSeries
                {
                    ItemsSource = Storage.BaseResults,
                    DependentValuePath = "isum",
                    IndependentValuePath = "number",
                    Title = "I сумма"
                };
                DataResult.Series.Add(Graph);
            }
            if ((bool) ColumnGraph.IsChecked)
            {
                DataResult.Series.Clear();
                var Graph = new ColumnSeries
                {
                    ItemsSource = Storage.BaseResults,
                    DependentValuePath = "isum",
                    IndependentValuePath = "number",
                    Title = "I сумма"
                };
                DataResult.Series.Add(Graph);
            }
            this.Cursor = Cursors.Arrow;
        }
        private void ShowChilds()
        {
            this.Cursor = Cursors.Wait;
            if ((bool)LinearGraph.IsChecked)
            {
                DataResult.Series.Clear();
                var Graph = new LineSeries
                {
                    ItemsSource = Storage.BaseResults,
                    DependentValuePath = "childs",
                    IndependentValuePath = "number",
                    Title = "Абонентов на базовой"
                };
                DataResult.Series.Add(Graph);
            }
            if ((bool)AreaGraph.IsChecked)
            {
                DataResult.Series.Clear();
                var Graph = new AreaSeries
                {
                    ItemsSource = Storage.BaseResults,
                    DependentValuePath = "childs",
                    IndependentValuePath = "number",
                    Title = "Абонентов на базовой"
                };
                DataResult.Series.Add(Graph);
            }
            if ((bool)ColumnGraph.IsChecked)
            {
                DataResult.Series.Clear();
                var Graph = new ColumnSeries
                {
                    ItemsSource = Storage.BaseResults,
                    DependentValuePath = "childs",
                    IndependentValuePath = "number",
                    Title = "Абонентов на базовой"
                };
                DataResult.Series.Add(Graph);
            }
            this.Cursor = Cursors.Arrow;
        }
        private void ShowCarier()
        {
            this.Cursor = Cursors.Wait;
            if ((bool)LinearGraph.IsChecked)
            {
                DataResult.Series.Clear();
                var Graph = new LineSeries
                {
                    ItemsSource = Storage.AbonsResults,
                    DependentValuePath = "carier",
                    IndependentValuePath = "number",
                    Title = "Carier"
                };
                DataResult.Series.Add(Graph);
            }
            if ((bool)AreaGraph.IsChecked)
            {
                DataResult.Series.Clear();
                var Graph = new AreaSeries
                {
                    ItemsSource = Storage.AbonsResults,
                    DependentValuePath = "carier",
                    IndependentValuePath = "number",
                    Title = "Carier"
                };
                DataResult.Series.Add(Graph);
            }
            if ((bool)ColumnGraph.IsChecked)
            {
                DataResult.Series.Clear();
                var Graph = new ColumnSeries
                {
                    ItemsSource = Storage.AbonsResults,
                    DependentValuePath = "carier",
                    IndependentValuePath = "number",
                    Title = "Carier"
                };
                DataResult.Series.Add(Graph);
            }
            this.Cursor = Cursors.Arrow;
        }
        private void ShowCin()
        {
            this.Cursor = Cursors.Wait;
            if ((bool)LinearGraph.IsChecked)
            {
                DataResult.Series.Clear();
                var Graph = new LineSeries
                {
                    ItemsSource = Storage.AbonsResults,
                    DependentValuePath = "cin",
                    IndependentValuePath = "number",
                    Title = "C/(I+N)"
                };
                DataResult.Series.Add(Graph);
            }
            if ((bool)AreaGraph.IsChecked)
            {
                DataResult.Series.Clear();
                var Graph = new AreaSeries
                {
                    ItemsSource = Storage.AbonsResults,
                    DependentValuePath = "cin",
                    IndependentValuePath = "number",
                    Title = "C/(I+N)"
                };
                DataResult.Series.Add(Graph);
            }
            if ((bool)ColumnGraph.IsChecked)
            {
                DataResult.Series.Clear();
                var Graph = new ColumnSeries
                {
                    ItemsSource = Storage.AbonsResults,
                    DependentValuePath = "cin",
                    IndependentValuePath = "number",
                    Title = "C/(I+N)"
                };
                DataResult.Series.Add(Graph);
            }
            this.Cursor = Cursors.Arrow;
        }
        private void ShowBadParents()
        {
            this.Cursor = Cursors.Wait;
            if ((bool)LinearGraph.IsChecked)
            {
                DataResult.Series.Clear();
                var Graph = new LineSeries
                {
                    ItemsSource = Storage.AbonsResults,
                    DependentValuePath = "bedparents",
                    IndependentValuePath = "number",
                    Title = "Попыток подключиться"
                };
                DataResult.Series.Add(Graph);
            }
            if ((bool)AreaGraph.IsChecked)
            {
                DataResult.Series.Clear();
                var Graph = new AreaSeries
                {
                    ItemsSource = Storage.AbonsResults,
                    DependentValuePath = "bedparents",
                    IndependentValuePath = "number",
                    Title = "Попыток подключиться"
                };
                DataResult.Series.Add(Graph);
            }
            if ((bool)ColumnGraph.IsChecked)
            {
                DataResult.Series.Clear();
                var Graph = new ColumnSeries
                {
                    ItemsSource = Storage.AbonsResults,
                    DependentValuePath = "bedparents",
                    IndependentValuePath = "number",
                    Title = "Попыток подключиться"
                };
                DataResult.Series.Add(Graph);
            }
            this.Cursor = Cursors.Arrow;
        }
        #endregion

        #region обработка выбора отображаемого графика
        private void ShowIsumButton_Click(object sender, RoutedEventArgs e)
        {
            ShowIsum();
        }

        private void ShowChildsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowChilds();
        }

        private void ShowCarierButton_Click(object sender, RoutedEventArgs e)
        {
            ShowCarier();
        }

        private void ShowCinButton_Click(object sender, RoutedEventArgs e)
        {
            ShowCin();
        }

        private void ShowBadParentsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowBadParents();
        }
        #endregion
    }
}
