namespace SilpoBonusCore
{
    public class FactorByCategoryOffer : Offer
    {

        public readonly Category category;
        public readonly int factor;

        public FactorByCategoryOffer(Category category, int factor)
        {
            this.category = category;
            this.factor = factor;
        }

        public override void Apply(Check check, Offer offer)
        {
            FactorByCategoryOffer fbOffer = (FactorByCategoryOffer) offer;
            int points = check.GetCostByCategory(fbOffer.category);
            check.AddPoints(points * (fbOffer.factor - 1));
        }
    }
}