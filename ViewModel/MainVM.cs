using GalaSoft.MvvmLight.Command;
using Lesson_01._07._2023__Command_.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_01._07._2023__Command_.ViewModel
{
    internal class MainVM : INotifyPropertyChanged
    {
        public ObservableCollection<User> Users { get; set; }
        private User selectedUser;

        public User MySelectedUser
        {
            get { return selectedUser; }
            set { selectedUser = value; OnPropertyChanged("MySelectedUser"); }
        }


        private RelayCommand addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                if (addCommand == null)
                    addCommand = new RelayCommand(AddTestUser);

                return addCommand;
            }
        }

        private RelayCommand deleteCommand;

        public RelayCommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                    deleteCommand = new RelayCommand(DeleteUser);

                return deleteCommand;
            }
        }


        public MainVM()
        {
            Users = new ObservableCollection<User>()
            {
                new User() {Id = 1, Email = "vasil@yandex.ru", Name = "Artem"},
                new User() {Id = 2, Email = "bigbebrik@gmail.com", Name = "Kolya" }
            };
            MySelectedUser = Users[0];
        }

        public void AddTestUser() => Users.Add(new User() { Id = Users.LastOrDefault().Id + 1, Email = "test@mail.mu", Name = "Test" });

        public void DeleteUser() => Users.Remove(selectedUser);

        //public void ParamTest(object obj) => Users.Add(new User() { Id = Users.LastOrDefault().Id + 1, Email = "test@mail.mu", Name = "Test" });

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
