//05
using HarryPotterApp.Models;

namespace HarryPotterApp.ViewModels
{
    public class CharacterViewModel : BaseViewModel
    {
        private string __id;

        public string _id
        {
            get { return __id; }
            set { __id = value; OnPropertyChanged(); }
        }

        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        private string _role;

        public string role
        {
            get { return _role; }
            set { _role = value; OnPropertyChanged(); }
        }

        private string _house;

        public string house
        {
            get { return _house; }
            set { _house = value; OnPropertyChanged(); }
        }

        private string _school;

        public string school
        {
            get { return _school; }
            set { _school = value; OnPropertyChanged(); }
        }

        private int ___v;

        public int __v
        {
            get { return ___v; }
            set { ___v = value; OnPropertyChanged(); }
        }

        private bool _ministryOfMagic;

        public bool ministryOfMagic
        {
            get { return _ministryOfMagic; }
            set { _ministryOfMagic = value; OnPropertyChanged(); }
        }

        private bool _orderOfThePhoenix;

        public bool orderOfThePhoenix
        {
            get { return _orderOfThePhoenix; }
            set { _orderOfThePhoenix = value; OnPropertyChanged(); }
        }

        private bool _dumbledoresArmy;

        public bool dumbledoresArmy
        {
            get { return _dumbledoresArmy; }
            set { _dumbledoresArmy = value; OnPropertyChanged(); }
        }

        private bool _deathEater;

        public bool deathEater
        {
            get { return _deathEater; }
            set { _deathEater = value; OnPropertyChanged(); }
        }

        private string _bloodStatus;

        public string bloodStatus
        {
            get { return _bloodStatus; }
            set { _bloodStatus = value; OnPropertyChanged(); }
        }

        private string _species;

        public string species
        {
            get { return _species; }
            set { _species = value; OnPropertyChanged(); }
        }

        private string _boggart;

        public string boggart
        {
            get { return _boggart; }
            set { _boggart = value; OnPropertyChanged(); }
        }

        private string _alias;

        public string alias
        {
            get { return _alias; }
            set { _alias = value; OnPropertyChanged(); }
        }

        private string _animagus;

        public string animagus
        {
            get { return _animagus; }
            set { _animagus = value; OnPropertyChanged(); }
        }

        private string _wand;

        public string wand
        {
            get { return _wand; }
            set { _wand = value; OnPropertyChanged(); }
        }

        private string _patronus;

        public string patronus
        {
            get { return _patronus; }
            set { _patronus = value; OnPropertyChanged(); }
        }

        public CharacterViewModel()
        {

        }

        public CharacterViewModel(HPCharacter character)
        {
            _id = character._id;
            name = character.name;
            role = character.role;
            house = character.house;
            school = character.school;
            __v = character.__v;
            ministryOfMagic = character.ministryOfMagic;
            orderOfThePhoenix = character.orderOfThePhoenix;
            dumbledoresArmy = character.dumbledoresArmy;
            deathEater = character.deathEater;
            bloodStatus = character.bloodStatus;
            species = character.species;
            boggart = character.boggart;
            alias = character.alias;
            animagus = character.animagus;
            wand = character.wand;
            patronus = character.patronus;
        }

        public HPCharacter GetCharacter()
        {
            return new HPCharacter()
            {
                _id = this._id,
                alias = this.alias,
                animagus = this.animagus,
                bloodStatus = this.bloodStatus,
                boggart = this.boggart,
                deathEater = this.deathEater,
                dumbledoresArmy = this.dumbledoresArmy,
                house = this.house,
                ministryOfMagic = this.ministryOfMagic,
                name = this.name,
                orderOfThePhoenix = this.orderOfThePhoenix,
                patronus = this.patronus,
                role = this.role,
                school = this.school,
                species = this.species,
                wand = this.wand,
                __v  = this.__v
            };
        }
    }
}
