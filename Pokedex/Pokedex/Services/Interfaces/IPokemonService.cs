using Pokedex.ViewModels;
using System.Collections.ObjectModel;

namespace Pokedex.Services.Interfaces
{
    public interface IPokemonService
    {
        ObservableCollection<PokemonViewModel> SelectAll();
        void Inserir(PokemonViewModel pokemon);
        void Update(PokemonViewModel Pokemon);
        void Delete(PokemonViewModel Pokemon);
    }
}
