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
           // ResultPie.DataContext=
        }

        private static Results instance;
        public static Results GetResults()
        {
            if (instance == null)
            {
                instance = new Results();
            }
            return instance;
        }
        #endregion

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            instance = null;
        }
    }
}
