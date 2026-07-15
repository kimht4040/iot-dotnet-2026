using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WpfMvvm01.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        // 1. 변경될 텍스트 데이터를 담는 변수
        private string _displayText = "버튼을 눌러보세요!";

        // 2. View(화면)와 바인딩될 프로퍼티
        public string DisplayText
        {
            get { return _displayText; }
            set
            {
                _displayText = value;
                OnPropertyChanged(); // 값이 변경되었음을 View에 알림
            }
        }

        // 3. 버튼 클릭 시 실행될 Command
        public ICommand ChangeTextCommand { get; }

        public ViewModel()
        {
            // Command에 실행할 메서드 연결
            ChangeTextCommand = new RelayCommand(ChangeText);
        }

        // 4. 실제 텍스트를 변경하는 로직
        private void ChangeText()
        {
            DisplayText = "글자가 성공적으로 변경되었습니다!";
        }

        // --- INotifyPropertyChanged 구현부 ---
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}