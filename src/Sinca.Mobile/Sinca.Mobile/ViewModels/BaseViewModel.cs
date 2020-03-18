using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Sinca.Mobile.Services;
using AutoMapper;

namespace Sinca.Mobile.ViewModels
{
    public class BaseViewModel<TEntityDto> : INotifyPropertyChanged
    {
        #region Blinding
        private TEntityDto _dto;
        public TEntityDto Dto { get { return _dto; } set { SetProperty(ref _dto, value); } }
        #endregion

        public IMapper Mapper { get; set; }
        public IInitialize DataStore { get; set; }

        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public BaseViewModel()
        {
            DataStore = DependencyService.Get<IInitialize>();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<ClienteDto, CreateUpdateClienteDto>(); });
            Mapper = config.CreateMapper();
        }

        internal void NovoDto()
        {
            Dto = Activator.CreateInstance<TEntityDto>();
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
