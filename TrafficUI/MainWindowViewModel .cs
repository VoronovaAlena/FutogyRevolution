using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficUI
{
    public class MainWindowViewModel : BaseViewModel
    {
		private string _controller1;
		private string _controller2;
		private string _controller3;
		private string _controller4;
		private string _controller5;
		private string _controller6;
		private string _controller7;
		private string _controller8;
		private string _controller9;
		private string _controller10;

        private string _phase1;
        private string _phase2;
        private string _phase3;
        private string _phase4;
        private string _phase5;
        private string _phase6;
        private string _phase7;
        private string _phase8;
        private string _phase9;
        private string _phase10;

        public string Controller1
        {
            get => _controller1;
            set
            {
                _controller1 = value;
                OnPropertyChanged(nameof(Controller1));
            }
        }
        public string Controller2
        {
            get => _controller2;
            set
            {
                _controller2 = value;
                OnPropertyChanged(nameof(Controller2));
            }
        }

        public string Controller3
        {
            get => _controller3;
            set
            {
                _controller3 = value;
                OnPropertyChanged(nameof(Controller3));
            }
        }

        public string Controller4
        {
            get => _controller4;
            set
            {
                _controller4 = value;
                OnPropertyChanged(nameof(Controller4));
            }
        }

        public string Controller5
        {
            get => _controller5;
            set
            {
                _controller5 = value;
                OnPropertyChanged(nameof(Controller5));
            }
        }

        public string Controller6
        {
            get => _controller6;
            set
            {
                _controller6 = value;
                OnPropertyChanged(nameof(Controller6));
            }
        }

        public string Controller7
        {
            get => _controller7;
            set
            {
                _controller7 = value;
                OnPropertyChanged(nameof(Controller7));
            }
        }

        public string Controller8
        {
            get => _controller8;
            set
            {
                _controller8 = value;
                OnPropertyChanged(nameof(Controller8));
            }
        }

        public string Controller9
        {
            get => _controller9;
            set
            {
                _controller9 = value;
                OnPropertyChanged(nameof(Controller9));
            }
        }

        public string Controller10
        {
            get => _controller10;
            set
            {
                _controller10 = value;
                OnPropertyChanged(nameof(Controller10));
            }
        }

        public string Phase1
        {
            get => _phase1;
            set
            {
                _phase1 = value;
                OnPropertyChanged(nameof(Phase1));
            }
        }
        public string Phase2
        {
            get => _phase2;
            set
            {
                _phase2 = value;
                OnPropertyChanged(nameof(Phase2));
            }
        }

        public string Phase3
        {
            get => _phase3;
            set
            {
                _phase3 = value;
                OnPropertyChanged(nameof(Phase3));
            }
        }

        public string Phase4
        {
            get => _phase4;
            set
            {
                _phase4 = value;
                OnPropertyChanged(nameof(Phase4));
            }
        }

        public string Phase5
        {
            get => _phase5;
            set
            {
                _phase5 = value;
                OnPropertyChanged(nameof(Phase5));
            }
        }

        public string Phase6
        {
            get => _phase6;
            set
            {
                _phase6 = value;
                OnPropertyChanged(nameof(Phase6));
            }
        }

        public string Phase7
        {
            get => _phase7;
            set
            {
                _phase7 = value;
                OnPropertyChanged(nameof(Phase7));
            }
        }

        public string Phase8
        {
            get => _phase8;
            set
            {
                _phase8 = value;
                OnPropertyChanged(nameof(Phase8));
            }
        }

        public string Phase9
        {
            get => _phase9;
            set
            {
                _phase9 = value;
                OnPropertyChanged(nameof(Phase9));
            }
        }

        public string Phase10
        {
            get => _phase10;
            set
            {
                _phase10 = value;
                OnPropertyChanged(nameof(Phase10));
            }
        }


        public void Update()
		{

		}

    }
}
