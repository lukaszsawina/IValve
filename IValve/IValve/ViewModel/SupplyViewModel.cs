using DataAccessLibrary.DbAccess;
using DataAccessLibrary.Models;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValve.ViewModel
{
    public class SupplyViewModel : Screen
    {
        private readonly IDataAccess _data;
        private readonly IWindowManager _window;
        private readonly NewSupplyViewModel _newSupplyView;
        private BindableCollection<DrinkModel> _drinks;
        private BindableCollection<FoodModel> _food;
        private BindableCollection<ItemModel> _items;

        public BindableCollection<DrinkModel> Drinks
        {
            get { return _drinks; }
            set 
            {
                if(_drinks != value)
                {
                    _drinks = value;
                    NotifyOfPropertyChange(nameof(Drinks));
                }
            }
        }

        public BindableCollection<FoodModel> Food
        {
            get { return _food; }
            set
            {
                if (_food != value)
                {
                    _food = value;
                    NotifyOfPropertyChange(nameof(Food));
                }
            }
        }

        public BindableCollection<ItemModel> Items
        {
            get { return _items; }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    NotifyOfPropertyChange(nameof(Items));
                }
            }
        }


        public SupplyViewModel(IDataAccess data, IWindowManager window, NewSupplyViewModel newSupplyView)
        {
            _data = data;
            _window = window;
            _newSupplyView = newSupplyView;
            Task.Run(() => InitialData()).Wait();
        }


        private async Task InitialData()
        {
            Drinks = new BindableCollection<DrinkModel>(await _data.LoadDrinksAsync());
            Food = new BindableCollection<FoodModel>(await _data.LoadFoodAsync());
            Items = new BindableCollection<ItemModel>(await _data.LoadItemsAsync());
        }

        public void ShowNewSupplyWindow()
        {
            _window.ShowWindow(_newSupplyView);
        }
    }
}
