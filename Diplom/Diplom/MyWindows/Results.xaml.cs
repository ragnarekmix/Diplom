using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
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
            GridResultAbons.ItemsSource = Storage.AbonsResults.ToString();
            // GridResultBases.ItemsSource = Storage.BaseResults;
            foreach (BaseResults result in Storage.BaseResults)
            {
                GridResultBases.Items.Add(result);
            }
            //   List<String> test = GridResultBases.DataContext;
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
        #endregion

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Storage.Connecteds.Clear();
            Storage.AbonsResults.Clear();
            Storage.BaseResults.Clear();
            _instance = null;
        }

        private void GetResultsForAbons(List<GSM_Abon> abons)
        {
            foreach (GSM_Abon abon in abons)
            {
                AbonsResult abonResult = new AbonsResult();
                abonResult.number = abon.Number.ToString();
                if (abon.Orphan)
                {
                    abonResult.connected = "Не подключен";
                    abonResult.parent = "Нет родителя";
                }
                else
                {
                    abonResult.connected = "Подключен";
                    abonResult.parent = abon.Parent.Number.ToString();
                }
                abonResult.carier = abon.Carier.ToString();
                abonResult.power = GSM_Abon.P.ToString();
                abonResult.g = GSM_Abon.G.ToString();
                abonResult.lf = GSM_Abon.Lf.ToString();
                Storage.AbonsResults.Add(abonResult);
            }
        }

        private void GetResultsForBases(List<GSM_Base> bases)
        {
            foreach (GSM_Base gsm in bases)
            {
                BaseResults baseResult = new BaseResults();
                baseResult.number = gsm.Number.ToString();
                baseResult.isum = gsm.Isum.ToString();
                baseResult.ful = GSM_Base.Ful.ToString();
                baseResult.fdl = GSM_Base.Fdl.ToString();
                baseResult.power = GSM_Base.P.ToString();
                baseResult.g = GSM_Base.G.ToString();
                baseResult.lf = GSM_Base.Lf.ToString();
                Storage.BaseResults.Add(baseResult);
            }
        }
    }



}
