using System.Windows;

namespace WhoWantsMoney
{
    class ErrorService
    {
        private string _ErrorMessage;
        private string _ErrorTitle;
        private MessageBoxImage _ErrorType;

        public ErrorService(string ErrorMessage, string ErrorTitle, string type)
        {
            this._ErrorMessage = ErrorMessage;
            this._ErrorTitle = ErrorTitle;
            
            switch(type)
            {
                case "err":
                    this._ErrorType = MessageBoxImage.Error;
                    break;
                case "warn":
                    this._ErrorType = MessageBoxImage.Warning;
                    break;
                default:
                    this._ErrorType = MessageBoxImage.Information;
                    break;
            }
        }

        public void CallErrorWindow()
        {
            MessageBox.Show(this._ErrorMessage, this._ErrorTitle, MessageBoxButton.OK, this._ErrorType);
        }
    }
}
