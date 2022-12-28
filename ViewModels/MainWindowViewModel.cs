using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using WikipediaAPI.Commands;
using WikipediaAPI.Models;
using WikipediaAPI.Services;
using WikipediaAPI.Views;

namespace WikipediaAPI.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public RelayCommand MouseEnterCommand { get; set; }
        public RelayCommand MouseLeaveCommand { get; set; }
        public RelayCommand IsFocusedCommand { get; set; }
        public RelayCommand IsNotFocusedCommand { get; set; }
        public RelayCommand ClearCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }

        private ObservableCollection<UIElement> results = new ObservableCollection<UIElement>();

        public ObservableCollection<UIElement> Results
        {
            get { return results; }
            set { results = value; OnPropertyChanged(); }
        }

        public TextBox SearchTb { get; set; }

        public string DefaultText { get; set; } = "Search Wikipedia";

        public MainWindowViewModel()
        {
            MouseEnterCommand = new RelayCommand((m) =>
            {
                if (SearchTb.Text.Trim() == DefaultText)
                {
                    SearchTb.Text = String.Empty;
                }
            });

            MouseLeaveCommand = new RelayCommand((m) =>
            {
                if (SearchTb.Text.Trim() == String.Empty && SearchTb.IsFocused == false)
                {
                    SearchTb.Text = DefaultText;
                }
            });

            IsFocusedCommand = new RelayCommand((i) =>
            {
                SearchTb.Foreground = Brushes.Black;
            });

            IsNotFocusedCommand = new RelayCommand((i) =>
            {
                string text = SearchTb.Text.Trim();
                if (text == String.Empty || text == DefaultText)
                {
                    SearchTb.Text = DefaultText;
                }
            });

            SearchCommand = new RelayCommand((s) =>
            {
                string search = SearchTb.Text.Trim();
                Results.Clear();
                List<WikiModel> indexes;
                try
                {
                    indexes = WikipediaService.GetPageIndexes(search).Result;
                }
                catch (Exception)
                {
                    Results.Add(new NoResultUC());
                    return;
                }

                foreach (var index in indexes)
                {
                    var wikiText = WikipediaService.GetDataByPageId(index.PageId).Result;

                    var expandableTB = new ExpandableTextBlock();
                    var expandableTBVM = new ExpandableTextBlockViewModel();
                    expandableTB.DataContext = expandableTBVM;
                    expandableTBVM.Content = wikiText.Text;
                    expandableTBVM.Title = wikiText.Title;

                    Results.Add(expandableTB);
                }
            });

            ClearCommand = new RelayCommand((c) =>
            {
                SearchTb.Text = string.Empty;
            });

        }
    }
}
