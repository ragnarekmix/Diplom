﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diplom.MyClasses
{
    class Storage
    {
        private Storage()
        {
        }

        private static List<GSM_Base> _gsmBaseStorage = new List<GSM_Base>(); // статическая переменная для хранения GSM станций
        public static List<GSM_Base> GsmBases // поле для доступа к GSM станциям
        {
            get { return _gsmBaseStorage; }
            set { _gsmBaseStorage = value; }
        }

        private static List<CDMA_Base> _cdmaBaseStorage = new List<CDMA_Base>(); // статическая переменная для хранения CDMA станций
        public static List<CDMA_Base> CdmaBases // поле для доступа к CDMA станциям
        {
            get { return _cdmaBaseStorage; }
            set { _cdmaBaseStorage = value; }
        }

        private static List<GSM_Abon> _gsmAbonsStorage = new List<GSM_Abon>(); // статическая переменная для хранения GSM абонентов
        public static List<GSM_Abon> GsmAbons // поле для доступа к GSM абонентам
        {
            get { return _gsmAbonsStorage; }
            set { _gsmAbonsStorage = value; }
        }

        private static List<CDMA_Abon> _cdmaAbonsStorage = new List<CDMA_Abon>(); // статическая переменная для хранения CDMA абонентов
        public static List<CDMA_Abon> CdmaAbons // поле для доступа к CDMA абонентам
        {
            get { return _cdmaAbonsStorage; }
            set { _cdmaAbonsStorage = value; }
        }

        private static List<Connected> _connecteds = new List<Connected>(); // Статическая переменная для хранения результатов подключения абонентов GSM
        public static List<Connected> Connecteds // Поле для доступа к результатам подключения абонентов GSM
        {
            get { return _connecteds; }
            set { _connecteds = value; }
        }

        private static List<AbonsResult> _abonsResults = new List<AbonsResult>(); // Результаты по абонентам
        public static List<AbonsResult> AbonsResults
        {
            get { return _abonsResults; }
            set { _abonsResults = value; }
        }

        private static List<BaseResults> _baseResults = new List<BaseResults>(); // Результаты по базовым
        public static List<BaseResults> BaseResults
        {
            get { return _baseResults; }
            set { _baseResults = value; }
        }
    }
}
