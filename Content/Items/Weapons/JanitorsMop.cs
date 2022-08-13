using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace TheJanitor.Content.Items.Weapons
{
    internal class JanitorsMop : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Janitor's Mop");
            Tooltip.SetDefault("He mops but never cleans");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            // Hitbox
            Item.width = 64;
            Item.height = 64;

            // Use and Animation style
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.autoReuse = false;

            // Damage Values
            Item.DamageType = DamageClass.Melee;
            Item.damage = JanitorsMop.GetDamage();
            Item.knockBack = 1.5f;

            // Misc
            Item.value = Item.buyPrice(copper: 1);
            Item.rare = ItemRarityID.Blue;

            // Sound
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.DirtBlock, 1) // Adds ingredients and quantity
                .AddTile(TileID.Anvils) // Adds crafting station
                .Register(); // Registers the item
        }

        public static int GetDamage()
        {
            // Use the janitors age as the damage (ex: 1991 = 30 y/o)
            var today = System.DateTime.Today;
            var birthday = System.DateTime.Parse("8.16.1991");
            var age = today.Year - birthday.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (birthday.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
