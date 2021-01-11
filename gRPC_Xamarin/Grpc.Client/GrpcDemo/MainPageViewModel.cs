using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;

namespace GrpcDemo
{
    public class MainPageViewModel: BaseViewModel
    {
        public MainPageViewModel()
        {
        }
        public ICommand SendGreetingCommand => new Command(async () => await SendGreetingAsync());
        private String _greetingText;
        public String GreetingText
        {
            get { return _greetingText; }
            set { SetProperty(ref _greetingText, value); }
        }
        private String _greetingResult;
        public String GreetingResult
        {
            get { return _greetingResult; }
            set { SetProperty(ref _greetingResult, value); }
        }
      

        private async Task SendGreetingAsync()
        {
          var result = await App.GreeterService.SayHelloAsync(_greetingText);
            GreetingResult = result;
        }
    }
}
