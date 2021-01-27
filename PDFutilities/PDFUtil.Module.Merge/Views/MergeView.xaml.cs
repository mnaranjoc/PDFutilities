﻿using PDFUtil.Module.Merge.ViewModels;
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

namespace PDFUtil.Module.Merge.Views
{
    /// <summary>
    /// Interaction logic for MergeView.xaml
    /// </summary>
    public partial class MergeView : UserControl
    {
        public MergeView(MergeViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
