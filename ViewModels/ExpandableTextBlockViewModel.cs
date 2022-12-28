using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikipediaAPI.ViewModels
{
    public class ExpandableTextBlockViewModel : BaseViewModel
    {
		private string content;

		public string Content
		{
			get { return content; }
			set { content = value; OnPropertyChanged(); }
		}

		private string title;

		public string Title
		{
			get { return title; }
			set { title = value; OnPropertyChanged(); }
		}

	}
}
