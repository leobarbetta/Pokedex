using Pokedex.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System.Collections.ObjectModel;

namespace Pokedex.ViewModels
{
    public class ListagemPokemonsPageViewModel : BindableBase
    {
        private IPokemonService _pokemonService;
        private INavigationService _navigationService;
        private IPageDialogService _pageDialogService;

        private ObservableCollection<PokemonViewModel> _pokemons = new ObservableCollection<PokemonViewModel>();
        public ObservableCollection<PokemonViewModel> Pokemons
        {
            get { return _pokemons; }
            set { SetProperty(ref _pokemons, value); }
        }

        public DelegateCommand NovoPokemonCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _navigationService.NavigateAsync("NavigationPage/CriarPokemonPage");
                });
            }
        }

        public DelegateCommand<PokemonViewModel> SelecionarPokemonCommand
        {
            get
            {
                return new DelegateCommand<PokemonViewModel>((pokemon) =>
                {
                    IActionSheetButton editarPokemonButton = ActionSheetButton.CreateButton("Editar", () =>
                    {
                        _pageDialogService.DisplayAlertAsync("Editar", $"Editar {pokemon.Nome}", "Ok");
                    });

                    IActionSheetButton excluirPokemonButton = ActionSheetButton.CreateDestroyButton("Excluir", async () =>
                    {
                        bool confirmaExecucao = await _pageDialogService.DisplayAlertAsync("COnfirmação", $"Deseja realmente excluir o {pokemon.Nome}?", "Sim", "Não");

                        if (confirmaExecucao)
                            _pokemonService.Delete(pokemon);
                    });

                    IActionSheetButton detalhePokemonButton = ActionSheetButton.CreateDestroyButton("Detalhe", () =>
                    {
                        _pageDialogService.DisplayAlertAsync("Detalhe", $"Detalhe {pokemon.Nome}", "Ok");
                    });

                    IActionSheetButton cancelaPokemonButton = ActionSheetButton.CreateCancelButton("Cancelar", () =>
                    {
                        _pageDialogService.DisplayAlertAsync("Cancelar", $"Cancelar {pokemon.Nome}", "Ok");
                    });

                    _pageDialogService.DisplayActionSheetAsync($"O que vc quer fazer com o {pokemon.Nome}?", editarPokemonButton, excluirPokemonButton, detalhePokemonButton, cancelaPokemonButton);
                    //_pageDialogService.DisplayAlertAsync("Nome Pokémon", pokemon.Nome, "Ok");
                });
            }
        }

        public ListagemPokemonsPageViewModel(IPokemonService pokemonService, INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _pokemonService = pokemonService;
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;

            Pokemons = _pokemonService.SelectAll();
        }
    }
}
