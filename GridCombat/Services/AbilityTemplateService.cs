namespace GridCombat.Services
{
    #region Usings

    using GridCombat.Actors;
    using GridCombat.Enums;
    using System.Collections.Generic;

    #endregion

    static class AbilityTemplateService
    {
        public static List<Tile> GetAffectedTiles(AbilityTemplateType abilityTemplateType)
        {
            List<Tile> result = new List<Tile>();

            switch(abilityTemplateType)
            {
                case AbilityTemplateType.SingleTarget:
                    result = SingleTargetTemplate();
                    break;

                case AbilityTemplateType.AreaEffect:
                    result = AreaEffectTemplate();
                    break;
            }

            return result;
        }

        private static List<Tile> SingleTargetTemplate()
        {
            List<Tile> result = new List<Tile>();



            return result;
        }

        private static List<Tile> AreaEffectTemplate()
        {
            List<Tile> result = new List<Tile>();



            return result;
        }
    }
}
