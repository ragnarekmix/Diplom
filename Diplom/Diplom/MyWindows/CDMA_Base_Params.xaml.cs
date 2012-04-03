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
using System.Windows.Shapes;
using Diplom.MyClasses;

namespace Diplom.MyWindows
{
    /// <summary>
    /// Interaction logic for CDMA_Base_Params.xaml
    /// </summary>
    public partial class CDMA_Base_Params : Window
    {
        #region Реализация шаблона Одиночка
        private CDMA_Base_Params()
        {
            InitializeComponent();
            Initializing();
        }
        private static CDMA_Base_Params instance;
        public static CDMA_Base_Params GetCDMA_Base_Params()
        {

            if (instance == null)
            {
                instance = new CDMA_Base_Params();
            }
            return instance;

        }
        #endregion

        private void Cansel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            instance = null;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CDMA_Base.Ful = Double.Parse(Ful.Text);
            }
            catch (Exception)
            {
            }
            try
            {
                CDMA_Base.Fdl = Double.Parse(Fdl.Text);
            }
            catch (Exception)
            {
            }
            try
            {
                CDMA_Base.P = Double.Parse(P.Text);
            }
            catch (Exception)
            {
            }
            try
            {
                CDMA_Base.G = Double.Parse(G.Text);
            }
            catch (Exception)
            {
            }
            try
            {
                CDMA_Base.Lf = Double.Parse(L.Text);
            }
            catch (Exception)
            {
            }
            this.Close();
            instance = null;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            instance = null;
        }

        private void Initializing()
        {
            Ful.Text = CDMA_Base.Ful.ToString();
            Fdl.Text = CDMA_Base.Fdl.ToString();
            P.Text = CDMA_Base.P.ToString();
            G.Text = CDMA_Base.G.ToString();
            L.Text = CDMA_Base.Lf.ToString();
        }
    }
}
