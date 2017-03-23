using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoGameStore.Web.Models.Factories.Contracts
{
    public interface IAddGameViewModelFactory
    {
        AddGameViewModel Create(IList<CheckBoxModel> checkBoxesCategories, IList<CheckBoxModel> platforms);
    }
}