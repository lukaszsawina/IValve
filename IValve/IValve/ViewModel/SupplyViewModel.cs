using Dapper;
using DataAccessLibrary.DbAccess;
using DataAccessLibrary.Models;
using IValve.Events;
using IValve.Validation;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IValve.ViewModel
{
    public class SupplyViewModel : Screen, IHandle<NewDrinkEvent>, IHandle<NewFoodEvent>, IHandle<NewItemEvent>
    {
        private readonly IDataAccess _data;
        private readonly IWindowManager _window;
        private readonly NewSupplyViewModel _newSupplyView;
        private readonly StatisticViewModel _statisticView;
        private readonly IEventAggregator _eventAggregator;
        private BindableCollection<DrinkModel> _drinks;
        private BindableCollection<FoodModel> _food;
        private BindableCollection<ItemModel> _items;
        private BasicSupplyModel _selected = new BasicSupplyModel();

        public BasicSupplyModel Selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value;
                    NotifyOfPropertyChange(nameof(Selected));
                }
            }
        }


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


        public SupplyViewModel(IDataAccess data, IWindowManager window, NewSupplyViewModel newSupplyView, StatisticViewModel statisticView, IEventAggregator eventAggregator)
        {
            _data = data;
            _window = window;
            _newSupplyView = newSupplyView;
            _statisticView = statisticView;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
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

        public void ShowStatisticWindow()
        {
            _statisticView.Statistic.TotalDrink = Drinks.Sum(x => x.Amount);
            _statisticView.Statistic.TotalFood = Food.Sum(x => x.Amount);
            _statisticView.CalcStat();
            _window.ShowWindow(_statisticView);
        }

        public void ChangeSelectedSupplyDrink(object sender, SelectedCellsChangedEventArgs e)
        {
            var s = (DrinkModel)e.AddedCells[0].Item;

            Selected = new BasicSupplyModel()
            {
                Name = s.Name,
                ID = s.Drink_ID,
                Amount = s.Amount,
                Option = "Drink"
            };
        }
        public void ChangeSelectedSupplyFood(object sender, SelectedCellsChangedEventArgs e)
        {
            var s = (FoodModel)e.AddedCells[0].Item;

            Selected = new BasicSupplyModel()
            {
                Name = s.Name,
                ID = s.Food_ID,
                Amount = s.Amount,
                Option = "Food"
            };
        }
        public void ChangeSelectedSupplyItem(object sender, SelectedCellsChangedEventArgs e)
        {
            var s = (ItemModel)e.AddedCells[0].Item;

            Selected = new BasicSupplyModel()
            {
                Name = s.Name,
                ID = s.Item_ID,
                Amount = s.Amount,
                Option = "Item"
            };
        }

        public void Increase()
        {
            if(Selected != null)
            {
                decimal newAmount;
                if (Selected.Option == "Item")
                    newAmount = Selected.Amount + 1.0M;
                else
                    newAmount = Selected.Amount + 0.1M;

                Selected = new BasicSupplyModel()
                {
                    Name = Selected.Name,
                    ID = Selected.ID,
                    Amount = newAmount,
                    Option = Selected.Option
                };
            }
        }
        public void Decrease()
        {

            if (Selected != null)
            {
                decimal newAmount;
                if (Selected.Option == "Item")
                    newAmount = Selected.Amount - 1.0M;
                else
                    newAmount = Selected.Amount - 0.1M;
                Selected = new BasicSupplyModel()
                {
                    Name = Selected.Name,
                    ID = Selected.ID,
                    Amount = newAmount,
                    Option = Selected.Option
                };
            }
        }
        public async Task Confirm()
        {
            switch(Selected.Option) 
            {
                case "Drink":
                    {

                        var parameters = new DynamicParameters();
                        parameters.Add("ID", Selected.ID);
                        parameters.Add("Amount", Selected.Amount);
                        parameters.Add("Option", Selected.Option);

                        try
                        {
                            await _data.UpdateDataSP("sp_EditSupply", parameters);

                            var obj = Drinks.FirstOrDefault(x => x.Drink_ID == Selected.ID);
                            if (obj != null)
                                obj.Amount = Selected.Amount;

                            Selected = null;
                            Drinks.Refresh();
                        }
                        catch (Exception ex)
                        {
                            
                        }
                    }
                    break;
                case "Food":
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("ID", Selected.ID);
                        parameters.Add("Amount", Selected.Amount);
                        parameters.Add("Option", Selected.Option);

                        try
                        {
                            await _data.UpdateDataSP("sp_EditSupply", parameters);

                            var obj = Food.FirstOrDefault(x => x.Food_ID == Selected.ID);
                            if (obj != null)
                                obj.Amount = Selected.Amount;

                            Selected = null;
                            Food.Refresh();
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    break;
                case "Item":
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("ID", Selected.ID);
                        parameters.Add("Amount", Selected.Amount);
                        parameters.Add("Option", Selected.Option);

                        try
                        {
                            await _data.UpdateDataSP("sp_EditSupply", parameters);

                            var obj = Items.FirstOrDefault(x => x.Item_ID == Selected.ID);
                            if (obj != null)
                                obj.Amount = (int)Selected.Amount;

                            Selected = null;
                            Items.Refresh();
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    break;
                default:
                    break;
            }
        }
        public void Handle(NewDrinkEvent drink) 
        {
            Drinks.Add(drink.Drink);
        }
        public void Handle(NewFoodEvent food)
        {
            Food.Add(food.Food);
        }
        public void Handle(NewItemEvent item)
        {
            Items.Add(item.Item);
        }


    }
}
