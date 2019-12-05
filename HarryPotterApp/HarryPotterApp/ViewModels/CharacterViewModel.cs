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
            __v = character.__v;
            name = character.name;
            role = character.role;
            wand = character.wand;
            alias = character.alias;
            house = character.house;
            school = character.school;
            boggart = character.boggart;
            species = character.species;
            animagus = character.animagus;
            patronus = character.patronus;
            deathEater = character.deathEater;
            bloodStatus = character.bloodStatus;
            dumbledoresArmy = character.dumbledoresArmy;
            ministryOfMagic = character.ministryOfMagic;
            orderOfThePhoenix = character.orderOfThePhoenix;
        }

        public HPCharacter GetCharacter()
        {
            return new HPCharacter()
            {
                _id = this._id,
                __v  = this.__v,
                name = this.name,
                role = this.role,
                wand = this.wand,
                alias = this.alias,
                house = this.house,
                school = this.school,
                boggart = this.boggart,
                species = this.species,
                animagus = this.animagus,
                patronus = this.patronus,
                deathEater = this.deathEater,
                bloodStatus = this.bloodStatus,
                dumbledoresArmy = this.dumbledoresArmy,
                ministryOfMagic = this.ministryOfMagic,
                orderOfThePhoenix = this.orderOfThePhoenix,
            };
        }
    }
}
