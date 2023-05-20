using Dapper;
using DataAccessLibrary.DbAccess;
using DataAccessLibrary.Models;
using FluentValidation;
using IValve.Events;
using IValve.Validation;
using Stylet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValve.ViewModel
{
    public class NewSupplyViewModel : Screen
    {

        private string _option = "None";
        private string _newSupplyName;
        private readonly IDataAccess _dataAccess;
        private readonly IEventAggregator _eventAggregator;
        private IEnumerable<SupplyTypeModel> _supplyTypes;
        private decimal _amount = 0;
        private string _error;
        private SupplyTypeModel _type;

        public SupplyTypeModel Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    NotifyOfPropertyChange(nameof(Type));
                }
            }
        }


        public string ErrorMessage
        {
            get { return _error; }
            set
            {
                if (_error != value)
                {
                    _error = value;
                    NotifyOfPropertyChange(nameof(ErrorMessage));
                }
            }
        }


        public decimal Amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    NotifyOfPropertyChange(nameof(Amount));
                }
            }
        }
        public IEnumerable<SupplyTypeModel> SupplyTypes
        {
            get { return _supplyTypes; }
            set 
            {
                if(_supplyTypes != value)
                {
                    _supplyTypes = value; 
                    NotifyOfPropertyChange(nameof(SupplyTypes));
                }
            }
        }
        public string NewSupplyName
        {
            get { return _newSupplyName; }
            set 
            { 
                if( _newSupplyName != value )
                {
                    _newSupplyName = value;
                    NotifyOfPropertyChange(nameof(NewSupplyName));
                }
            
            }
        }
        public string Option
        {
            get { return _option; }
            set 
            { 
                if (_option != value)
                {
                    _option = value; 
                    NotifyOfPropertyChange(nameof(Option));
                }
            }
        }

        public NewSupplyViewModel(IDataAccess dataAccess, IEventAggregator eventAggregator )
        {
            _dataAccess = dataAccess;
            _eventAggregator = eventAggregator;
            Task.Run(() => { InitializeData(); }).Wait();
        }

        private async Task InitializeData()
        {
            string SQL = "SELECT * FROM supplytypes";
            SupplyTypes = await _dataAccess.LoadDataSQL<SupplyTypeModel>(SQL);
        }


        public void ChangeOption(string option) 
        {
            Option = option;
        }

        public async Task Add()
        {
            switch (Option)
            {
                case "Drink":
                    {
                        var newDrink = new DrinkModel() { Name = NewSupplyName, Type = Type, Amount = Amount };
                        var validator = new DrinkValidator();
                        var result = validator.Validate(newDrink);

                        if(result.IsValid)
                        {
                            var parameters = new DynamicParameters();
                            parameters.Add("Name", newDrink.Name);
                            parameters.Add("Type", newDrink.Type.Type_ID);
                            parameters.Add("Amount", newDrink.Amount);
                            parameters.Add("new_id", DbType.Int32, direction: ParameterDirection.Output);

                            try
                            {
                                int newID = await _dataAccess.SaveDataSP("sp_NewDrink", parameters);
                                newDrink.Drink_ID = newID;
                                _eventAggregator.Publish(new NewDrinkEvent(newDrink));
                                Clear();
                                ErrorMessage = "";

                            }
                            catch (Exception ex)
                            {
                                ErrorMessage = "Error while saving data";
                            }
                        }
                        else
                        {

                            ErrorMessage = result.Errors.Last().ErrorMessage;
                        }
                    }
                    break;
                case "Food":
                    {
                        var newFood = new FoodModel() { Name = NewSupplyName, Type = Type, Amount = Amount };
                        var validator = new FoodValidator();
                        var result = validator.Validate(newFood);

                        if (result.IsValid)
                        {
                            var parameters = new DynamicParameters();
                            parameters.Add("Name", newFood.Name);
                            parameters.Add("Type", newFood.Type.Type_ID);
                            parameters.Add("Amount", newFood.Amount);
                            parameters.Add("new_id", DbType.Int32, direction: ParameterDirection.Output);

                            try
                            {
                                int newID = await _dataAccess.SaveDataSP("sp_NewFood", parameters);
                                newFood.Food_ID = newID;
                                _eventAggregator.Publish(new NewFoodEvent(newFood));
                                Clear();
                                ErrorMessage = "";

                            }
                            catch (Exception ex)
                            {
                                ErrorMessage = "Error while saving data";
                            }
                        }
                        else
                        {

                            ErrorMessage = result.Errors.Last().ErrorMessage;
                        }
                    }
                    break;
                case "Item":
                    {
                        var newItem = new ItemModel() { Name = NewSupplyName, Type = Type, Amount = (int)Amount };
                        var validator = new ItemValidator();
                        var result = validator.Validate(newItem);

                        if (result.IsValid)
                        {
                            var parameters = new DynamicParameters();
                            parameters.Add("Name", newItem.Name);
                            parameters.Add("Type", newItem.Type.Type_ID);
                            parameters.Add("Amount", newItem.Amount);
                            parameters.Add("new_id", DbType.Int32, direction: ParameterDirection.Output);

                            try
                            {
                                int newID = await _dataAccess.SaveDataSP("sp_NewItem", parameters);
                                newItem.Item_ID = newID;
                                _eventAggregator.Publish(new NewItemEvent(newItem));
                                Clear();
                                ErrorMessage = "";

                            }
                            catch (Exception ex)
                            {
                                ErrorMessage = "Error while saving data";
                            }
                        }
                        else
                        {

                            ErrorMessage = result.Errors.Last().ErrorMessage;
                        }
                    }
                    break;
                default:
                    ErrorMessage = "Invalid option selected";
                    break;
            }
        }

        public void Clear()
        {
            if (Type is null && NewSupplyName == "" && Amount == 0)
                Close();

            NewSupplyName = "";
            Type = null;
            Amount = 0;
        }
        public void Close()
        {
            this.RequestClose();
        }
    }
}
