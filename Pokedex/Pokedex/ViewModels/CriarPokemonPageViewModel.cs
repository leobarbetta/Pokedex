using Pokedex.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace Pokedex.ViewModels
{
    public class CriarPokemonPageViewModel : BindableBase
    {
        private IPokemonService _pokemonService;
        private INavigationService _navigationService;

        private PokemonViewModel _pokemon = new PokemonViewModel();
        public PokemonViewModel Pokemon
        {
            get { return _pokemon; }
            set { SetProperty(ref _pokemon, value); }
        }

        public DelegateCommand SalvarCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _pokemonService.Inserir(Pokemon);
                    _navigationService.GoBackAsync();
                });
            }
        }

        public CriarPokemonPageViewModel(IPokemonService pokemonService, INavigationService navigationService)
        {
            _pokemonService = pokemonService;
            _navigationService = navigationService;
        }
    }
}
