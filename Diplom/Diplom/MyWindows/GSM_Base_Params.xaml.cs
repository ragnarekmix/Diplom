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
    /// Interaction logic for GSM_Base_Params.xaml
    /// </summary>
    public partial class GSM_Base_Params : Window
    {
        #region Реализация шаблона Одиночка
        private GSM_Base_Params()
        {
            InitializeComponent();
            Initializing();
        }
        private static GSM_Base_Params instance;
        public static GSM_Base_Params GetGSM_Base_Params()
        {

            if (instance == null)
            {
                instance = new GSM_Base_Params();
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
                GSM_Base.Ful = Double.Parse(Ful.Text);
            }
            catch (Exception)
            {
            }
            try
            {
                GSM_Base.Fdl = Double.Parse(Fdl.Text);
            }
            catch (Exception)
            {
            }
            try
            {
                GSM_Base.P = Double.Parse(P.Text);
            }
            catch (Exception)
            {
            }
            try
            {
                GSM_Base.G = Double.Parse(G.Text);
            }
            catch (Exception)
            {
            }
            try
            {
                GSM_Base.Lf = Double.Parse(L.Text);
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
            Ful.Text = GSM_Base.Ful.ToString();
            Fdl.Text = GSM_Base.Fdl.ToString();
            P.Text = GSM_Base.P.ToString();
            G.Text = GSM_Base.G.ToString();
            L.Text = GSM_Base.Lf.ToString();
        }
    }
}
