using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Controller for group A
namespace JamFactory.Controller {
    class IngredientController 
    {
        Database.OptimeringDatabaseFacade _DBF;

        public IngredientController()
        {
            this._DBF = new Database.OptimeringDatabaseFacade();
        }

        /* Calculates the actual price to produce a product*/
        public double CalculateProductPrice()
        {

        }

        /* Calculates the product waste from all of the products and the fruits remaning*/
        public double CalculateProductsWaste(List<Model.Fruit> FruitsRemaining, List<Model.IngredientLine> FruitsUsed)
        {

        }

        /* Calculates the products that can be made out from the remaining resources*/
        public void CalculateRemainingResource() 
        {
            List<Model.Product> AllProducts = _DBF.GetAllProducts();
            List<Model.IngredientLine> AllIngredientLines = _DBF.GetAllIngredientLines();
            //List<Model.Fruit> AllFruits = _DBF.GetAllFruits();


        }
    }
}
