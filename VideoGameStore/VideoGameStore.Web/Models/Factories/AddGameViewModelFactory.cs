using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoGameStore.Web.Models.Factories.Contracts;

namespace VideoGameStore.Web.Models.Factories
{
    public class AddGameViewModelFactory : IAddGameViewModelFactory
    {
        public AddGameViewModel Create(IList<CheckBoxModel> checkBoxesCategories, IList<CheckBoxModel> platforms)
        {
            if (checkBoxesCategories == null)
            {
                throw new NullReferenceException("checkBoxesCategories cannot be null");
            }

            if (platforms == null)
            {
                throw new NullReferenceException("platforms cannot be null");
            }

            AddGameViewModel model = new AddGameViewModel();

            model.CheckBoxesCategories = checkBoxesCategories;
            model.Platforms = platforms;

            return model;
        }
    }
}