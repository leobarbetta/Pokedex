using System.Collections.ObjectModel;
using Pokedex.Services.Interfaces;
using Pokedex.ViewModels;

namespace Pokedex.Services.Impl
{
    public class InMemoryPokemonService : IPokemonService
    {
        private static ObservableCollection<PokemonViewModel> _pokemons = new ObservableCollection<PokemonViewModel>();

        public InMemoryPokemonService()
        {
            if (_pokemons.Count == 0)
            {
                _pokemons.Add(new PokemonViewModel
                {
                    Numero = 1,
                    Nome = "Bulbassauro"
                });
            }
        }

        public void Delete(PokemonViewModel Pokemon)
        {
            _pokemons.Remove(Pokemon);
        }

        public void Inserir(PokemonViewModel pokemon)
        {
            _pokemons.Add(pokemon);
        }

        public ObservableCollection<PokemonViewModel> SelectAll()
        {
            return _pokemons;
        }

        public void Update(PokemonViewModel Pokemon)
        {
            
        }
    }
}
