using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Validation.Model;

namespace Validation.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Contact> _contacts;
        public ObservableCollection<Contact> Contacts
        {
            get { return _contacts; }
            set
            {
                _contacts = value;
                OnPropertyChanged(nameof(Contacts));
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        // 构造函数中初始化Commands、加载数据等操作
        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand(AddContact);
            EditCommand = new RelayCommand(EditContact, CanEditContact);
            DeleteCommand = new RelayCommand(DeleteContact, CanDeleteContact);

            LoadData();
        }

        // 添加联系人
        private void AddContact(object obj)
        {
            var newContact = new Contact();
            // 在这里添加新联系人的逻辑
            Contacts.Add(newContact);
        }

        // 编辑联系人
        private void EditContact(object obj)
        {
            var selectedContact = obj as Contact;
            // 在这里编辑选中联系人的逻辑
            // 如果更新成功，需要通知UI更新对应的行
        }

        // 判断是否可以编辑联系人
        private bool CanEditContact(object obj)
        {
            var selectedContact = obj as Contact;
            return selectedContact != null;
        }

        // 删除联系人
        private void DeleteContact(object obj)
        {
            var selectedContact = obj as Contact;
            // 在这里删除选中联系人的逻辑
            Contacts.Remove(selectedContact);
        }

        // 判断是否可以删除联系人
        private bool CanDeleteContact(object obj)
        {
            var selectedContact = obj as Contact;
            return selectedContact != null;
        }

        // 加载数据
        private void LoadData()
        {
            Contacts = new ObservableCollection<Contact>();
            // 在这里加载联系人数据的逻辑
        }

        // 实现INotifyPropertyChanged接口，用于通知UI更新属性
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
