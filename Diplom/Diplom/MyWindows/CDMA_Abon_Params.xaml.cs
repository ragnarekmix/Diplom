using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for CDMA_Abon_Params.xaml
    /// </summary>
    public partial class CDMA_Abon_Params : Window
    {
        #region Реализация шаблона Одиночка
        private CDMA_Abon_Params() {
            InitializeComponent();
            Initializing();
        }
        private static CDMA_Abon_Params instance;
        public static CDMA_Abon_Params GetCDMA_Abon_Params() {

            if(instance == null)
            {
                instance = new CDMA_Abon_Params();
            }
            return instance;

        }
        #endregion

        private void Cansel_Click(object sender, RoutedEventArgs e) {
            this.Close();
            instance = null;
        }

        private void Ok_Click(object sender, RoutedEventArgs e) {
            try
            {
                CDMA_Abon.P = Double.Parse(P.Text);
            }
            catch (Exception)
            {
            }
            try
            {
                CDMA_Abon.G = Double.Parse(G.Text);
            }
            catch (Exception)
            {
            }
            try
            {
                CDMA_Abon.Lf = Double.Parse(L.Text);
            }
            catch (Exception)
            {
            }
            this.Close();
            instance = null;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            instance = null;
        }

        private void Initializing()
        {
            P.Text = CDMA_Abon.P.ToString();
            G.Text = CDMA_Abon.G.ToString();
            L.Text = CDMA_Abon.Lf.ToString();
        }
    }
}
